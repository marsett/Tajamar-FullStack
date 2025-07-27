namespace FundamentosNetCore
{
    partial class Form09Isbn
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
            lblISBN = new Label();
            txtISBN = new TextBox();
            btnValidarISBN = new Button();
            lblResultado = new Label();
            SuspendLayout();
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(50, 32);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(193, 35);
            lblISBN.TabIndex = 0;
            lblISBN.Text = "Introduzca ISBN";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(50, 89);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(501, 41);
            txtISBN.TabIndex = 1;
            // 
            // btnValidarISBN
            // 
            btnValidarISBN.Location = new Point(221, 167);
            btnValidarISBN.Name = "btnValidarISBN";
            btnValidarISBN.Size = new Size(177, 57);
            btnValidarISBN.TabIndex = 2;
            btnValidarISBN.Text = "Validar ISBN";
            btnValidarISBN.UseVisualStyleBackColor = true;
            btnValidarISBN.Click += btnValidarISBN_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(50, 264);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(151, 35);
            lblResultado.TabIndex = 3;
            lblResultado.Text = "lblResultado";
            // 
            // Form09Isbn
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(lblResultado);
            Controls.Add(btnValidarISBN);
            Controls.Add(txtISBN);
            Controls.Add(lblISBN);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Form09Isbn";
            Text = "Form09Isbn";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblISBN;
        private TextBox txtISBN;
        private Button btnValidarISBN;
        private Label lblResultado;
    }
}