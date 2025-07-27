namespace AdoNetCore
{
    partial class Form08CrudDepartamentos
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
            lblDepartamentos = new Label();
            lstDepartamentos = new ListBox();
            lblId = new Label();
            txtId = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblLocalidad = new Label();
            txtLocalidad = new TextBox();
            btnInsertar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            SuspendLayout();
            // 
            // lblDepartamentos
            // 
            lblDepartamentos.AutoSize = true;
            lblDepartamentos.Location = new Point(67, 37);
            lblDepartamentos.Margin = new Padding(5, 0, 5, 0);
            lblDepartamentos.Name = "lblDepartamentos";
            lblDepartamentos.Size = new Size(187, 35);
            lblDepartamentos.TabIndex = 0;
            lblDepartamentos.Text = "Departamentos";
            // 
            // lstDepartamentos
            // 
            lstDepartamentos.FormattingEnabled = true;
            lstDepartamentos.Location = new Point(67, 98);
            lstDepartamentos.Name = "lstDepartamentos";
            lstDepartamentos.Size = new Size(472, 354);
            lstDepartamentos.TabIndex = 1;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(626, 22);
            lblId.Name = "lblId";
            lblId.Size = new Size(37, 35);
            lblId.TabIndex = 2;
            lblId.Text = "Id";
            // 
            // txtId
            // 
            txtId.Location = new Point(626, 75);
            txtId.Name = "txtId";
            txtId.Size = new Size(125, 41);
            txtId.TabIndex = 3;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(626, 135);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(108, 35);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(626, 186);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(273, 41);
            txtNombre.TabIndex = 5;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(626, 243);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(122, 35);
            lblLocalidad.TabIndex = 6;
            lblLocalidad.Text = "Localidad";
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(626, 300);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(273, 41);
            txtLocalidad.TabIndex = 7;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(626, 363);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(273, 50);
            btnInsertar.TabIndex = 8;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(626, 435);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(273, 56);
            btnModificar.TabIndex = 9;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.ForeColor = Color.Red;
            btnEliminar.Location = new Point(626, 520);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(273, 58);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Form08CrudDepartamentos
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnInsertar);
            Controls.Add(txtLocalidad);
            Controls.Add(lblLocalidad);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Controls.Add(lstDepartamentos);
            Controls.Add(lblDepartamentos);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form08CrudDepartamentos";
            Text = "Form08CrudDepartamentos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDepartamentos;
        private ListBox lstDepartamentos;
        private Label lblId;
        private TextBox txtId;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblLocalidad;
        private TextBox txtLocalidad;
        private Button btnInsertar;
        private Button btnModificar;
        private Button btnEliminar;
    }
}