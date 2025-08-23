using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Applogin
{
    public partial class GoogleMaps : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        List<Ubicacion> ubicaciones = new List<Ubicacion>();
        int filaSeleccionada = 0;
        double LatInicial = 27.486388888889;
        double LongInicial = -109.94083333333;

        string connectionString = @"Server=SKU100131817;Database=pruebaConexion;Trusted_Connection=true";

        public GoogleMaps()
        {
            InitializeComponent();
        }

        private void GoogleMaps_Load(object sender, EventArgs e)
        {
            CargarUbicaciones();

            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LongInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;

            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(LatInicial, LongInicial), GMarkerGoogleType.green);
            markerOverlay.Markers.Add(marker);
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = $"ubicacion:\nLatitud:{LatInicial}\nLongitud:{LongInicial}";
            gMapControl1.Overlays.Add(markerOverlay);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                filaSeleccionada = listBox1.SelectedIndex;
                Ubicacion ub = ubicaciones[filaSeleccionada];

                txtDescripcion.Text = ub.Descripcion;
                txtLatitud.Text = ub.Lat.ToString(CultureInfo.InvariantCulture);
                txtLongitud.Text = ub.Long.ToString(CultureInfo.InvariantCulture);

                // Limpiar marcadores anteriores
                markerOverlay.Markers.Clear();

                // Crear nuevo marcador en la ubicación seleccionada
                marker = new GMarkerGoogle(new PointLatLng(ub.Lat, ub.Long), GMarkerGoogleType.blue);
                marker.ToolTipMode = MarkerTooltipMode.Always;
                marker.ToolTipText = $"ubicacion:\nLatitud:{ub.Lat:F5}\nLongitud:{ub.Long:F5}";
                markerOverlay.Markers.Add(marker);

                // Centrar el mapa en el nuevo marcador
                gMapControl1.Position = marker.Position;
            }
        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Obtener coordenadas del clic
            double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

            // Actualizar campos de texto
            txtLatitud.Text = lat.ToString(CultureInfo.InvariantCulture);
            txtLongitud.Text = lng.ToString(CultureInfo.InvariantCulture);

            // Generar descripción automática
            txtDescripcion.Text = $"Ubicación seleccionada ({lat:F5}, {lng:F5})";

            // Actualizar marcador
            markerOverlay.Markers.Clear();
            marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red);
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = $"ubicacion:\nLatitud:{lat:F5}\nLongitud:{lng:F5}";
            markerOverlay.Markers.Add(marker);
            gMapControl1.Position = marker.Position;

            // Insertar en base de datos
            Ubicacion nueva = new Ubicacion
            {
                Descripcion = txtDescripcion.Text,
                Lat = lat,
                Long = lng
            };

            InsertarUbicacion(nueva);
            CargarUbicaciones();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtLatitud.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double lat) ||
                !double.TryParse(txtLongitud.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double lng))
            {
                MessageBox.Show("Latitud o longitud inválida. Verifica el formato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Ubicacion nueva = new Ubicacion
            {
                Descripcion = txtDescripcion.Text,
                Lat = lat,
                Long = lng
            };

            InsertarUbicacion(nueva);
            CargarUbicaciones();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indexSeleccionado = listBox1.SelectedIndex;

            if (indexSeleccionado >= 0 && indexSeleccionado < ubicaciones.Count)
            {
                int id = ubicaciones[indexSeleccionado].Id;
                EliminarUbicacion(id);
                CargarUbicaciones();
            }
            else
            {
                MessageBox.Show("Selecciona una ubicación para eliminar.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada >= 0 && filaSeleccionada < ubicaciones.Count)
            {
                if (!double.TryParse(txtLatitud.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double lat) ||
                    !double.TryParse(txtLongitud.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double lng))
                {
                    MessageBox.Show("Latitud o longitud inválida. Verifica el formato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Ubicacion ubicacionEditada = new Ubicacion
                {
                    Id = ubicaciones[filaSeleccionada].Id,
                    Descripcion = txtDescripcion.Text,
                    Lat = lat,
                    Long = lng
                };

                ActualizarUbicacion(ubicacionEditada);
                CargarUbicaciones();

                // Actualizar el marcador en la nueva posición
                marker.Position = new PointLatLng(lat, lng);
                marker.ToolTipText = $"ubicacion:\nLatitud:{lat}\nLongitud:{lng}";
                gMapControl1.Position = marker.Position;
            }
            else
            {
                MessageBox.Show("Selecciona una ubicación para editar.", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MnPrincipal mnPrincipal = new MnPrincipal();
            mnPrincipal.Show();
        }

        // CRUD SQL

        private void InsertarUbicacion(Ubicacion ubicacion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Ins_Ubicacion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", ubicacion.Descripcion);
                cmd.Parameters.AddWithValue("@Latitud", ubicacion.Lat);
                cmd.Parameters.AddWithValue("@Longitud", ubicacion.Long);
                cmd.Parameters.AddWithValue("@FechaRegistro", DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void ActualizarUbicacion(Ubicacion ubicacion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Upd_Ubicacion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", ubicacion.Id);
                cmd.Parameters.AddWithValue("@Descripcion", ubicacion.Descripcion);
                cmd.Parameters.AddWithValue("@Latitud", ubicacion.Lat);
                cmd.Parameters.AddWithValue("@Longitud", ubicacion.Long);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void EliminarUbicacion(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Del_Ubicacion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void CargarUbicaciones()
        {
            ubicaciones.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Ver_Ubicaciones", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                cmd.Parameters.AddWithValue("@BuscarDescripcion", DBNull.Value);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (double.TryParse(reader["Latitud"].ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double lat) &&
                        double.TryParse(reader["Longitud"].ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double lng))
                    {
                        ubicaciones.Add(new Ubicacion
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            Lat = lat,
                            Long = lng
                        });
                    }
                }
            }

            listBox1.DataSource = null;
            listBox1.DataSource = ubicaciones;
        }
    }

    public class Ubicacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
