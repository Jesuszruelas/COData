using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Applogin
{
    public partial class FrmCatCliente : Form
    {
        ClienteControlador Controladorr = new ClienteControlador();
        public FrmCatCliente()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            MnPrincipal principal = new MnPrincipal();
            principal.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmCatCliente_Load(object sender, EventArgs e)
        {
            
            
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            
        }
        

        private void CtId_TextChanged(object sender, EventArgs e)
        {

        }


        private void lblID_Click(object sender, EventArgs e)
        {
            string connectionString = "server=SKU100131817;database=pruebaConexion;Trusted_Connection=true";

            try
            {
                int clienteID = int.Parse(lblID.Text);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT clienteID, clienteNombre, clienteEdad, 
                                   clienteMail, contraCliente
                           FROM Clientes 
                           WHERE clienteID = @clienteID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@clienteID", clienteID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Mostrar datos con formato descriptivo
                                lblID.Text = $"ID: {reader["clienteID"]}";
                                lblNombre.Text = $"Nombre: {reader["clienteNombre"]}";
                                lblEdad.Text = $"Edad: {reader["clienteEdad"]} años";
                                lblEmail.Text = $"Email: {reader["clienteMail"]}";

                     
                                // Cambiar color del nombre para destacar
                                lblNombre.ForeColor = Color.Blue;
                                lblNombre.Font = new Font(lblNombre.Font, FontStyle.Bold);

                                MessageBox.Show($"Cliente: {reader["clienteNombre"]}\n" +
                                              $"Edad: {reader["clienteEdad"]} años\n" +
                                              $"Email: {reader["clienteMail"]}",
                                              "Información del Cliente",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                LimpiarEtiquetasClienteConFormato();
                                MessageBox.Show($"No se encontró el cliente con ID: {clienteID}",
                                              "Cliente No Encontrado",
                                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del cliente: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarEtiquetasClienteConFormato()
        {
            lblID.Text = "ID: ";
            lblNombre.Text = "Nombre: ";
            lblEdad.Text = "Edad: ";
            lblEmail.Text = "Email: ";
            lblNombre.ForeColor = Color.Black;
            lblNombre.Font = new Font(lblNombre.Font, FontStyle.Regular);
        }



    }
}
