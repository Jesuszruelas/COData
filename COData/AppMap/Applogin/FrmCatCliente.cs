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
    public partial class FrmCatCliente : Form
    {
        ClienteControlador Controladorr = new ClienteControlador();
        public FrmCatCliente()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmCatCliente_Load(object sender, EventArgs e)
        {
            llenarGrid();
            Limpiar();
        }
        void llenarGrid()
        {
            List<Cliente> clis =Controladorr.ListatCliente();
            grid.DataSource = clis;
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.Rows.Count > 0)
            {
                CtId.Enabled = false;
                CtId.Text = grid[0,e.RowIndex].Value.ToString();
                CtNombre.Text=grid[1, e.RowIndex].Value.ToString();
                CtEdad.Text=grid[2, e.RowIndex].Value.ToString();
                CtEmail.Text=grid[3, e.RowIndex].Value.ToString();

            }
        }
        void Limpiar()
        {
            CtId.Enabled=true;
            CtId.Text = "";
            CtNombre.Text = "";
            CtEdad.Text = "";
            CtEmail.Text = "";
            CtId.Focus();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        void LlenarForma(int id) 
        {
            Cliente cliente= Controladorr.OptenerCliente(id);
            if (cliente != null) 
            {
                CtId.Enabled=false;
                CtId.Text=cliente.Cli_id.ToString();
                CtNombre.Text = cliente.Cli_nombre;
                CtEdad.Text=cliente.Cli_edad.ToString();
                CtEmail.Text = cliente.Cli_email;
            }
        }

        private void BtnGuarda_Click(object sender, EventArgs e)
        {
            bool guardo = false;
            int id, edad;
            string nombre, email;
            if (CtId.Text.Trim() == "")
            {
                MessageBox.Show("Favor de teclear id");
                CtId.Focus();
                return;
            }
            if (CtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Favor de teclear Nombre");
                CtNombre.Focus();
                return;
            }
            if (CtEdad.Text.Trim() == "")
            {
                MessageBox.Show("Favor de teclear Edad");
                CtEdad.Focus();
                return;
            }
            if (CtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Favor de teclear E-mail");
                CtEmail.Focus();
                return;
            }
            id = Convert.ToInt32(CtId.Text);
            nombre=CtNombre.Text;
            edad=Convert.ToInt32(CtEdad.Text);
            email=CtEmail.Text;
            Cliente cli = new Cliente(id,nombre,edad,email);
            if (CtId.Enabled == true)
                guardo = Controladorr.AgregarCliente(cli);
            else
                guardo=Controladorr.ActualizarCliente(cli);
            if (guardo==true)
            {
                CtId.Enabled = false;
                llenarGrid();
                MessageBox.Show("El cliente se guardo");
            }
            else
            {
                MessageBox.Show("El cliente no se guardo");
            }
        }

        private void CtId_Leave(object sender, EventArgs e)
        {
            try 
            {
                LlenarForma(Convert.ToInt32(CtId.Text));
            
            }
            catch 
            {
                CtId.Text = "";
            }
        }

        private void CtEdad_Leave(object sender, EventArgs e)
        {
            try
            {
                CtEdad.Text = Convert.ToInt32(CtEdad.Text).ToString();
            }
            catch 
            {
                CtEdad.Text = "0";
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            bool elimino = false;
            if (CtId.Enabled == false) 
            {
                if (MessageBox.Show("¿Desea eliminar el cliente?", "Eliminar",MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    int id = Convert.ToInt32(CtId.Text);
                    elimino = Controladorr.BorarCliente(id);
                    if (elimino == true)
                    {
                        MessageBox.Show("Cliente eliminado");
                        llenarGrid();
                        Limpiar();
                    }
                    else { MessageBox.Show("El cliente no se eliminado"); }
                }

            }
        }
    }
}
