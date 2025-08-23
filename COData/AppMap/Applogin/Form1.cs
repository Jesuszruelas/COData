using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (txtUser.Text.Trim().ToUpper() == "ADMIN")
            {
                if (txtContra.Text.Trim().ToUpper() == "1234")
                {
                    this.Hide();
                    PantallaCarga carga = new PantallaCarga();
                    carga.ShowDialog();


                    
                    MnPrincipal mnPrincipal = new MnPrincipal();
                    mnPrincipal.Show();
                    
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta", "login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Usuario incorrecto", "login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

    }
}
