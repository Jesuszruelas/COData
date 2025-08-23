using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Applogin
{
    public partial class pnlogin : Form
    {
        private bool ShowPass  = false;
        public pnlogin()
        {
            InitializeComponent();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bntAceptar_Click(object sender, EventArgs e)
        {
            string usuario = txtUser.Text.Trim();
            string contraseña = txtContra.Text.Trim();

            using (SqlConnection conn = new SqlConnection(Conexion.strConexion))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Clientes WHERE clienteMail = @clienteMail AND contraCliente = @contraCliente";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@clienteMail", usuario);
                        cmd.Parameters.AddWithValue("@contraCliente", contraseña); // Idealmente usar hash

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            this.Hide();
                            PantallaCarga carga = new PantallaCarga();
                            carga.ShowDialog();

                            MnPrincipal mnPrincipal = new MnPrincipal();
                            mnPrincipal.Show();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void pnlogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MnRegistro registro = new MnRegistro();
            registro.Show();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ShowPass = !ShowPass;
            if (ShowPass)
            {
                txtContra.PasswordChar = '\0';
            }
            else { txtContra.PasswordChar = '*'; }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
           
            
        }
    }
}
