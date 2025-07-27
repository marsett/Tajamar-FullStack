namespace AdoNetCore
{
    partial class Form09CrudHospitales
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
            btnEliminar = new Button();
            btnModificar = new Button();
            btnInsertar = new Button();
            txtDireccion = new TextBox();
            lblDireccion = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtHospitalCod = new TextBox();
            lblHospitalCod = new Label();
            lstHospitales = new ListBox();
            lblHospitales = new Label();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblNumCama = new Label();
            txtNumCama = new TextBox();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.ForeColor = Color.Red;
            btnEliminar.Location = new Point(442, 538);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(201, 58);
            btnEliminar.TabIndex = 21;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(233, 543);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(168, 53);
            btnModificar.TabIndex = 20;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(28, 546);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(173, 50);
            btnInsertar.TabIndex = 19;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(722, 287);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(273, 41);
            txtDireccion.TabIndex = 18;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(722, 236);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(120, 35);
            lblDireccion.TabIndex = 17;
            lblDireccion.Text = "Dirección";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(722, 170);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(273, 41);
            txtNombre.TabIndex = 16;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(722, 120);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(108, 35);
            lblNombre.TabIndex = 15;
            lblNombre.Text = "Nombre";
            // 
            // txtHospitalCod
            // 
            txtHospitalCod.Location = new Point(722, 65);
            txtHospitalCod.Name = "txtHospitalCod";
            txtHospitalCod.Size = new Size(125, 41);
            txtHospitalCod.TabIndex = 14;
            // 
            // lblHospitalCod
            // 
            lblHospitalCod.AutoSize = true;
            lblHospitalCod.Location = new Point(722, 9);
            lblHospitalCod.Name = "lblHospitalCod";
            lblHospitalCod.Size = new Size(165, 35);
            lblHospitalCod.TabIndex = 13;
            lblHospitalCod.Text = "Hospital COD";
            // 
            // lstHospitales
            // 
            lstHospitales.FormattingEnabled = true;
            lstHospitales.Location = new Point(28, 88);
            lstHospitales.Name = "lstHospitales";
            lstHospitales.Size = new Size(625, 424);
            lstHospitales.TabIndex = 12;
            // 
            // lblHospitales
            // 
            lblHospitales.AutoSize = true;
            lblHospitales.Location = new Point(28, 27);
            lblHospitales.Margin = new Padding(5, 0, 5, 0);
            lblHospitales.Name = "lblHospitales";
            lblHospitales.Size = new Size(131, 35);
            lblHospitales.TabIndex = 11;
            lblHospitales.Text = "Hospitales";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(722, 357);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(110, 35);
            lblTelefono.TabIndex = 22;
            lblTelefono.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(722, 408);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(273, 41);
            txtTelefono.TabIndex = 23;
            // 
            // lblNumCama
            // 
            lblNumCama.AutoSize = true;
            lblNumCama.Location = new Point(720, 477);
            lblNumCama.Name = "lblNumCama";
            lblNumCama.Size = new Size(143, 35);
            lblNumCama.TabIndex = 24;
            lblNumCama.Text = "Num_Cama";
            // 
            // txtNumCama
            // 
            txtNumCama.Location = new Point(720, 538);
            txtNumCama.Name = "txtNumCama";
            txtNumCama.Size = new Size(273, 41);
            txtNumCama.TabIndex = 25;
            // 
            // Form09CrudHospitales
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(txtNumCama);
            Controls.Add(lblNumCama);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnInsertar);
            Controls.Add(txtDireccion);
            Controls.Add(lblDireccion);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtHospitalCod);
            Controls.Add(lblHospitalCod);
            Controls.Add(lstHospitales);
            Controls.Add(lblHospitales);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form09CrudHospitales";
            Text = "Form09CrudHospitales";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button btnModificar;
        private Button btnInsertar;
        private TextBox txtDireccion;
        private Label lblDireccion;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtHospitalCod;
        private Label lblHospitalCod;
        private ListBox lstHospitales;
        private Label lblHospitales;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblNumCama;
        private TextBox txtNumCama;
    }
}