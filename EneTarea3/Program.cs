using System;
using System.Windows.Forms;

namespace ENETarea3
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm()); // Aquí debe coincidir exactamente con el nombre de la clase
        }
    }
}