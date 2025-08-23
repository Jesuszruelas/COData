using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Applogin;

public static class GestorReportes
{
    public static void AgregarNuevoReporte()
    {
        var (descripcion, prioridad) = PedirDatosReporte("Agregar Reporte");

        if (!string.IsNullOrEmpty(descripcion))
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Conexion.strConexion))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Ins_Reporte", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@Prioridad", prioridad);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Reporte agregado: '{descripcion}'", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private static (string descripcion, string prioridad) PedirDatosReporte(string titulo)
    {
        Form ventana = new Form();
        ventana.Text = titulo;
        ventana.Size = new Size(400, 200);
        ventana.StartPosition = FormStartPosition.CenterParent;
        ventana.FormBorderStyle = FormBorderStyle.FixedDialog;
        ventana.MaximizeBox = false;
        ventana.MinimizeBox = false;

        Label lblDescripcion = new Label();
        lblDescripcion.Text = "Descripción:";
        lblDescripcion.Location = new Point(10, 10);
        lblDescripcion.Size = new Size(80, 20);

        TextBox txtDescripcion = new TextBox();
        txtDescripcion.Location = new Point(10, 35);
        txtDescripcion.Size = new Size(350, 20);

        Label lblPrioridad = new Label();
        lblPrioridad.Text = "Prioridad:";
        lblPrioridad.Location = new Point(10, 70);
        lblPrioridad.Size = new Size(80, 20);

        ComboBox cmbPrioridad = new ComboBox();
        cmbPrioridad.Items.AddRange(new string[] { "Crítica", "Alta", "Media", "Baja" });
        cmbPrioridad.SelectedIndex = 2; // Media por defecto
        cmbPrioridad.Location = new Point(10, 95);
        cmbPrioridad.Size = new Size(120, 20);
        cmbPrioridad.DropDownStyle = ComboBoxStyle.DropDownList;

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
}
