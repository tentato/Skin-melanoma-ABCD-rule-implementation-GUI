using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App1
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        public static double A = 0.0;
        public static double B = 0.0;
        public static double C = 0.0;
        public static double D = 0.0;
        public static double TDS = 0.0;

        [STAThread]
        static void Main()
        {
            CultureInfo info = new CultureInfo("en-US");
            info.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = info;
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
            Application.Run(form1);
        }
    }
}
