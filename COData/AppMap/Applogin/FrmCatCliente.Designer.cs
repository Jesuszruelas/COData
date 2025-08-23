namespace Applogin
{
    partial class FrmCatCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCatCliente));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.BtnGuarda = new System.Windows.Forms.ToolStripButton();
            this.BtnEliminar = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CtEmail = new System.Windows.Forms.TextBox();
            this.CtEdad = new System.Windows.Forms.TextBox();
            this.CtNombre = new System.Windows.Forms.TextBox();
            this.CtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.Cli_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cli_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNuevo,
            this.BtnGuarda,
            this.BtnEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(554, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.ForeColor = System.Drawing.Color.Black;
            this.BtnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("BtnNuevo.Image")));
            this.BtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(76, 24);
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnGuarda
            // 
            this.BtnGuarda.ForeColor = System.Drawing.Color.Black;
            this.BtnGuarda.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuarda.Image")));
            this.BtnGuarda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnGuarda.Name = "BtnGuarda";
            this.BtnGuarda.Size = new System.Drawing.Size(86, 24);
            this.BtnGuarda.Text = "Guardar";
            this.BtnGuarda.Click += new System.EventHandler(this.BtnGuarda_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.ForeColor = System.Drawing.Color.Black;
            this.BtnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("BtnEliminar.Image")));
            this.BtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(87, 24);
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CtEmail);
            this.panel1.Controls.Add(this.CtEdad);
            this.panel1.Controls.Add(this.CtNombre);
            this.panel1.Controls.Add(this.CtId);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(17, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 161);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CtEmail
            // 
            this.CtEmail.Location = new System.Drawing.Point(119, 112);
            this.CtEmail.Name = "CtEmail";
            this.CtEmail.Size = new System.Drawing.Size(264, 22);
            this.CtEmail.TabIndex = 7;
            // 
            // CtEdad
            // 
            this.CtEdad.Location = new System.Drawing.Point(119, 83);
            this.CtEdad.Name = "CtEdad";
            this.CtEdad.Size = new System.Drawing.Size(75, 22);
            this.CtEdad.TabIndex = 6;
            this.CtEdad.Leave += new System.EventHandler(this.CtEdad_Leave);
            // 
            // CtNombre
            // 
            this.CtNombre.Location = new System.Drawing.Point(119, 52);
            this.CtNombre.Name = "CtNombre";
            this.CtNombre.Size = new System.Drawing.Size(264, 22);
            this.CtNombre.TabIndex = 5;
            // 
            // CtId
            // 
            this.CtId.Location = new System.Drawing.Point(119, 19);
            this.CtId.Name = "CtId";
            this.CtId.Size = new System.Drawing.Size(135, 22);
            this.CtId.TabIndex = 4;
            this.CtId.Leave += new System.EventHandler(this.CtId_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Edad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Location = new System.Drawing.Point(17, 411);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(516, 74);
            this.panel2.TabIndex = 2;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Location = new System.Drawing.Point(408, 15);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(78, 40);
            this.BtnSalir.TabIndex = 0;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cli_id,
            this.Cli_Nombre,
            this.Cli_Edad,
            this.Cli_Email});
            this.grid.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.grid.Location = new System.Drawing.Point(17, 244);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 51;
            this.grid.RowTemplate.Height = 24;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(516, 150);
            this.grid.TabIndex = 3;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            // 
            // Cli_id
            // 
            this.Cli_id.DataPropertyName = "Cli_id";
            this.Cli_id.HeaderText = "ID";
            this.Cli_id.MinimumWidth = 6;
            this.Cli_id.Name = "Cli_id";
            this.Cli_id.ReadOnly = true;
            this.Cli_id.Width = 50;
            // 
            // Cli_Nombre
            // 
            this.Cli_Nombre.DataPropertyName = "Cli_Nombre";
            this.Cli_Nombre.HeaderText = "Nombre";
            this.Cli_Nombre.MinimumWidth = 6;
            this.Cli_Nombre.Name = "Cli_Nombre";
            this.Cli_Nombre.ReadOnly = true;
            this.Cli_Nombre.Width = 150;
            // 
            // Cli_Edad
            // 
            this.Cli_Edad.DataPropertyName = "Cli_Edad";
            this.Cli_Edad.HeaderText = "Edad";
            this.Cli_Edad.MinimumWidth = 6;
            this.Cli_Edad.Name = "Cli_Edad";
            this.Cli_Edad.ReadOnly = true;
            this.Cli_Edad.Width = 50;
            // 
            // Cli_Email
            // 
            this.Cli_Email.DataPropertyName = "Cli_Email";
            this.Cli_Email.HeaderText = "Email";
            this.Cli_Email.MinimumWidth = 6;
            this.Cli_Email.Name = "Cli_Email";
            this.Cli_Email.ReadOnly = true;
            this.Cli_Email.Width = 200;
            // 
            // FrmCatCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(554, 515);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCatCliente";
            this.Text = "Catalago de clientes";
            this.Load += new System.EventHandler(this.FrmCatCliente_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnNuevo;
        private System.Windows.Forms.ToolStripButton BtnGuarda;
        private System.Windows.Forms.ToolStripButton BtnEliminar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CtEmail;
        private System.Windows.Forms.TextBox CtEdad;
        private System.Windows.Forms.TextBox CtNombre;
        private System.Windows.Forms.TextBox CtId;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cli_Email;
    }
}