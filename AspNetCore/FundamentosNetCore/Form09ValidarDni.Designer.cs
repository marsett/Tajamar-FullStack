namespace FundamentosNetCore
{
    partial class Form09ValidarDni
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
            lblDni = new Label();
            txtDni = new TextBox();
            btnValidarDni = new Button();
            lblResultado = new Label();
            SuspendLayout();
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(102, 46);
            lblDni.Margin = new Padding(5, 0, 5, 0);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(184, 35);
            lblDni.TabIndex = 0;
            lblDni.Text = "Introduzca DNI";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(110, 107);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(468, 41);
            txtDni.TabIndex = 1;
            // 
            // btnValidarDni
            // 
            btnValidarDni.Location = new Point(243, 191);
            btnValidarDni.Name = "btnValidarDni";
            btnValidarDni.Size = new Size(227, 66);
            btnValidarDni.TabIndex = 2;
            btnValidarDni.Text = "Validar DNI";
            btnValidarDni.UseVisualStyleBackColor = true;
            btnValidarDni.Click += btnValidarDni_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(110, 291);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(151, 35);
            lblResultado.TabIndex = 3;
            lblResultado.Text = "lblResultado";
            // 
            // Form09ValidarDni
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(lblResultado);
            Controls.Add(btnValidarDni);
            Controls.Add(txtDni);
            Controls.Add(lblDni);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Form09ValidarDni";
            Text = "Form09ValidarDni";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDni;
        private TextBox txtDni;
        private Button btnValidarDni;
        private Label lblResultado;
    }
}