namespace FundamentosNetCore
{
    partial class Form05Char
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
            lblNumeros = new Label();
            lblLetras = new Label();
            lblPuntuacion = new Label();
            lblSimbolos = new Label();
            txtNumeros = new TextBox();
            txtLetras = new TextBox();
            txtPuntuacion = new TextBox();
            txtSimbolos = new TextBox();
            btnRun = new Button();
            SuspendLayout();
            // 
            // lblNumeros
            // 
            lblNumeros.AutoSize = true;
            lblNumeros.Font = new Font("Segoe UI", 15F);
            lblNumeros.Location = new Point(35, 33);
            lblNumeros.Name = "lblNumeros";
            lblNumeros.Size = new Size(118, 35);
            lblNumeros.TabIndex = 0;
            lblNumeros.Text = "Números";
            // 
            // lblLetras
            // 
            lblLetras.AutoSize = true;
            lblLetras.Font = new Font("Segoe UI", 15F);
            lblLetras.Location = new Point(488, 33);
            lblLetras.Name = "lblLetras";
            lblLetras.Size = new Size(81, 35);
            lblLetras.TabIndex = 1;
            lblLetras.Text = "Letras";
            // 
            // lblPuntuacion
            // 
            lblPuntuacion.AutoSize = true;
            lblPuntuacion.Font = new Font("Segoe UI", 15F);
            lblPuntuacion.Location = new Point(35, 226);
            lblPuntuacion.Name = "lblPuntuacion";
            lblPuntuacion.Size = new Size(139, 35);
            lblPuntuacion.TabIndex = 2;
            lblPuntuacion.Text = "Puntuación";
            // 
            // lblSimbolos
            // 
            lblSimbolos.AutoSize = true;
            lblSimbolos.Font = new Font("Segoe UI", 15F);
            lblSimbolos.Location = new Point(488, 226);
            lblSimbolos.Name = "lblSimbolos";
            lblSimbolos.Size = new Size(118, 35);
            lblSimbolos.TabIndex = 3;
            lblSimbolos.Text = "Símbolos";
            // 
            // txtNumeros
            // 
            txtNumeros.Font = new Font("Segoe UI", 15F);
            txtNumeros.Location = new Point(35, 94);
            txtNumeros.Multiline = true;
            txtNumeros.Name = "txtNumeros";
            txtNumeros.Size = new Size(223, 107);
            txtNumeros.TabIndex = 4;
            // 
            // txtLetras
            // 
            txtLetras.Font = new Font("Segoe UI", 15F);
            txtLetras.Location = new Point(488, 94);
            txtLetras.Multiline = true;
            txtLetras.Name = "txtLetras";
            txtLetras.Size = new Size(210, 107);
            txtLetras.TabIndex = 5;
            // 
            // txtPuntuacion
            // 
            txtPuntuacion.Font = new Font("Segoe UI", 15F);
            txtPuntuacion.Location = new Point(43, 304);
            txtPuntuacion.Multiline = true;
            txtPuntuacion.Name = "txtPuntuacion";
            txtPuntuacion.Size = new Size(222, 95);
            txtPuntuacion.TabIndex = 6;
            // 
            // txtSimbolos
            // 
            txtSimbolos.Font = new Font("Segoe UI", 15F);
            txtSimbolos.Location = new Point(488, 304);
            txtSimbolos.Multiline = true;
            txtSimbolos.Name = "txtSimbolos";
            txtSimbolos.Size = new Size(193, 95);
            txtSimbolos.TabIndex = 7;
            // 
            // btnRun
            // 
            btnRun.Font = new Font("Segoe UI", 15F);
            btnRun.Location = new Point(322, 424);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(128, 54);
            btnRun.TabIndex = 8;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // Form05Char
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 504);
            Controls.Add(btnRun);
            Controls.Add(txtSimbolos);
            Controls.Add(txtPuntuacion);
            Controls.Add(txtLetras);
            Controls.Add(txtNumeros);
            Controls.Add(lblSimbolos);
            Controls.Add(lblPuntuacion);
            Controls.Add(lblLetras);
            Controls.Add(lblNumeros);
            Name = "Form05Char";
            Text = "Form05Char";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumeros;
        private Label lblLetras;
        private Label lblPuntuacion;
        private Label lblSimbolos;
        private TextBox txtNumeros;
        private TextBox txtLetras;
        private TextBox txtPuntuacion;
        private TextBox txtSimbolos;
        private Button btnRun;
    }
}