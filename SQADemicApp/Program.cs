using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQADemicApp
{
    static class Program
    {
        public static string[] rolesArray;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SetupGameForm());
            Form1 form1 = new Form1(rolesArray);
            Application.Run(form1);
        }
    }
}
