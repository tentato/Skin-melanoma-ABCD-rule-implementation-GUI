using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App1
{
    public partial class Form2 : Form
    {
        double licznik = 0.0;
        public string logFilePath = @"C:\Users\alepa\Desktop\Inz\Code\log_file.txt";


        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Program.D = licznik*0.5;
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine("[Results] D=" + Program.D);
            }
            Program.TDS = Program.A + Program.B + Program.C + Program.D;
            this.Hide();
            if(Program.TDS < 4.75)
            {
                MessageBox.Show("Benign melanocytic lesion", "Wynik");
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine("[Final result] Benign melanocytic lesion... TDS = " + Program.TDS);
                }
            }
            else if(Program.TDS < 5.45)
            {
                MessageBox.Show("Suspicious lesion; close follow-up or excision recommended", "Wynik");
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine("[Final result] Suspicious lesion; close follow-up or excision recommended... TDS = " + Program.TDS);
                }
            }
            else 
            {
                MessageBox.Show("Lesion highly suggestive of melanoma...\n\nFalse-positive score (>5.45) sometimes observed in:\nReed and Spitz nevus\nClark nevus with globular pattern\nCongenital melanocytic nevus.", "Wynik");
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine("[Final result] Lesion highly suggestive of melanoma...\n\nFalse-positive score (>5.45) sometimes observed in:\nReed and Spitz nevus\nClark nevus with globular pattern\nCongenital melanocytic nevus TDS = " + Program.TDS);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { licznik++; }
            else { licznik--; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { licznik++; }
            else { licznik--; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked) { licznik++; }
            else { licznik--; }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked) { licznik++; }
            else { licznik--; }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked) { licznik++; }
            else { licznik--; }
        }
    }
}
