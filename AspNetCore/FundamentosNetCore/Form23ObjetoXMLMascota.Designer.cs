namespace FundamentosNetCore
{
    partial class Form23ObjetoXMLMascota
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
            txtNombre = new TextBox();
            txtRaza = new TextBox();
            txtEdad = new TextBox();
            lblNombre = new Label();
            lblRaza = new Label();
            lblEdad = new Label();
            btnLeerDatos = new Button();
            btnGuardarDatos = new Button();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(99, 95);
            txtNombre.Margin = new Padding(5);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(216, 41);
            txtNombre.TabIndex = 0;
            // 
            // txtRaza
            // 
            txtRaza.Location = new Point(99, 224);
            txtRaza.Name = "txtRaza";
            txtRaza.Size = new Size(216, 41);
            txtRaza.TabIndex = 1;
            // 
            // txtEdad
            // 
            txtEdad.Location = new Point(99, 367);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(211, 41);
            txtEdad.TabIndex = 2;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(99, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(108, 35);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre";
            // 
            // lblRaza
            // 
            lblRaza.AutoSize = true;
            lblRaza.Location = new Point(99, 159);
            lblRaza.Name = "lblRaza";
            lblRaza.Size = new Size(67, 35);
            lblRaza.TabIndex = 4;
            lblRaza.Text = "Raza";
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Location = new Point(99, 300);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(71, 35);
            lblEdad.TabIndex = 5;
            lblEdad.Text = "Edad";
            // 
            // btnLeerDatos
            // 
            btnLeerDatos.Location = new Point(550, 121);
            btnLeerDatos.Name = "btnLeerDatos";
            btnLeerDatos.Size = new Size(197, 73);
            btnLeerDatos.TabIndex = 6;
            btnLeerDatos.Text = "Leer datos";
            btnLeerDatos.UseVisualStyleBackColor = true;
            btnLeerDatos.Click += btnLeerDatos_Click;
            // 
            // btnGuardarDatos
            // 
            btnGuardarDatos.Location = new Point(550, 241);
            btnGuardarDatos.Name = "btnGuardarDatos";
            btnGuardarDatos.Size = new Size(197, 73);
            btnGuardarDatos.TabIndex = 7;
            btnGuardarDatos.Text = "Guardar datos";
            btnGuardarDatos.UseVisualStyleBackColor = true;
            btnGuardarDatos.Click += btnGuardarDatos_Click;
            // 
            // Form23ObjetoXMLMascota
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(btnGuardarDatos);
            Controls.Add(btnLeerDatos);
            Controls.Add(lblEdad);
            Controls.Add(lblRaza);
            Controls.Add(lblNombre);
            Controls.Add(txtEdad);
            Controls.Add(txtRaza);
            Controls.Add(txtNombre);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form23ObjetoXMLMascota";
            Text = "Form23ObjetoXMLMascota";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtRaza;
        private TextBox txtEdad;
        private Label lblNombre;
        private Label lblRaza;
        private Label lblEdad;
        private Button btnLeerDatos;
        private Button btnGuardarDatos;
    }
}