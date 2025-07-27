namespace FundamentosNetCore
{
    partial class Form24ColeccionXMLMascotas
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
            lstMascotas = new ListBox();
            lblMascotas = new Label();
            btnGuardarMascotas = new Button();
            btnLeerMascotas = new Button();
            btnNuevaMascota = new Button();
            txtRaza = new TextBox();
            lblRaza = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            lblAnos = new Label();
            txtAnos = new TextBox();
            SuspendLayout();
            // 
            // lstMascotas
            // 
            lstMascotas.FormattingEnabled = true;
            lstMascotas.Location = new Point(580, 96);
            lstMascotas.Margin = new Padding(5);
            lstMascotas.Name = "lstMascotas";
            lstMascotas.Size = new Size(457, 529);
            lstMascotas.TabIndex = 17;
            lstMascotas.SelectedIndexChanged += lstMascotas_SelectedIndexChanged;
            // 
            // lblMascotas
            // 
            lblMascotas.AutoSize = true;
            lblMascotas.Location = new Point(580, 23);
            lblMascotas.Margin = new Padding(5, 0, 5, 0);
            lblMascotas.Name = "lblMascotas";
            lblMascotas.Size = new Size(120, 35);
            lblMascotas.TabIndex = 16;
            lblMascotas.Text = "Mascotas";
            // 
            // btnGuardarMascotas
            // 
            btnGuardarMascotas.Location = new Point(103, 543);
            btnGuardarMascotas.Margin = new Padding(5);
            btnGuardarMascotas.Name = "btnGuardarMascotas";
            btnGuardarMascotas.Size = new Size(411, 82);
            btnGuardarMascotas.TabIndex = 15;
            btnGuardarMascotas.Text = "Guardar mascotas";
            btnGuardarMascotas.UseVisualStyleBackColor = true;
            btnGuardarMascotas.Click += btnGuardarMascotas_Click;
            // 
            // btnLeerMascotas
            // 
            btnLeerMascotas.Location = new Point(103, 414);
            btnLeerMascotas.Margin = new Padding(5);
            btnLeerMascotas.Name = "btnLeerMascotas";
            btnLeerMascotas.Size = new Size(411, 82);
            btnLeerMascotas.TabIndex = 14;
            btnLeerMascotas.Text = "Leer mascotas";
            btnLeerMascotas.UseVisualStyleBackColor = true;
            btnLeerMascotas.Click += btnLeerMascotas_Click;
            // 
            // btnNuevaMascota
            // 
            btnNuevaMascota.Location = new Point(103, 285);
            btnNuevaMascota.Margin = new Padding(5);
            btnNuevaMascota.Name = "btnNuevaMascota";
            btnNuevaMascota.Size = new Size(411, 82);
            btnNuevaMascota.TabIndex = 13;
            btnNuevaMascota.Text = "Nueva mascota";
            btnNuevaMascota.UseVisualStyleBackColor = true;
            btnNuevaMascota.Click += btnNuevaMascota_Click;
            // 
            // txtRaza
            // 
            txtRaza.Location = new Point(239, 118);
            txtRaza.Margin = new Padding(5);
            txtRaza.Name = "txtRaza";
            txtRaza.Size = new Size(216, 41);
            txtRaza.TabIndex = 12;
            // 
            // lblRaza
            // 
            lblRaza.AutoSize = true;
            lblRaza.Location = new Point(103, 108);
            lblRaza.Margin = new Padding(5, 0, 5, 0);
            lblRaza.Name = "lblRaza";
            lblRaza.Size = new Size(67, 35);
            lblRaza.TabIndex = 11;
            lblRaza.Text = "Raza";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(239, 34);
            txtNombre.Margin = new Padding(5);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(216, 41);
            txtNombre.TabIndex = 10;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(103, 34);
            lblNombre.Margin = new Padding(9, 0, 9, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(108, 35);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Nombre";
            // 
            // lblAnos
            // 
            lblAnos.AutoSize = true;
            lblAnos.Location = new Point(103, 204);
            lblAnos.Margin = new Padding(5, 0, 5, 0);
            lblAnos.Name = "lblAnos";
            lblAnos.Size = new Size(71, 35);
            lblAnos.TabIndex = 18;
            lblAnos.Text = "Años";
            // 
            // txtAnos
            // 
            txtAnos.Location = new Point(239, 198);
            txtAnos.Margin = new Padding(5);
            txtAnos.Name = "txtAnos";
            txtAnos.Size = new Size(216, 41);
            txtAnos.TabIndex = 19;
            // 
            // Form24ColeccionXMLMascotas
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(txtAnos);
            Controls.Add(lblAnos);
            Controls.Add(lstMascotas);
            Controls.Add(lblMascotas);
            Controls.Add(btnGuardarMascotas);
            Controls.Add(btnLeerMascotas);
            Controls.Add(btnNuevaMascota);
            Controls.Add(txtRaza);
            Controls.Add(lblRaza);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form24ColeccionXMLMascotas";
            Text = "Form24ColeccionXMLMascotas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstMascotas;
        private Label lblMascotas;
        private Button btnGuardarMascotas;
        private Button btnLeerMascotas;
        private Button btnNuevaMascota;
        private TextBox txtRaza;
        private Label lblRaza;
        private TextBox txtNombre;
        private Label lblNombre;
        private Label lblAnos;
        private TextBox txtAnos;
    }
}