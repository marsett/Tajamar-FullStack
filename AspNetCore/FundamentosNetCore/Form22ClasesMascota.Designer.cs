namespace FundamentosNetCore
{
    partial class Form22ClasesMascota
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblRaza = new Label();
            txtRaza = new TextBox();
            btnNuevaMascota = new Button();
            btnLeerMascotas = new Button();
            btnGuardarMascotas = new Button();
            lblMascotas = new Label();
            lstMascotas = new ListBox();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(74, 58);
            lblNombre.Margin = new Padding(5, 0, 5, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(108, 35);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(74, 117);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 41);
            txtNombre.TabIndex = 1;
            // 
            // lblRaza
            // 
            lblRaza.AutoSize = true;
            lblRaza.Location = new Point(74, 187);
            lblRaza.Name = "lblRaza";
            lblRaza.Size = new Size(67, 35);
            lblRaza.TabIndex = 2;
            lblRaza.Text = "Raza";
            // 
            // txtRaza
            // 
            txtRaza.Location = new Point(74, 247);
            txtRaza.Name = "txtRaza";
            txtRaza.Size = new Size(125, 41);
            txtRaza.TabIndex = 3;
            // 
            // btnNuevaMascota
            // 
            btnNuevaMascota.Location = new Point(74, 327);
            btnNuevaMascota.Name = "btnNuevaMascota";
            btnNuevaMascota.Size = new Size(235, 47);
            btnNuevaMascota.TabIndex = 4;
            btnNuevaMascota.Text = "Nueva mascota";
            btnNuevaMascota.UseVisualStyleBackColor = true;
            btnNuevaMascota.Click += btnNuevaMascota_Click;
            // 
            // btnLeerMascotas
            // 
            btnLeerMascotas.Location = new Point(74, 392);
            btnLeerMascotas.Name = "btnLeerMascotas";
            btnLeerMascotas.Size = new Size(235, 47);
            btnLeerMascotas.TabIndex = 5;
            btnLeerMascotas.Text = "Leer mascotas";
            btnLeerMascotas.UseVisualStyleBackColor = true;
            btnLeerMascotas.Click += btnLeerMascotas_Click;
            // 
            // btnGuardarMascotas
            // 
            btnGuardarMascotas.Location = new Point(74, 455);
            btnGuardarMascotas.Name = "btnGuardarMascotas";
            btnGuardarMascotas.Size = new Size(235, 47);
            btnGuardarMascotas.TabIndex = 6;
            btnGuardarMascotas.Text = "Guardar mascotas";
            btnGuardarMascotas.UseVisualStyleBackColor = true;
            btnGuardarMascotas.Click += btnGuardarMascotas_Click;
            // 
            // lblMascotas
            // 
            lblMascotas.AutoSize = true;
            lblMascotas.Location = new Point(392, 58);
            lblMascotas.Name = "lblMascotas";
            lblMascotas.Size = new Size(120, 35);
            lblMascotas.TabIndex = 7;
            lblMascotas.Text = "Mascotas";
            // 
            // lstMascotas
            // 
            lstMascotas.FormattingEnabled = true;
            lstMascotas.Location = new Point(392, 117);
            lstMascotas.Name = "lstMascotas";
            lstMascotas.Size = new Size(263, 319);
            lstMascotas.TabIndex = 8;
            lstMascotas.SelectedIndexChanged += lstMascotas_SelectedIndexChanged;
            // 
            // Form22ClasesMascota
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
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
            Name = "Form22ClasesMascota";
            Text = "Form22ClasesMascota";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblRaza;
        private TextBox txtRaza;
        private Button btnNuevaMascota;
        private Button btnLeerMascotas;
        private Button btnGuardarMascotas;
        private Label lblMascotas;
        private ListBox lstMascotas;
    }
}