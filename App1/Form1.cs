using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;
using System.Threading.Tasks;

namespace App1
{
    public partial class Form1 : Form
    {
        //public string textBoxText = "Instrukcja: " + Environment.NewLine + "1. Naciśnij przycisk \"Załaduj obraz\", aby wybrać i załadować obraz. " + Environment.NewLine + "2. Naciśnij przycisk \"Zbadaj\", aby dokonać analizy obrazu. " + Environment.NewLine + Environment.NewLine + "Wyniki zostaną przedstawione w osobnym oknie.";

        private string imagePath = string.Empty;
        public string logFilePath = @"C:\Users\alepa\Desktop\Inz\Code\log_file.txt";
        public string D = string.Empty;
        public string TDS = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            var fileContent = string.Empty;

            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "C:\\Users\\alepa\\Desktop\\Inz\\Skin_melanoma\\to_process";
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        imagePath = openFileDialog.FileName;
                    }
                }
                pictureBox1.Image = Image.FromFile(imagePath);
                textBox1.Text = "Gotowy do zbadania";
            }
            catch (Exception exception)
            {
                Console.WriteLine("{0} Exception caught.", exception);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Najpierw załaduj obraz!", "Ostrzeżenie");
            }
            else
            {
                textBox1.Text = "Automatyczna analiza rozpoczęta - nie zamykaj aplikacji";
                run_script();
                textBox1.Text = "Automatyczna analiza zakończona";

                string[] logFileLines = File.ReadAllLines(logFilePath);

                foreach (string line in logFileLines)
                {
                    int position = line.IndexOf("=");

                    if (line.Contains("[Results] A="))
                    {
                        string line_temp = line.Substring(position + 1);
                        Program.A = Convert.ToDouble(line_temp);
                    }
                    if (line.Contains("[Results] B="))
                    {
                        string line_temp = line.Substring(position + 1);
                        Program.B = Convert.ToDouble(line_temp);
                    }
                    if (line.Contains("[Results] C="))
                    {
                        string line_temp = line.Substring(position + 1);
                        Program.C = Convert.ToDouble(line_temp);
                    }
                }
                using (Form2 form2 = new Form2())
                {
                    form2.ShowDialog();
                }
                textBox2.Visible = true;
                textBox5.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox6.Visible = true;
                label3.Visible = true;
                label6.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label7.Visible = true;
                textBox2.Text = Program.A.ToString();
                textBox5.Text = Program.B.ToString();
                textBox3.Text = Program.C.ToString();
                textBox4.Text = Program.D.ToString();
                textBox6.Text = Program.TDS.ToString();

                button3.Visible = true;
            }

        }

        private void run_script()
        {
            var cmd = string.Format("-u C:/Users/alepa/Desktop/Inz/Code/main.py {0}", imagePath);
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "C:/Users/alepa/AppData/Local/Microsoft/WindowsApps/python.exe",
                    Arguments = cmd,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                },
                EnableRaisingEvents = true
            };
            process.ErrorDataReceived += Process_OutputDataReceived;
            process.OutputDataReceived += Process_OutputDataReceived;

            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            process.WaitForExit();
            Console.Read();
        }
        static void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TDS < 4.75 -- Łagodne znamię melanocytowe    \n\n4.75 < TDS < 5.45 -- Podejrzana zmiana, zalecana kontrola   \n\nTDS > 5.45 -- Wysoce podejrzana zmiana", "Informacje o Total Dermoscopy Score (TDS)");
        }
    }
}
