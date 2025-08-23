using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        DataTable dt;

        int filaSeleccionada = 0;
        double LatInicial = 27.486388888889;
        double LongInicial = -109.94083333333;

        public GoogleMaps()
        {
            InitializeComponent();
        }

        private void GoogleMaps_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dt.Columns.Add(new DataColumn("Lat", typeof(double)));
            dt.Columns.Add(new DataColumn("Long", typeof(double)));

            //insertar datos l dt para mostrar en la lista
            dt.Rows.Add("ubicacion 1", LatInicial, LongInicial);
            dataGridView1.DataSource = dt;

            //desactivar las columnas de lat y long.
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;


            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LongInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;

            //Marcador

            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(LatInicial, LongInicial), GMarkerGoogleType.green);
            markerOverlay.Markers.Add(marker); //agregamos al mapa

            //agregamos un tooltip de texto a los marcadores.
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("ubicacion: \n Latitud:{0} \n Longitud:{1}", LatInicial, LongInicial);

            //ahora agregamos el mapa y el marcador al map control
            gMapControl1.Overlays.Add(markerOverlay);
        }

        private void SeleccionarRegistro(object sender, DataGridViewCellMouseEventArgs e)
        {
            filaSeleccionada = e.RowIndex;//fila seleccionada
            //recuperamos los datos del grid y los asignsmod a los textbox
            txtDescripcion.Text = dataGridView1.Rows[filaSeleccionada].Cells[0].Value.ToString();
            txtLatitud.Text = dataGridView1.Rows[filaSeleccionada].Cells[1].Value.ToString();
            txtLongitud.Text = dataGridView1.Rows[filaSeleccionada].Cells[2].Value.ToString();

            //se asignan los valores del grid al marcador
            marker.Position = new PointLatLng(Convert.ToDouble(txtLatitud.Text), Convert.ToDouble(txtLongitud.Text));
            //se posiciona el foco del mapa en ese punto
            gMapControl1.Position = marker.Position;

        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //se obtiene los dto de Latitud y Longitud del mapa donde el usuario preciono 
            double lat= gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

            //se posiscionan en el txt de la latitud y la longitud
            txtLatitud.Text = lat.ToString();
            txtLongitud.Text= lng.ToString();

            //creamos el marcador para moverlo al lugar indicado 
            marker.Position = new PointLatLng(lat, lng);

            //tambien se agrega el mensaje al marcador (tooltip)
            marker.ToolTipText = string.Format("ubicacion: \n Latitud:{0} \n Longitud:{1}", LatInicial, LongInicial);
            

        }

        //agregar ala tabla
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dt.Rows.Add(txtDescripcion.Text,txtLatitud.Text,txtLongitud.Text);
            //procedimiento para agregar de una bade de datos
        }

        //eliminar de la tabla
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(filaSeleccionada);
            //procedimiento para eliminar de una bade de datos
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MnPrincipal mnPrincipal = new MnPrincipal();
            mnPrincipal.Show();
        }
    }
}
