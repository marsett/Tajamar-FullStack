namespace FundamentosNetCore
{
    partial class Form06ValidarMail
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
            lblIntroducirMail = new Label();
            txtValidarMail = new TextBox();
            btnValidarMail = new Button();
            lblResultado = new Label();
            SuspendLayout();
            // 
            // lblIntroducirMail
            // 
            lblIntroducirMail.AutoSize = true;
            lblIntroducirMail.Font = new Font("Segoe UI", 15F);
            lblIntroducirMail.Location = new Point(47, 32);
            lblIntroducirMail.Name = "lblIntroducirMail";
            lblIntroducirMail.Size = new Size(222, 35);
            lblIntroducirMail.TabIndex = 0;
            lblIntroducirMail.Text = "Introduzca un mail";
            // 
            // txtValidarMail
            // 
            txtValidarMail.Font = new Font("Segoe UI", 15F);
            txtValidarMail.Location = new Point(47, 90);
            txtValidarMail.Name = "txtValidarMail";
            txtValidarMail.Size = new Size(467, 41);
            txtValidarMail.TabIndex = 1;
            // 
            // btnValidarMail
            // 
            btnValidarMail.Font = new Font("Segoe UI", 15F);
            btnValidarMail.Location = new Point(47, 159);
            btnValidarMail.Name = "btnValidarMail";
            btnValidarMail.Size = new Size(464, 54);
            btnValidarMail.TabIndex = 2;
            btnValidarMail.Text = "Validar Email";
            btnValidarMail.UseVisualStyleBackColor = true;
            btnValidarMail.Click += btnValidarMail_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI", 15F);
            lblResultado.Location = new Point(48, 248);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(151, 35);
            lblResultado.TabIndex = 3;
            lblResultado.Text = "lblResultado";
            // 
            // Form06ValidarMail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResultado);
            Controls.Add(btnValidarMail);
            Controls.Add(txtValidarMail);
            Controls.Add(lblIntroducirMail);
            Name = "Form06ValidarMail";
            Text = "Form06ValidarMail";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIntroducirMail;
        private TextBox txtValidarMail;
        private Button btnValidarMail;
        private Label lblResultado;
    }
}