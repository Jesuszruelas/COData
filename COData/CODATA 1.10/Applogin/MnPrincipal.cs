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
        // Lista estática para compartir reportes entre formularios
        public static List<string> reportesCompartidos = new List<string>();

        public MnPrincipal()
        {
            InitializeComponent();
            InicializarReportes();
            ActualizarListaReportes();
        }

        private void InicializarReportes()
        {
            // Solo agregar reportes si la lista está vacía (primera vez)
            if (reportesCompartidos.Count == 0)
            {
                reportesCompartidos.Add("Sistema de agua deficiente - Crítica");
                reportesCompartidos.Add("Corregir alumbrado público - Alta");
            }
        }

        private void ActualizarListaReportes()
        {
            // Buscar el ListBox en el formulario principal
            ListBox lb = this.Controls.Find("listBoxReportes", true).FirstOrDefault() as ListBox;

            if (lb != null)
            {
                lb.DataSource = null;
                lb.DataSource = new List<string>(reportesCompartidos);

                if (reportesCompartidos.Count == 0)
                {
                    lb.Items.Clear();
                    lb.Items.Add("No hay reportes disponibles");
                }
            }
        }

        // Método para agregar reporte desde el menú principal
        private string PedirTexto(string mensaje, string titulo, string textoInicial = "")
        {
            Form ventana = new Form();
            ventana.Text = titulo;
            ventana.Size = new Size(400, 150);
            ventana.StartPosition = FormStartPosition.CenterParent;
            ventana.FormBorderStyle = FormBorderStyle.FixedDialog;
            ventana.MaximizeBox = false;
            ventana.MinimizeBox = false;

            Label etiqueta = new Label();
            etiqueta.Text = mensaje;
            etiqueta.Location = new Point(10, 10);
            etiqueta.Size = new Size(350, 20);

            TextBox cajaTexto = new TextBox();
            cajaTexto.Text = textoInicial;
            cajaTexto.Location = new Point(10, 35);
            cajaTexto.Size = new Size(350, 20);

            Button botonOK = new Button();
            botonOK.Text = "Aceptar";
            botonOK.Location = new Point(200, 70);
            botonOK.Size = new Size(75, 25);
            botonOK.DialogResult = DialogResult.OK;

            Button botonCancelar = new Button();
            botonCancelar.Text = "Cancelar";
            botonCancelar.Location = new Point(285, 70);
            botonCancelar.Size = new Size(75, 25);
            botonCancelar.DialogResult = DialogResult.Cancel;

            ventana.Controls.Add(etiqueta);
            ventana.Controls.Add(cajaTexto);
            ventana.Controls.Add(botonOK);
            ventana.Controls.Add(botonCancelar);

            if (ventana.ShowDialog() == DialogResult.OK)
                return cajaTexto.Text;
            else
                return "";
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

        //Boton Enviar - MODIFICADO para agregar reporte 
        private void button1_Click(object sender, EventArgs e)
        {
            GestorReportes.AgregarNuevoReporte();
        }

        //Boton Salir
        private void button8_Click(object sender, EventArgs e)
        {
            pnlogin login = new pnlogin();
            login.Show();
            this.Hide();
        }

        // Nuevo método para cuando el formulario se muestra de nuevo
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
            if (value)
            {
                ActualizarListaReportes(); // Actualizar lista cuando se muestra el formulario
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
