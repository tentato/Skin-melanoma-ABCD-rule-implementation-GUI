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
            Program.TDS = Program.A + Program.B + Program.C;
            MessageBox.Show("Nie zatwierdzono wyboru przyciskiem \"OK\"! Prezentacja wyniku z pominięciem współczynnika D.", "Ostrzeżenie!");
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Program.TDS = Program.A + Program.B + Program.C;
            MessageBox.Show("Nie zatwierdzono wyboru przyciskiem \"OK\"! Prezentacja wyniku z pominięciem współczynnika D.", "Ostrzeżenie!");
            Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Program.D = licznik*0.5;
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine("[Wyniki] D=" + Program.D);
            }
            Program.TDS = Program.A + Program.B + Program.C + Program.D;
            this.Hide();
            if(Program.TDS < 4.75)
            {
                MessageBox.Show("Łagodna zmiana melanocytowa", "Wynik");
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine("[Wynik koncowy] Lagodna zmiana melanocytowa... TDS = " + Program.TDS);
                }
            }
            else if(Program.TDS < 5.45)
            {
                MessageBox.Show("Podejrzana zmiana - zalecana ścisła obserwacja", "Wynik");
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine("[Wynik koncowy] Podejrzana zmiana - zalecana scisla obserwacja... TDS = " + Program.TDS);
                }
            }
            else 
            {
                MessageBox.Show("Zmiana wysoce sugerująca czerniaka...\n\nWynik fałszywie pozytywny (>5.45) jest czasami obserwowany w:\n- znamieniu Reeda i Spitza\n- znamieniu Clarka z wzorem kulistym\n- wrodzonym znamieniu melanocytowym.", "Wynik");
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine("[Wynik koncowy] Zmiana wysoce sugerujaca czerniaka...\n\nWynik falszywie pozytywny (>5.45) jest czasami obserwowany w:\n- znamieniu Reeda i Spitza\n- znamieniu Clarka z wzorem kulistym\n- wrodzonym znamieniu melanocytowym. TDS = " + Program.TDS);
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
