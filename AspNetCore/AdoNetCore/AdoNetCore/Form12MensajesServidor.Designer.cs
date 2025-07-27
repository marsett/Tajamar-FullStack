namespace AdoNetCore
{
    partial class Form12MensajesServidor
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
            lblNumero = new Label();
            txtNumero = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            txtLocalidad = new TextBox();
            lblLocalidad = new Label();
            btnInsertar = new Button();
            lblMensaje = new Label();
            lblDepartamentos = new Label();
            lstDepartamentos = new ListBox();
            SuspendLayout();
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(61, 23);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(107, 35);
            lblNumero.TabIndex = 0;
            lblNumero.Text = "Número";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(61, 72);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(125, 41);
            txtNumero.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(61, 131);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(108, 35);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(61, 183);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(194, 41);
            txtNombre.TabIndex = 3;
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(61, 312);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(194, 41);
            txtLocalidad.TabIndex = 5;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(61, 248);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(122, 35);
            lblLocalidad.TabIndex = 4;
            lblLocalidad.Text = "Localidad";
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(61, 390);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(194, 65);
            btnInsertar.TabIndex = 6;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.ForeColor = Color.FromArgb(0, 0, 192);
            lblMensaje.Location = new Point(61, 486);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(134, 35);
            lblMensaje.TabIndex = 7;
            lblMensaje.Text = "lblMensaje";
            // 
            // lblDepartamentos
            // 
            lblDepartamentos.AutoSize = true;
            lblDepartamentos.Location = new Point(435, 23);
            lblDepartamentos.Name = "lblDepartamentos";
            lblDepartamentos.Size = new Size(187, 35);
            lblDepartamentos.TabIndex = 8;
            lblDepartamentos.Text = "Departamentos";
            // 
            // lstDepartamentos
            // 
            lstDepartamentos.FormattingEnabled = true;
            lstDepartamentos.Location = new Point(435, 93);
            lstDepartamentos.Name = "lstDepartamentos";
            lstDepartamentos.Size = new Size(441, 284);
            lstDepartamentos.TabIndex = 9;
            // 
            // Form12MensajesServidor
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(lstDepartamentos);
            Controls.Add(lblDepartamentos);
            Controls.Add(lblMensaje);
            Controls.Add(btnInsertar);
            Controls.Add(txtLocalidad);
            Controls.Add(lblLocalidad);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtNumero);
            Controls.Add(lblNumero);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form12MensajesServidor";
            Text = "Form12MensajesServidor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumero;
        private TextBox txtNumero;
        private Label lblNombre;
        private TextBox txtNombre;
        private TextBox txtLocalidad;
        private Label lblLocalidad;
        private Button btnInsertar;
        private Label lblMensaje;
        private Label lblDepartamentos;
        private ListBox lstDepartamentos;
    }
}