using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace EneTarea3
{
    public partial class CalculoSueldoForm : Form
    {
        public CalculoSueldoForm()
        {
            InitializeComponent();
            lblSueldoBruto.Text = string.Empty;
            lblDescuentoAFP.Text = string.Empty;
            lblDescuentoSalud.Text = string.Empty;
            lblSueldoLiquido.Text = string.Empty;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRut.Text))
            {
                MessageBox.Show("Por favor, ingresa un RUT válido.");
                return;
            }

            if (!EsRutValido(txtRut.Text))
            {
                MessageBox.Show("El RUT ingresado no es válido. Asegúrate de que tenga el formato correcto.");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT SueldoBase, HorasTrabajadas, HorasExtras, AFPId, SaludId FROM Trabajadores WHERE RUT=@rut";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@rut", txtRut.Text.Trim());

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal sueldoBase = Convert.ToDecimal(reader["SueldoBase"]);
                            int horasTrabajadas = Convert.ToInt32(reader["HorasTrabajadas"]);
                            int horasExtras = Convert.ToInt32(reader["HorasExtras"]);
                            int afpId = Convert.ToInt32(reader["AFPId"]);
                            int saludId = Convert.ToInt32(reader["SaludId"]);

                            // Cálculo del sueldo bruto
                            decimal sueldoBruto = sueldoBase + ((sueldoBase / 30) * 1.5M * horasExtras);
                            decimal tasaAfp = ObtenerTasa(conn, "AFPs", afpId);
                            decimal tasaSalud = ObtenerTasa(conn, "Salud", saludId);
                            decimal descuentoAFP = sueldoBruto * tasaAfp;
                            decimal descuentoSalud = sueldoBruto * tasaSalud;
                            decimal sueldoLiquido = sueldoBruto - descuentoAFP - descuentoSalud;

                            lblSueldoBruto.Text = $"Sueldo Bruto: {sueldoBruto:C}";
                            lblDescuentoAFP.Text = $"Descuento AFP: {descuentoAFP:C}";
                            lblDescuentoSalud.Text = $"Descuento Salud: {descuentoSalud:C}";
                            lblSueldoLiquido.Text = $"Sueldo Líquido: {sueldoLiquido:C}";
                        }
                        else
                        {
                            MessageBox.Show("Trabajador no encontrado.");
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

        private decimal ObtenerTasa(SqlConnection conn, string tabla, int id)
        {
            using (SqlCommand cmd = new SqlCommand($"SELECT Tasa FROM {tabla} WHERE Id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                var result = cmd.ExecuteScalar();
                if (result == null)
                {
                    throw new Exception($"No se encontró la tasa para el id: {id} en la tabla {tabla}");
                }
                return Convert.ToDecimal(result);
            }
        }

        private bool EsRutValido(string rut)
        {
            if (string.IsNullOrWhiteSpace(rut) || rut.Length < 9)
            {
                return false;
            }
            return true;
        }
    }
}

