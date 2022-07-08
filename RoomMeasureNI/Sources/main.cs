using RoomMeasureNI.GUI;
using System;
using System.Windows.Forms;

namespace RoomMeasureNI.Sources
{
    internal static class main
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new main_window());
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}