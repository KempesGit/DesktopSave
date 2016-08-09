using System;
using System.Windows.Forms;
using System.Threading;

namespace DesktopSave
{
    static class Program
    {
        private static Mutex s_Mutex;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            s_Mutex = new Mutex(true, "DesktopSaveMutex");

            if (s_Mutex.WaitOne(0, false))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
            else
            {
                MessageBox.Show("Another DesktopSave instance is running.", "DesktopSave", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
