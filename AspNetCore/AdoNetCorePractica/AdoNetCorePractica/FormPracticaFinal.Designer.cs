namespace AdoNetCorePractica
{
    partial class FormPracticaFinal
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
            lblLocalidad = new Label();
            lblNombre = new Label();
            txtLocalidad = new TextBox();
            txtNombre = new TextBox();
            txtId = new TextBox();
            lblId = new Label();
            lstEmpleados = new ListBox();
            lblEmpleados = new Label();
            cmbDepartamentos = new ComboBox();
            lblDepartamentos = new Label();
            lblApellido = new Label();
            lblSalario = new Label();
            lblOficio = new Label();
            txtSalario = new TextBox();
            txtOficio = new TextBox();
            txtApellido = new TextBox();
            btnInsertarDepartamento = new Button();
            btnUpdateEmpleado = new Button();
            SuspendLayout();
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(41, 423);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(122, 35);
            lblLocalidad.TabIndex = 19;
            lblLocalidad.Text = "Localidad";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(41, 296);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(108, 35);
            lblNombre.TabIndex = 18;
            lblNombre.Text = "Nombre";
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(41, 486);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(201, 41);
            txtLocalidad.TabIndex = 17;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(41, 358);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(201, 41);
            txtNombre.TabIndex = 16;
            // 
            // txtId
            // 
            txtId.Location = new Point(41, 234);
            txtId.Name = "txtId";
            txtId.Size = new Size(201, 41);
            txtId.TabIndex = 15;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(41, 168);
            lblId.Name = "lblId";
            lblId.Size = new Size(37, 35);
            lblId.TabIndex = 14;
            lblId.Text = "Id";
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(323, 70);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(389, 424);
            lstEmpleados.TabIndex = 13;
            lstEmpleados.SelectedIndexChanged += lstEmpleados_SelectedIndexChanged;
            // 
            // lblEmpleados
            // 
            lblEmpleados.AutoSize = true;
            lblEmpleados.Location = new Point(323, 21);
            lblEmpleados.Name = "lblEmpleados";
            lblEmpleados.Size = new Size(138, 35);
            lblEmpleados.TabIndex = 12;
            lblEmpleados.Text = "Empleados";
            // 
            // cmbDepartamentos
            // 
            cmbDepartamentos.FormattingEnabled = true;
            cmbDepartamentos.Location = new Point(41, 80);
            cmbDepartamentos.Name = "cmbDepartamentos";
            cmbDepartamentos.Size = new Size(151, 43);
            cmbDepartamentos.TabIndex = 11;
            cmbDepartamentos.SelectedIndexChanged += cmbDepartamentos_SelectedIndexChanged;
            // 
            // lblDepartamentos
            // 
            lblDepartamentos.AutoSize = true;
            lblDepartamentos.Location = new Point(41, 21);
            lblDepartamentos.Name = "lblDepartamentos";
            lblDepartamentos.Size = new Size(187, 35);
            lblDepartamentos.TabIndex = 10;
            lblDepartamentos.Text = "Departamentos";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(760, 21);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(107, 35);
            lblApellido.TabIndex = 20;
            lblApellido.Text = "Apellido";
            // 
            // lblSalario
            // 
            lblSalario.AutoSize = true;
            lblSalario.Location = new Point(760, 269);
            lblSalario.Name = "lblSalario";
            lblSalario.Size = new Size(90, 35);
            lblSalario.TabIndex = 25;
            lblSalario.Text = "Salario";
            // 
            // lblOficio
            // 
            lblOficio.AutoSize = true;
            lblOficio.Location = new Point(760, 142);
            lblOficio.Name = "lblOficio";
            lblOficio.Size = new Size(81, 35);
            lblOficio.TabIndex = 24;
            lblOficio.Text = "Oficio";
            // 
            // txtSalario
            // 
            txtSalario.Location = new Point(760, 332);
            txtSalario.Name = "txtSalario";
            txtSalario.Size = new Size(201, 41);
            txtSalario.TabIndex = 23;
            // 
            // txtOficio
            // 
            txtOficio.Location = new Point(760, 204);
            txtOficio.Name = "txtOficio";
            txtOficio.Size = new Size(201, 41);
            txtOficio.TabIndex = 22;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(760, 80);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(201, 41);
            txtApellido.TabIndex = 21;
            // 
            // btnInsertarDepartamento
            // 
            btnInsertarDepartamento.Location = new Point(41, 566);
            btnInsertarDepartamento.Name = "btnInsertarDepartamento";
            btnInsertarDepartamento.Size = new Size(201, 80);
            btnInsertarDepartamento.TabIndex = 26;
            btnInsertarDepartamento.Text = "Insertar departamento";
            btnInsertarDepartamento.UseVisualStyleBackColor = true;
            btnInsertarDepartamento.Click += btnInsertarDepartamento_Click;
            // 
            // btnUpdateEmpleado
            // 
            btnUpdateEmpleado.Location = new Point(760, 423);
            btnUpdateEmpleado.Name = "btnUpdateEmpleado";
            btnUpdateEmpleado.Size = new Size(201, 71);
            btnUpdateEmpleado.TabIndex = 27;
            btnUpdateEmpleado.Text = "Update";
            btnUpdateEmpleado.UseVisualStyleBackColor = true;
            btnUpdateEmpleado.Click += btnUpdateEmpleado_Click;
            // 
            // FormPracticaFinal
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(btnUpdateEmpleado);
            Controls.Add(btnInsertarDepartamento);
            Controls.Add(lblSalario);
            Controls.Add(lblOficio);
            Controls.Add(txtSalario);
            Controls.Add(txtOficio);
            Controls.Add(txtApellido);
            Controls.Add(lblApellido);
            Controls.Add(lblLocalidad);
            Controls.Add(lblNombre);
            Controls.Add(txtLocalidad);
            Controls.Add(txtNombre);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Controls.Add(lstEmpleados);
            Controls.Add(lblEmpleados);
            Controls.Add(cmbDepartamentos);
            Controls.Add(lblDepartamentos);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "FormPracticaFinal";
            Text = "FormPracticaFinal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLocalidad;
        private Label lblNombre;
        private TextBox txtLocalidad;
        private TextBox txtNombre;
        private TextBox txtId;
        private Label lblId;
        private ListBox lstEmpleados;
        private Label lblEmpleados;
        private ComboBox cmbDepartamentos;
        private Label lblDepartamentos;
        private Label lblApellido;
        private Label lblSalario;
        private Label lblOficio;
        private TextBox txtSalario;
        private TextBox txtOficio;
        private TextBox txtApellido;
        private Button btnInsertarDepartamento;
        private Button btnUpdateEmpleado;
    }
}