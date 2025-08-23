using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applogin
{
    public partial class MnRegistro : Form
    {
        public MnRegistro()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            pnlogin pnlogin = new pnlogin();
            pnlogin.Show();
        }

        void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtEdad.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            txtpass.Text = string.Empty;

            txtNombre.Enabled = true;
            txtNombre.Focus();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtEdad.Text) ||
                string.IsNullOrWhiteSpace(TxtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtpass.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtEdad.Text.Trim(), out int edad))
            {
                MessageBox.Show("La edad debe ser un número válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(Conexion.strConexion))
            {
                SqlTransaction transaction = null;
                try
                {
                    conn.Open();

                    // Iniciar transacción para evitar problemas de concurrencia
                    transaction = conn.BeginTransaction();

                    // Obtener el próximo ID disponible con bloqueo de tabla para evitar duplicados
                    string queryGetNextId = "SELECT ISNULL(MAX(clienteID), 0) + 1 FROM Clientes WITH (TABLOCKX)";
                    int nuevoClienteID;

                    using (SqlCommand cmdGetId = new SqlCommand(queryGetNextId, conn, transaction))
                    {
                        nuevoClienteID = (int)cmdGetId.ExecuteScalar();
                    }

                    // Insertar el nuevo cliente con el ID asignado manualmente
                    string query = "INSERT INTO Clientes (clienteID, clienteNombre, clienteEdad, clienteMail, contraCliente) VALUES (@clienteID, @clienteNombre, @clienteEdad, @clienteMail, @contraCliente)";

                    using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@clienteID", nuevoClienteID);
                        cmd.Parameters.AddWithValue("@clienteNombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@clienteEdad", edad);
                        cmd.Parameters.AddWithValue("@clienteMail", TxtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@contraCliente", txtpass.Text.Trim());

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            // Confirmar la transacción
                            transaction.Commit();

                            // Mostrar mensaje de éxito con el ID asignado
                            MessageBox.Show($"Usuario registrado exitosamente con ID: {nuevoClienteID}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar(); // Limpiar los campos después de registrar
                        }
                        else
                        {
                            // Rollback si no se insertó ninguna fila
                            transaction.Rollback();
                            MessageBox.Show("No se pudo registrar el usuario. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    // Rollback en caso de error de SQL
                    transaction?.Rollback();

                    if (sqlEx.Number == 2627 || sqlEx.Number == 2601) // Error de clave duplicada
                    {
                        MessageBox.Show("Ya existe un usuario con ese ID. Intente nuevamente.", "Error de duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Error en la base de datos:\n" + sqlEx.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Rollback en caso de cualquier otro error
                    transaction?.Rollback();
                    MessageBox.Show("Error al conectar con la base de datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void MnRegistro_Load(object sender, EventArgs e)
        {

        }
        private bool ShowPass = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ShowPass = !ShowPass;
            if (ShowPass)
            {
                txtpass.PasswordChar = '\0';
            }
            else { txtpass.PasswordChar = '*'; }
        }
    }
}
