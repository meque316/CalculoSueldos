using System;
using System.Windows.Forms;
using ENETarea3;

namespace EneTarea3
{
    public partial class MainMenuForm : Form
    {
        private LoginForm loginForm;

        public MainMenuForm(LoginForm form)
        {
            InitializeComponent();
            loginForm = form;
            btnRegistroTrabajador.Click += btnRegistroTrabajador_Click;
            btnVerTrabajadores.Click += btnVerTrabajadores_Click;
            btnCalcularSueldo.Click += btnCalcularSueldo_Click;
            btnLogout.Click += btnLogout_Click;
        }

        private void btnRegistroTrabajador_Click(object sender, EventArgs e)
        {
            RegistroTrabajadorForm registroForm = new RegistroTrabajadorForm();
            registroForm.Show();
        }

        private void btnVerTrabajadores_Click(object sender, EventArgs e)
        {
            TrabajadoresForm verForm = new TrabajadoresForm();
            verForm.Show();
        }

        private void btnCalcularSueldo_Click(object sender, EventArgs e)
        {
            CalculoSueldoForm calculoForm = new CalculoSueldoForm();
            calculoForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            this.Close();
        }
    }
}
