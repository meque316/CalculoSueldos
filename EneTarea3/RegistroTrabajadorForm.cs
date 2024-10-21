using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace ENETarea3
{
    public partial class RegistroTrabajadorForm : Form
    {
        public RegistroTrabajadorForm()
        {
            InitializeComponent();
            CargarDatosComboBoxes();
        }

        private void CargarDatosComboBoxes()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmdAFP = new SqlCommand("SELECT Id, Nombre FROM AFPs", conn))
                    {
                        using (SqlDataAdapter adapterAFP = new SqlDataAdapter(cmdAFP))
                        {
                            DataTable dtAFP = new DataTable();
                            adapterAFP.Fill(dtAFP);
                            cmbAFP.DataSource = dtAFP;
                            cmbAFP.DisplayMember = "Nombre";
                            cmbAFP.ValueMember = "Id";
                        }
                    }

                    using (SqlCommand cmdSalud = new SqlCommand("SELECT Id, Nombre FROM Salud", conn))
                    {
                        using (SqlDataAdapter adapterSalud = new SqlDataAdapter(cmdSalud))
                        {
                            DataTable dtSalud = new DataTable();
                            adapterSalud.Fill(dtSalud);
                            cmbSalud.DataSource = dtSalud;
                            cmbSalud.DisplayMember = "Nombre";
                            cmbSalud.ValueMember = "Id";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRut.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtSueldoBase.Text) || string.IsNullOrWhiteSpace(txtHorasTrabajadas.Text) ||
                string.IsNullOrWhiteSpace(txtHorasExtras.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            if (!decimal.TryParse(txtSueldoBase.Text, out decimal sueldoBase) ||
                !int.TryParse(txtHorasTrabajadas.Text, out int horasTrabajadas) ||
                !int.TryParse(txtHorasExtras.Text, out int horasExtras))
            {
                MessageBox.Show("Por favor, ingrese un sueldo base válido y horas trabajadas/extras válidas.");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "INSERT INTO Trabajadores (RUT, Nombre, Direccion, Telefono, SueldoBase, HorasTrabajadas, HorasExtras, AFPId, SaludId) " +
                                   "VALUES (@rut, @nombre, @direccion, @telefono, @sueldoBase, @horasTrabajadas, @horasExtras, @afpId, @saludId)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@rut", txtRut.Text.Trim());
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@sueldoBase", sueldoBase);
                        cmd.Parameters.AddWithValue("@horasTrabajadas", horasTrabajadas);
                        cmd.Parameters.AddWithValue("@horasExtras", horasExtras);
                        cmd.Parameters.AddWithValue("@afpId", (int)cmbAFP.SelectedValue);
                        cmd.Parameters.AddWithValue("@saludId", (int)cmbSalud.SelectedValue);

                        await cmd.ExecuteNonQueryAsync();
                        MessageBox.Show("Trabajador registrado correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar trabajador: " + ex.Message);
            }
        }
    }
}



