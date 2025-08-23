using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            txtNombre.Enabled = true;
            txtNombre.Text="";
            txtEdad.Text = "";
            TxtEmail.Text = "";
            txtNombre.Focus();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
