namespace FundamentosNetCore
{
    partial class Form25ColeccionMascotasJSON
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
            txtAnos = new TextBox();
            lblAnos = new Label();
            txtRaza = new TextBox();
            lblRaza = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            btnGuardarMascotas = new Button();
            btnLeerMascotas = new Button();
            btnNuevaMascota = new Button();
            lstMascotas = new ListBox();
            lblMascotas = new Label();
            SuspendLayout();
            // 
            // txtAnos
            // 
            txtAnos.Location = new Point(212, 183);
            txtAnos.Margin = new Padding(9);
            txtAnos.Name = "txtAnos";
            txtAnos.Size = new Size(200, 41);
            txtAnos.TabIndex = 25;
            // 
            // lblAnos
            // 
            lblAnos.AutoSize = true;
            lblAnos.Location = new Point(37, 183);
            lblAnos.Margin = new Padding(9, 0, 9, 0);
            lblAnos.Name = "lblAnos";
            lblAnos.Size = new Size(71, 35);
            lblAnos.TabIndex = 24;
            lblAnos.Text = "Años";
            // 
            // txtRaza
            // 
            txtRaza.Location = new Point(212, 108);
            txtRaza.Margin = new Padding(9);
            txtRaza.Name = "txtRaza";
            txtRaza.Size = new Size(200, 41);
            txtRaza.TabIndex = 23;
            // 
            // lblRaza
            // 
            lblRaza.AutoSize = true;
            lblRaza.Location = new Point(37, 108);
            lblRaza.Margin = new Padding(9, 0, 9, 0);
            lblRaza.Name = "lblRaza";
            lblRaza.Size = new Size(67, 35);
            lblRaza.TabIndex = 22;
            lblRaza.Text = "Raza";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(212, 38);
            txtNombre.Margin = new Padding(9);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 41);
            txtNombre.TabIndex = 21;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(37, 38);
            lblNombre.Margin = new Padding(16, 0, 16, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(108, 35);
            lblNombre.TabIndex = 20;
            lblNombre.Text = "Nombre";
            // 
            // btnGuardarMascotas
            // 
            btnGuardarMascotas.Location = new Point(37, 511);
            btnGuardarMascotas.Margin = new Padding(5);
            btnGuardarMascotas.Name = "btnGuardarMascotas";
            btnGuardarMascotas.Size = new Size(411, 82);
            btnGuardarMascotas.TabIndex = 28;
            btnGuardarMascotas.Text = "Guardar mascotas";
            btnGuardarMascotas.UseVisualStyleBackColor = true;
            btnGuardarMascotas.Click += btnGuardarMascotas_Click;
            // 
            // btnLeerMascotas
            // 
            btnLeerMascotas.Location = new Point(37, 382);
            btnLeerMascotas.Margin = new Padding(5);
            btnLeerMascotas.Name = "btnLeerMascotas";
            btnLeerMascotas.Size = new Size(411, 82);
            btnLeerMascotas.TabIndex = 27;
            btnLeerMascotas.Text = "Leer mascotas";
            btnLeerMascotas.UseVisualStyleBackColor = true;
            btnLeerMascotas.Click += btnLeerMascotas_Click;
            // 
            // btnNuevaMascota
            // 
            btnNuevaMascota.Location = new Point(37, 253);
            btnNuevaMascota.Margin = new Padding(5);
            btnNuevaMascota.Name = "btnNuevaMascota";
            btnNuevaMascota.Size = new Size(411, 82);
            btnNuevaMascota.TabIndex = 26;
            btnNuevaMascota.Text = "Nueva mascota";
            btnNuevaMascota.UseVisualStyleBackColor = true;
            btnNuevaMascota.Click += btnNuevaMascota_Click;
            // 
            // lstMascotas
            // 
            lstMascotas.FormattingEnabled = true;
            lstMascotas.Location = new Point(483, 108);
            lstMascotas.Margin = new Padding(5);
            lstMascotas.Name = "lstMascotas";
            lstMascotas.Size = new Size(457, 529);
            lstMascotas.TabIndex = 30;
            lstMascotas.SelectedIndexChanged += lstMascotas_SelectedIndexChanged;
            // 
            // lblMascotas
            // 
            lblMascotas.AutoSize = true;
            lblMascotas.Location = new Point(483, 35);
            lblMascotas.Margin = new Padding(5, 0, 5, 0);
            lblMascotas.Name = "lblMascotas";
            lblMascotas.Size = new Size(120, 35);
            lblMascotas.TabIndex = 29;
            lblMascotas.Text = "Mascotas";
            // 
            // Form25ColeccionMascotasJSON
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(lstMascotas);
            Controls.Add(lblMascotas);
            Controls.Add(btnGuardarMascotas);
            Controls.Add(btnLeerMascotas);
            Controls.Add(btnNuevaMascota);
            Controls.Add(txtAnos);
            Controls.Add(lblAnos);
            Controls.Add(txtRaza);
            Controls.Add(lblRaza);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form25ColeccionMascotasJSON";
            Text = "Form25ColeccionMascotasJSON";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAnos;
        private Label lblAnos;
        private TextBox txtRaza;
        private Label lblRaza;
        private TextBox txtNombre;
        private Label lblNombre;
        private Button btnGuardarMascotas;
        private Button btnLeerMascotas;
        private Button btnNuevaMascota;
        private ListBox lstMascotas;
        private Label lblMascotas;
    }
}