namespace FundamentosNetCore
{
    partial class Form15Metodos
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
            lblResultado = new Label();
            btnDobleValor = new Button();
            btnDobleReferencia = new Button();
            btnObjetoReferencia = new Button();
            label1 = new Label();
            txtSoloNumeros = new TextBox();
            txtSoloLetras = new TextBox();
            lblSoloLetras = new Label();
            lblRaton = new Label();
            SuspendLayout();
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(40, 31);
            lblNumero.Margin = new Padding(5, 0, 5, 0);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(107, 35);
            lblNumero.TabIndex = 0;
            lblNumero.Text = "Número";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(40, 86);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(213, 41);
            txtNumero.TabIndex = 1;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(40, 162);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(151, 35);
            lblResultado.TabIndex = 2;
            lblResultado.Text = "lblResultado";
            // 
            // btnDobleValor
            // 
            btnDobleValor.Location = new Point(40, 228);
            btnDobleValor.Name = "btnDobleValor";
            btnDobleValor.Size = new Size(175, 67);
            btnDobleValor.TabIndex = 3;
            btnDobleValor.Text = "Doble Valor";
            btnDobleValor.UseVisualStyleBackColor = true;
            btnDobleValor.Click += btnDobleValor_Click;
            // 
            // btnDobleReferencia
            // 
            btnDobleReferencia.Location = new Point(40, 332);
            btnDobleReferencia.Name = "btnDobleReferencia";
            btnDobleReferencia.Size = new Size(175, 86);
            btnDobleReferencia.TabIndex = 4;
            btnDobleReferencia.Text = "Doble Referencia";
            btnDobleReferencia.UseVisualStyleBackColor = true;
            btnDobleReferencia.Click += btnDobleReferencia_Click;
            // 
            // btnObjetoReferencia
            // 
            btnObjetoReferencia.Location = new Point(40, 453);
            btnObjetoReferencia.Name = "btnObjetoReferencia";
            btnObjetoReferencia.Size = new Size(175, 85);
            btnObjetoReferencia.TabIndex = 5;
            btnObjetoReferencia.Text = "Objeto Referencia";
            btnObjetoReferencia.UseVisualStyleBackColor = true;
            btnObjetoReferencia.Click += btnObjetoReferencia_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(399, 31);
            label1.Name = "label1";
            label1.Size = new Size(169, 35);
            label1.TabIndex = 6;
            label1.Text = "Sólo números";
            // 
            // txtSoloNumeros
            // 
            txtSoloNumeros.Location = new Point(399, 86);
            txtSoloNumeros.Name = "txtSoloNumeros";
            txtSoloNumeros.Size = new Size(340, 41);
            txtSoloNumeros.TabIndex = 7;
            txtSoloNumeros.KeyPress += txtSoloNumeros_KeyPress;
            // 
            // txtSoloLetras
            // 
            txtSoloLetras.Location = new Point(399, 228);
            txtSoloLetras.Name = "txtSoloLetras";
            txtSoloLetras.Size = new Size(340, 41);
            txtSoloLetras.TabIndex = 8;
            txtSoloLetras.KeyPress += txtSoloLetras_KeyPress;
            // 
            // lblSoloLetras
            // 
            lblSoloLetras.AutoSize = true;
            lblSoloLetras.Location = new Point(399, 162);
            lblSoloLetras.Name = "lblSoloLetras";
            lblSoloLetras.Size = new Size(131, 35);
            lblSoloLetras.TabIndex = 9;
            lblSoloLetras.Text = "Sólo letras";
            // 
            // lblRaton
            // 
            lblRaton.BackColor = SystemColors.MenuHighlight;
            lblRaton.Location = new Point(399, 310);
            lblRaton.Name = "lblRaton";
            lblRaton.Size = new Size(340, 205);
            lblRaton.TabIndex = 10;
            lblRaton.Text = "lblRaton";
            lblRaton.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form15Metodos
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(lblRaton);
            Controls.Add(lblSoloLetras);
            Controls.Add(txtSoloLetras);
            Controls.Add(txtSoloNumeros);
            Controls.Add(label1);
            Controls.Add(btnObjetoReferencia);
            Controls.Add(btnDobleReferencia);
            Controls.Add(btnDobleValor);
            Controls.Add(lblResultado);
            Controls.Add(txtNumero);
            Controls.Add(lblNumero);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form15Metodos";
            Text = "Form15Metodos";
            MouseMove += Form15Metodos_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumero;
        private TextBox txtNumero;
        private Label lblResultado;
        private Button btnDobleValor;
        private Button btnDobleReferencia;
        private Button btnObjetoReferencia;
        private Label label1;
        private TextBox txtSoloNumeros;
        private TextBox txtSoloLetras;
        private Label lblSoloLetras;
        private Label lblRaton;
    }
}