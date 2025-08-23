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
    public partial class Seguimiento : Form
    {
        public Seguimiento()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


        //Boton Eliminar
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {

        }


        //Boton Actualizar
        private void btn_Actualizar_Click(object sender, EventArgs e)
        {

        }


        //Boton Agregar
        private void btn_Agregar_Click(object sender, EventArgs e)
        {

        }


        //Boton Regresar
        private void btn_Regresar_Click(object sender, EventArgs e)
        {

            this.Hide();
            MnPrincipal mnPrincipal = new MnPrincipal();
            mnPrincipal.Show();

        }

        //Todos
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string seleccion = comboBox1.SelectedItem.ToString();

        }


        //Prioridades
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string seleccion = comboBox1.SelectedItem.ToString();
        }
    }
}
