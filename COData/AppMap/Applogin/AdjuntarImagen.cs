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
    public partial class AdjuntarImagen : Form
    {
        public AdjuntarImagen()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog Archivo = new OpenFileDialog();
            Archivo.Filter = "Archivos de imagenes (*.png; *.jpg)| *.png; *.jpg";

            if(Archivo.ShowDialog() == DialogResult.OK) 
            {
                pictureBox1.Image= Image.FromFile(Archivo.FileName);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MnPrincipal mnPrincipal = new MnPrincipal();
            mnPrincipal.Show();
        }
    }
}
