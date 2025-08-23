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

namespace Applogin
{
    public partial class Seguimiento : Form
    {
        // Lista para almacenar los reportes de la base de datos
        private List<Reporte> reportes = new List<Reporte>();
        private string connectionString;

        // Clase para representar un reporte
        public class Reporte
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public string Prioridad { get; set; }
            public DateTime FechaRegistro { get; set; }
            public DateTime? FechaActualizacion { get; set; }

            // Para mostrar en el ListBox con ID (respaldo)
            public override string ToString()
            {
                return $"ID: {Id} | {Descripcion} | {Prioridad}";
            }
        }

        public Seguimiento()
        {
            InitializeComponent();

            // Configurar visualización (DataGridView o ListBox)
            ConfigurarVisualizacion();

            // Configurar ComboBoxes
            comboBox1.Items.AddRange(new string[] { "Todos", "Agua y Drenaje", "Alumbrado", "Seguridad" });
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.AddRange(new string[] { "Todos", "Crítica", "Alta", "Media", "Baja" });
            comboBox2.SelectedIndex = 0;

            CargarReportesDesdeDB();
        }

        private void ConfigurarVisualizacion()
        {
            // Buscar si hay DataGridView
            DataGridView dgv = this.Controls.Find("dataGridView1", true).FirstOrDefault() as DataGridView;

            if (dgv != null)
            {
                ConfigurarDataGridView(dgv);
            }
            else
            {
                // Si no hay DataGridView, crear uno dinámicamente
                CrearDataGridView();
            }
        }

        private void CrearDataGridView()
        {
            // Buscar el ListBox para reemplazarlo
            ListBox lb = this.Controls.Find("listBox1", true).FirstOrDefault() as ListBox;

            if (lb != null)
            {
                // Crear DataGridView en la misma posición del ListBox
                DataGridView dgv = new DataGridView();
                dgv.Name = "dataGridView1";
                dgv.Location = lb.Location;
                dgv.Size = new Size(lb.Width, lb.Height);

                // Ocultar el ListBox y agregar el DataGridView
                lb.Visible = false;
                this.Controls.Add(dgv);

                ConfigurarDataGridView(dgv);
            }
        }

        private void ConfigurarDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            // Configurar columnas con encabezados
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 60,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                Width = 300,
                ReadOnly = true
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Prioridad",
                HeaderText = "Prioridad",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaRegistro",
                HeaderText = "Fecha Registro",
                Width = 130,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy HH:mm",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // Configuración general del DataGridView
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.Fixed3D;

            // Estilo de encabezados
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 30;

