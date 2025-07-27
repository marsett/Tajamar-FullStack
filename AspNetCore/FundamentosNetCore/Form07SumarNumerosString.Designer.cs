namespace FundamentosNetCore
{
    partial class Form07SumarNumerosString
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
            lblIntroduzcaNumeros = new Label();
            txtNumeros = new TextBox();
            btnSumarNumeros = new Button();
            lblResultado = new Label();
            SuspendLayout();
            // 
            // lblIntroduzcaNumeros
            // 
            lblIntroduzcaNumeros.AutoSize = true;
            lblIntroduzcaNumeros.Location = new Point(56, 32);
            lblIntroduzcaNumeros.Name = "lblIntroduzcaNumeros";
            lblIntroduzcaNumeros.Size = new Size(238, 35);
            lblIntroduzcaNumeros.TabIndex = 0;
            lblIntroduzcaNumeros.Text = "Introduzca números";
            // 
            // txtNumeros
            // 
            txtNumeros.Location = new Point(56, 84);
            txtNumeros.Name = "txtNumeros";
            txtNumeros.Size = new Size(260, 41);
            txtNumeros.TabIndex = 1;
            // 
            // btnSumarNumeros
            // 
            btnSumarNumeros.Location = new Point(58, 152);
            btnSumarNumeros.Name = "btnSumarNumeros";
            btnSumarNumeros.Size = new Size(258, 60);
            btnSumarNumeros.TabIndex = 2;
            btnSumarNumeros.Text = "Sumar números";
            btnSumarNumeros.UseVisualStyleBackColor = true;
            btnSumarNumeros.Click += btnSumarNumeros_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(58, 249);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(151, 35);
            lblResultado.TabIndex = 3;
            lblResultado.Text = "lblResultado";
            // 
            // Form07SumarNumerosString
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(lblResultado);
            Controls.Add(btnSumarNumeros);
            Controls.Add(txtNumeros);
            Controls.Add(lblIntroduzcaNumeros);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Form07SumarNumerosString";
            Text = "Form07SumarNumerosString";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIntroduzcaNumeros;
        private TextBox txtNumeros;
        private Button btnSumarNumeros;
        private Label lblResultado;
    }
}