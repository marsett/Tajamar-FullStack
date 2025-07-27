namespace FundamentosNetCore
{
    partial class Form13ColeccionNumeros
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
            lstNumeros = new ListBox();
            btnGenerar = new Button();
            btnMostrarDatos = new Button();
            lblSuma = new Label();
            lblPares = new Label();
            lblImpares = new Label();
            txtSuma = new TextBox();
            txtImpares = new TextBox();
            txtPares = new TextBox();
            SuspendLayout();
            // 
            // lblNumeros
            // 
            lblNumeros.AutoSize = true;
            lblNumeros.Location = new Point(58, 40);
            lblNumeros.Margin = new Padding(5, 0, 5, 0);
            lblNumeros.Name = "lblNumeros";
            lblNumeros.Size = new Size(118, 35);
            lblNumeros.TabIndex = 0;
            lblNumeros.Text = "Números";
            // 
            // lstNumeros
            // 
            lstNumeros.FormattingEnabled = true;
            lstNumeros.Location = new Point(67, 98);
            lstNumeros.Name = "lstNumeros";
            lstNumeros.Size = new Size(233, 354);
            lstNumeros.TabIndex = 1;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(425, 46);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(150, 47);
            btnGenerar.TabIndex = 2;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // btnMostrarDatos
            // 
            btnMostrarDatos.Location = new Point(425, 127);
            btnMostrarDatos.Name = "btnMostrarDatos";
            btnMostrarDatos.Size = new Size(186, 47);
            btnMostrarDatos.TabIndex = 3;
            btnMostrarDatos.Text = "Mostrar datos";
            btnMostrarDatos.UseVisualStyleBackColor = true;
            btnMostrarDatos.Click += btnMostrarDatos_Click;
            // 
            // lblSuma
            // 
            lblSuma.AutoSize = true;
            lblSuma.Location = new Point(427, 215);
            lblSuma.Name = "lblSuma";
            lblSuma.Size = new Size(77, 35);
            lblSuma.TabIndex = 4;
            lblSuma.Text = "Suma";
            // 
            // lblPares
            // 
            lblPares.AutoSize = true;
            lblPares.Location = new Point(427, 277);
            lblPares.Name = "lblPares";
            lblPares.Size = new Size(74, 35);
            lblPares.TabIndex = 5;
            lblPares.Text = "Pares";
            // 
            // lblImpares
            // 
            lblImpares.AutoSize = true;
            lblImpares.Location = new Point(430, 339);
            lblImpares.Name = "lblImpares";
            lblImpares.Size = new Size(105, 35);
            lblImpares.TabIndex = 6;
            lblImpares.Text = "Impares";
            // 
            // txtSuma
            // 
            txtSuma.Location = new Point(606, 215);
            txtSuma.Name = "txtSuma";
            txtSuma.Size = new Size(125, 41);
            txtSuma.TabIndex = 7;
            // 
            // txtImpares
            // 
            txtImpares.Location = new Point(606, 339);
            txtImpares.Name = "txtImpares";
            txtImpares.Size = new Size(125, 41);
            txtImpares.TabIndex = 8;
            // 
            // txtPares
            // 
            txtPares.Location = new Point(606, 277);
            txtPares.Name = "txtPares";
            txtPares.Size = new Size(125, 41);
            txtPares.TabIndex = 9;
            // 
            // Form13ColeccionNumeros
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(txtPares);
            Controls.Add(txtImpares);
            Controls.Add(txtSuma);
            Controls.Add(lblImpares);
            Controls.Add(lblPares);
            Controls.Add(lblSuma);
            Controls.Add(btnMostrarDatos);
            Controls.Add(btnGenerar);
            Controls.Add(lstNumeros);
            Controls.Add(lblNumeros);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form13ColeccionNumeros";
            Text = "Form13ColeccionNumeros";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumeros;
        private ListBox lstNumeros;
        private Button btnGenerar;
        private Button btnMostrarDatos;
        private Label lblSuma;
        private Label lblPares;
        private Label lblImpares;
        private TextBox txtSuma;
        private TextBox txtImpares;
        private TextBox txtPares;
    }
}