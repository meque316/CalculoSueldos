using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using EneTarea3;

namespace ENETarea3
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor, ingrese un usuario y una contraseña válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString))
                {
                    sqlCon.Open();
                    string query = "SELECT Rol FROM Usuarios WHERE Username=@Username AND Password=@Password";
                    using (SqlCommand sqlCmd = new SqlCommand(query, sqlCon))
                    {
                        sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

                        object rol = sqlCmd.ExecuteScalar();

                        if (rol != null)
                        {
                            int roleId = Convert.ToInt32(rol);

                            if (roleId == 1)
                            {
                                EneTarea3.MainMenuForm mainMenuForm = new EneTarea3.MainMenuForm(this);
                                this.Hide();
                                mainMenuForm.ShowDialog();
                            }
                            else if (roleId == 0)
                            {
                                CalculoSueldoForm calculoForm = new CalculoSueldoForm();
                                this.Hide();
                                calculoForm.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos. Inténtelo nuevamente.", "Login fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}





