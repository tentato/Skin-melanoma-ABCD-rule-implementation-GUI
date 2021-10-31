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
        int licznik=0;
        private string imagePath;

        public Form1()
        {
            InitializeComponent();
        }
                private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            imagePath = string.Empty;

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
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            run_script();
        }

        private void run_script()
        {

            string fileName = string.Format(@"C:\Users\alepa\Desktop\Inz\Code\main.py {0}", imagePath);

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Users\alepa\AppData\Local\Microsoft\WindowsApps\python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(output);

            Console.ReadLine();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