            // Estilo de filas alternas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Color de selección rojo vino claro
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 100, 120); // Rojo vino claro
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black; // Texto blanco para contraste
        }

        // Cargar reportes desde la base de datos
        private void CargarReportesDesdeDB()
        {
            if (!string.IsNullOrEmpty(Conexion.strConexion))
            {
                try
                {
                    reportes.Clear();

                    using (SqlConnection conexion = new SqlConnection(Conexion.strConexion))
                    {
                        conexion.Open();
                        string query = "SELECT * FROM Reportes ORDER BY FechaRegistro DESC";

                        using (SqlCommand cmd = new SqlCommand(query, conexion))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        reportes.Add(new Reporte
                                        {
                                            Id = Convert.ToInt32(reader["Id"]),
                                            Descripcion = reader["Descripcion"].ToString(),
                                            Prioridad = reader["Prioridad"].ToString(),
                                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                                        });
                                    }
                                }
                            }
                        }
                    }

                    ActualizarLista();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar reportes: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La cadena de conexión no está configurada.",
                    "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizarLista()
        {
            // Usar DataGridView como primera opción
            DataGridView dgv = this.Controls.Find("dataGridView1", true).FirstOrDefault() as DataGridView;

            if (dgv != null)
            {
                dgv.DataSource = null;
                dgv.DataSource = new List<Reporte>(reportes);

                if (reportes.Count == 0)
                {
                    // Mostrar mensaje cuando no hay datos
                    dgv.DataSource = null;
                    dgv.Rows.Add("", "No hay reportes disponibles", "", "");
                }
            }
            else
            {
                // Usar ListBox como respaldo
                ListBox lb = this.Controls.Find("listBox1", true).FirstOrDefault() as ListBox;

                if (lb != null)
                {
                    lb.DataSource = null;
                    lb.DataSource = new List<Reporte>(reportes);

                    if (reportes.Count == 0)
                    {
                        lb.Items.Clear();
                        lb.Items.Add("No hay reportes disponibles");
                    }
                }
            }
        }

        // Método para obtener el reporte seleccionado
        private Reporte ObtenerReporteSeleccionado()
        {
            // Intentar obtener de DataGridView primero
            DataGridView dgv = this.Controls.Find("dataGridView1", true).FirstOrDefault() as DataGridView;

            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                return dgv.SelectedRows[0].DataBoundItem as Reporte;
            }
            else
            {
                // Obtener de ListBox como respaldo
                ListBox lb = this.Controls.Find("listBox1", true).FirstOrDefault() as ListBox;

                if (lb != null && lb.SelectedIndex >= 0 && lb.SelectedItem is Reporte)
                {
                    return lb.SelectedItem as Reporte;
                }
            }

            return null;
        }

        // Método para pedir descripción y prioridad
        private (string descripcion, string prioridad) PedirDatosReporte(string titulo, string descripcionInicial = "", string prioridadInicial = "Media")
        {
            Form ventana = new Form();
            ventana.Text = titulo;
            ventana.Size = new Size(400, 200);
            ventana.StartPosition = FormStartPosition.CenterParent;
            ventana.FormBorderStyle = FormBorderStyle.FixedDialog;
            ventana.MaximizeBox = false;
            ventana.MinimizeBox = false;

            // Descripción
            Label lblDescripcion = new Label();
            lblDescripcion.Text = "Descripción:";
            lblDescripcion.Location = new Point(10, 10);
            lblDescripcion.Size = new Size(80, 20);

            TextBox txtDescripcion = new TextBox();
            txtDescripcion.Text = descripcionInicial;
            txtDescripcion.Location = new Point(10, 35);
            txtDescripcion.Size = new Size(350, 20);

            // Prioridad
            Label lblPrioridad = new Label();
            lblPrioridad.Text = "Prioridad:";
            lblPrioridad.Location = new Point(10, 70);
            lblPrioridad.Size = new Size(80, 20);

            ComboBox cmbPrioridad = new ComboBox();
            cmbPrioridad.Items.AddRange(new string[] { "Crítica", "Alta", "Media", "Baja" });
            cmbPrioridad.Text = prioridadInicial;
            cmbPrioridad.Location = new Point(10, 95);
            cmbPrioridad.Size = new Size(120, 20);
            cmbPrioridad.DropDownStyle = ComboBoxStyle.DropDownList;

            // Botones
            Button botonOK = new Button();
            botonOK.Text = "Aceptar";
            botonOK.Location = new Point(200, 130);
            botonOK.Size = new Size(75, 25);
            botonOK.DialogResult = DialogResult.OK;

            Button botonCancelar = new Button();
            botonCancelar.Text = "Cancelar";
            botonCancelar.Location = new Point(285, 130);
            botonCancelar.Size = new Size(75, 25);
            botonCancelar.DialogResult = DialogResult.Cancel;

            ventana.Controls.Add(lblDescripcion);
            ventana.Controls.Add(txtDescripcion);
            ventana.Controls.Add(lblPrioridad);
            ventana.Controls.Add(cmbPrioridad);
            ventana.Controls.Add(botonOK);
            ventana.Controls.Add(botonCancelar);

            if (ventana.ShowDialog() == DialogResult.OK)
                return (txtDescripcion.Text, cmbPrioridad.Text);
            else
                return ("", "");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Boton Eliminar
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            Reporte reporteSeleccionado = ObtenerReporteSeleccionado();

            if (reporteSeleccionado != null)
            {
                DialogResult resultado = MessageBox.Show(
                    $"¿Estás seguro de eliminar el reporte ID {reporteSeleccionado.Id}?\n\n'{reporteSeleccionado.Descripcion}'",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conexion = new SqlConnection(Conexion.strConexion))
                        {
                            conexion.Open();
                            using (SqlCommand cmd = new SqlCommand("Del_Reporte", conexion))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Id", reporteSeleccionado.Id);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        CargarReportesDesdeDB();
                        MessageBox.Show("Reporte eliminado exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar reporte: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un reporte para eliminar.");
            }
        }

        //Boton Actualizar
        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            Reporte reporteSeleccionado = ObtenerReporteSeleccionado();

            if (reporteSeleccionado != null)
            {
                var (descripcion, prioridad) = PedirDatosReporte("Actualizar Reporte",
                    reporteSeleccionado.Descripcion, reporteSeleccionado.Prioridad);

                if (!string.IsNullOrEmpty(descripcion))
                {
                    try
                    {
                        using (SqlConnection conexion = new SqlConnection(Conexion.strConexion))
                        {
                            conexion.Open();
                            using (SqlCommand cmd = new SqlCommand("Upd_Reporte", conexion))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Id", reporteSeleccionado.Id);
                                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                                cmd.Parameters.AddWithValue("@Prioridad", prioridad);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        CargarReportesDesdeDB();
                        MessageBox.Show("Reporte actualizado exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar reporte: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un reporte para actualizar.");
            }
        }

        //Boton Agregar
        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            var (descripcion, prioridad) = PedirDatosReporte("Agregar Reporte");

            if (!string.IsNullOrEmpty(descripcion))
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(Conexion.strConexion))
                    {
                        conexion.Open();
                        using (SqlCommand cmd = new SqlCommand("Ins_Reporte", conexion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                            cmd.Parameters.AddWithValue("@Prioridad", prioridad);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    CargarReportesDesdeDB();
                    MessageBox.Show($"Reporte agregado: '{descripcion}'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar reporte: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Boton Regresar
        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MnPrincipal mnPrincipal = new MnPrincipal();
            mnPrincipal.Show();
        }

        //Filtro por categoría
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarReportes();
        }

        //Filtro por prioridad
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarReportes();
        }

        private void FiltrarReportes()
        {
            var reportesFiltrados = reportes.AsEnumerable();

            // Filtrar por categoría
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() != "Todos")
            {
                string categoria = comboBox1.SelectedItem.ToString();
                reportesFiltrados = reportesFiltrados.Where(r => r.Descripcion.ToLower().Contains(categoria.ToLower()));
            }

            // Filtrar por prioridad
            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() != "Todos")
            {
                string prioridad = comboBox2.SelectedItem.ToString();
                reportesFiltrados = reportesFiltrados.Where(r => r.Prioridad.Equals(prioridad, StringComparison.OrdinalIgnoreCase));
            }

            // Actualizar la visualización con los datos filtrados
            DataGridView dgv = this.Controls.Find("dataGridView1", true).FirstOrDefault() as DataGridView;

            if (dgv != null)
            {
                dgv.DataSource = null;
                dgv.DataSource = reportesFiltrados.ToList();
            }
            else
            {
                ListBox lb = this.Controls.Find("listBox1", true).FirstOrDefault() as ListBox;

                if (lb != null)
                {
                    lb.DataSource = null;
                    lb.DataSource = reportesFiltrados.ToList();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Obtener el texto de búsqueda del TextBox
            TextBox txtBusqueda = sender as TextBox;
            string terminoBusqueda = txtBusqueda.Text.Trim();

            // Empezar con todos los reportes
            var reportesFiltrados = reportes.AsEnumerable();

            // Aplicar filtros de ComboBox existentes
            // Filtrar por categoría (ComboBox1)
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() != "Todos")
            {
                string categoria = comboBox1.SelectedItem.ToString();
                reportesFiltrados = reportesFiltrados.Where(r => r.Descripcion.ToLower().Contains(categoria.ToLower()));
            }

            // Filtrar por prioridad (ComboBox2)
            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() != "Todos")
            {
                string prioridad = comboBox2.SelectedItem.ToString();
                reportesFiltrados = reportesFiltrados.Where(r => r.Prioridad.Equals(prioridad, StringComparison.OrdinalIgnoreCase));
            }

            // Aplicar filtro de búsqueda si hay texto
            if (!string.IsNullOrEmpty(terminoBusqueda))
            {
                // Intentar buscar por ID
                if (int.TryParse(terminoBusqueda, out int idBusqueda))
                {
                    reportesFiltrados = reportesFiltrados.Where(r => r.Id == idBusqueda);
                }
                else
                {
                    // Intentar buscar por fecha (varios formatos)
                    DateTime fechaBusqueda;
                    bool esFecha = DateTime.TryParse(terminoBusqueda, out fechaBusqueda) ||
                                  DateTime.TryParseExact(terminoBusqueda, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaBusqueda) ||
                                  DateTime.TryParseExact(terminoBusqueda, "dd/mm/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaBusqueda);

                    if (esFecha)
                    {
                        // Buscar por fecha exacta
                        reportesFiltrados = reportesFiltrados.Where(r => r.FechaRegistro.Date == fechaBusqueda.Date);
                    }
                    else
                    {
                        // Búsqueda general en todos los campos
                        reportesFiltrados = reportesFiltrados.Where(r =>
                            r.Descripcion.ToLower().Contains(terminoBusqueda.ToLower()) ||
                            r.Prioridad.ToLower().Contains(terminoBusqueda.ToLower()) ||
                            r.Id.ToString().Contains(terminoBusqueda) ||
                            r.FechaRegistro.ToString("dd/MM/yyyy").Contains(terminoBusqueda) ||
                            r.FechaRegistro.ToString("dd/MM/yyyy HH:mm").Contains(terminoBusqueda));
                    }
                }
            }

            // Convertir a lista
            List<Reporte> listaFiltrada = reportesFiltrados.ToList();

            // Actualizar la visualización con los datos filtrados
            DataGridView dgv = this.Controls.Find("dataGridView1", true).FirstOrDefault() as DataGridView;

            if (dgv != null)
            {
                // CORRECCIÓN: Usar siempre DataSource, nunca Rows.Add cuando está enlazado
                dgv.DataSource = null;

                if (listaFiltrada.Count == 0 && !string.IsNullOrEmpty(terminoBusqueda))
                {
                    // Crear lista con mensaje de "no encontrado"
                    var mensajeNoResultados = new List<object>
            {
                new { Id = "", Descripcion = $"No se encontraron resultados para: '{terminoBusqueda}'", Prioridad = "", FechaRegistro = "" }
            };
                    dgv.DataSource = mensajeNoResultados;
                }
                else if (listaFiltrada.Count == 0)
                {
                    // Crear lista con mensaje de "no hay reportes"
                    var mensajeVacio = new List<object>
            {
                new { Id = "", Descripcion = "No hay reportes disponibles", Prioridad = "", FechaRegistro = "" }
            };
                    dgv.DataSource = mensajeVacio;
                }
                else
                {
                    // Mostrar resultados normales
                    dgv.DataSource = listaFiltrada;
                }
            }
            else
            {
                // Usar ListBox como respaldo
                ListBox lb = this.Controls.Find("listBox1", true).FirstOrDefault() as ListBox;

                if (lb != null)
                {
                    lb.DataSource = null;

                    if (listaFiltrada.Count == 0 && !string.IsNullOrEmpty(terminoBusqueda))
                    {
                        lb.Items.Clear();
                        lb.Items.Add($"No se encontraron resultados para: '{terminoBusqueda}'");
                    }
                    else if (listaFiltrada.Count == 0)
                    {
                        lb.Items.Clear();
                        lb.Items.Add("No hay reportes disponibles");
                    }
                    else
                    {
                        lb.DataSource = listaFiltrada;
                    }
                }
            }
        }

        private void Seguimiento_Load(object sender, EventArgs e)
        {

        }

        private void Seguimiento_Load_1(object sender, EventArgs e)
        {

        }
    }
}
