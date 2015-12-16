using System;
using System.Windows.Forms;

namespace SQADemicApp
{
    internal static class Program
    {
        public static string[] rolesArray;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SetupGameForm());
            GameBoard form1 = new GameBoard(rolesArray);
            Application.Run(form1);
        }
    }
}