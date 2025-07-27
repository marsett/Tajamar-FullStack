namespace FundamentosNetCore
{
    partial class Form01SumarNumeros
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
            lblNumeroUno = new Label();
            txtNumeroUno = new TextBox();
            lblNumeroDos = new Label();
            txtNumeroDos = new TextBox();
            btnSumarNumeros = new Button();
            lblResultado = new Label();
            SuspendLayout();
            // 
            // lblNumeroUno
            // 
            lblNumeroUno.AutoSize = true;
            lblNumeroUno.Font = new Font("Segoe UI", 17F);
            lblNumeroUno.Location = new Point(62, 36);
            lblNumeroUno.Name = "lblNumeroUno";
            lblNumeroUno.Size = new Size(146, 40);
            lblNumeroUno.TabIndex = 0;
            lblNumeroUno.Text = "Número 1";
            // 
            // txtNumeroUno
            // 
            txtNumeroUno.Location = new Point(67, 96);
            txtNumeroUno.Name = "txtNumeroUno";
            txtNumeroUno.Size = new Size(146, 27);
            txtNumeroUno.TabIndex = 1;
            // 
            // lblNumeroDos
            // 
            lblNumeroDos.AutoSize = true;
            lblNumeroDos.Font = new Font("Segoe UI", 17F);
            lblNumeroDos.Location = new Point(64, 141);
            lblNumeroDos.Name = "lblNumeroDos";
            lblNumeroDos.Size = new Size(146, 40);
            lblNumeroDos.TabIndex = 2;
            lblNumeroDos.Text = "Número 2";
            // 
            // txtNumeroDos
            // 
            txtNumeroDos.Location = new Point(69, 197);
            txtNumeroDos.Name = "txtNumeroDos";
            txtNumeroDos.Size = new Size(141, 27);
            txtNumeroDos.TabIndex = 3;
            // 
            // btnSumarNumeros
            // 
            btnSumarNumeros.Location = new Point(303, 129);
            btnSumarNumeros.Name = "btnSumarNumeros";
            btnSumarNumeros.Size = new Size(186, 52);
            btnSumarNumeros.TabIndex = 4;
            btnSumarNumeros.Text = "Sumar números";
            btnSumarNumeros.UseVisualStyleBackColor = true;
            btnSumarNumeros.Click += btnSumarNumeros_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI", 17F);
            lblResultado.ForeColor = SystemColors.HotTrack;
            lblResultado.Location = new Point(69, 262);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(167, 40);
            lblResultado.TabIndex = 5;
            lblResultado.Text = "lblresultado";
            // 
            // Form01SumarNumeros
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResultado);
            Controls.Add(btnSumarNumeros);
            Controls.Add(txtNumeroDos);
            Controls.Add(lblNumeroDos);
            Controls.Add(txtNumeroUno);
            Controls.Add(lblNumeroUno);
            Name = "Form01SumarNumeros";
            Text = "Form01SumarNumeros";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumeroUno;
        private TextBox txtNumeroUno;
        private Label lblNumeroDos;
        private TextBox txtNumeroDos;
        private Button btnSumarNumeros;
        private Label lblResultado;
    }
}