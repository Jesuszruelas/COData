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
    public partial class MnPrincipal : Form
    {
        public MnPrincipal()
        {
            InitializeComponent();
        }

        private void MnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MnPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MnCliente_Click(object sender, EventArgs e)
        {
            FrmCatCliente catCliente = new FrmCatCliente();
            catCliente.MdiParent = this;
            catCliente.Show();
        }

        private void MnPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Boton para acceder al Seguimiento de reportes
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Seguimiento seg = new Seguimiento();
            seg.Show();


        }


        //Boton para acceder al Mapa

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            GoogleMaps googleMaps = new GoogleMaps();
            googleMaps.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdjuntarImagen adjuntarImagen = new AdjuntarImagen();
            adjuntarImagen.Show();
        }

        
    }
}
