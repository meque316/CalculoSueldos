using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace EneTarea3
{
    public partial class TrabajadoresForm : Form
    {
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public TrabajadoresForm()
        {
            InitializeComponent();
        }

        private void TrabajadoresForm_Load(object sender, EventArgs e)
        {
            CargarTrabajadores();
        }

        private void CargarTrabajadores()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["miConexion"]?.ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT RUT, Nombre, Direccion, Telefono, SueldoBase, HorasTrabajadas, HorasExtras FROM Trabajadores";
                    dataAdapter = new SqlDataAdapter(query, conn);
                    dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgvTrabajadores.DataSource = dataTable;
                    dgvTrabajadores.ReadOnly = true;
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error en la conexión a la base de datos: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarTrabajadores();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            dgvTrabajadores.ReadOnly = false;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["miConexion"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("La cadena de conexión no se ha inicializado correctamente.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dgvTrabajadores.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string rut = row.Cells["RUT"].Value.ToString();
                        string nombre = row.Cells["Nombre"].Value.ToString();
                        string direccion = row.Cells["Direccion"].Value.ToString();
                        string telefono = row.Cells["Telefono"].Value.ToString();
                        decimal sueldoBase = Convert.ToDecimal(row.Cells["SueldoBase"].Value);
                        int horasTrabajadas = Convert.ToInt32(row.Cells["HorasTrabajadas"].Value);
                        int horasExtras = Convert.ToInt32(row.Cells["HorasExtras"].Value);

                        string query = "UPDATE Trabajadores SET Nombre = @nombre, Direccion = @direccion, Telefono = @telefono, SueldoBase = @sueldoBase, HorasTrabajadas = @horasTrabajadas, HorasExtras = @horasExtras WHERE RUT = @rut";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@rut", rut);
                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            cmd.Parameters.AddWithValue("@direccion", direccion);
                            cmd.Parameters.AddWithValue("@telefono", telefono);
                            cmd.Parameters.AddWithValue("@sueldoBase", sueldoBase);
                            cmd.Parameters.AddWithValue("@horasTrabajadas", horasTrabajadas);
                            cmd.Parameters.AddWithValue("@horasExtras", horasExtras);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Cambios guardados exitosamente.");
                    dgvTrabajadores.ReadOnly = true;
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error en la conexión a la base de datos: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTrabajadores.SelectedRows.Count > 0)
            {
                string rut = dgvTrabajadores.SelectedRows[0].Cells["RUT"].Value.ToString();

                var confirmResult = MessageBox.Show($"¿Estás seguro de que deseas eliminar al trabajador con RUT: {rut}?",
                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;

                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "DELETE FROM Trabajadores WHERE RUT = @rut";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@rut", rut);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Trabajador eliminado exitosamente.");
                                    CargarTrabajadores();
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró un trabajador con ese RUT.");
                                }
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show("Error en la conexión a la base de datos: " + sqlEx.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inesperado: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un trabajador para eliminar.");
            }
        }
    }
}




