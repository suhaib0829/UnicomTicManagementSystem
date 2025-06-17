// File: Program.cs
using System;
using System.Windows.Forms;


namespace UnicomTicManagementSystem
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // We start the application by showing our LoginForm.
            Application.Run(new LoginForm());
        }
    }
}