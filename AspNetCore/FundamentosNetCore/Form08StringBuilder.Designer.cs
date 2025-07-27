namespace FundamentosNetCore
{
    partial class Form08StringBuilder
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
            lblTexto = new Label();
            txtTexto = new RichTextBox();
            btnInvertirString = new Button();
            btnInvertirStringBuilder = new Button();
            lblTiempo = new Label();
            SuspendLayout();
            // 
            // lblTexto
            // 
            lblTexto.AutoSize = true;
            lblTexto.Location = new Point(51, 9);
            lblTexto.Margin = new Padding(5, 0, 5, 0);
            lblTexto.Name = "lblTexto";
            lblTexto.Size = new Size(317, 35);
            lblTexto.TabIndex = 0;
            lblTexto.Text = "Copie el texto para trabajar";
            // 
            // txtTexto
            // 
            txtTexto.Location = new Point(51, 60);
            txtTexto.Name = "txtTexto";
            txtTexto.Size = new Size(786, 313);
            txtTexto.TabIndex = 1;
            txtTexto.Text = "";
            // 
            // btnInvertirString
            // 
            btnInvertirString.Location = new Point(74, 460);
            btnInvertirString.Name = "btnInvertirString";
            btnInvertirString.Size = new Size(211, 55);
            btnInvertirString.TabIndex = 2;
            btnInvertirString.Text = "Invertir String";
            btnInvertirString.UseVisualStyleBackColor = true;
            btnInvertirString.Click += btnInvertirString_Click;
            // 
            // btnInvertirStringBuilder
            // 
            btnInvertirStringBuilder.Location = new Point(499, 460);
            btnInvertirStringBuilder.Name = "btnInvertirStringBuilder";
            btnInvertirStringBuilder.Size = new Size(276, 55);
            btnInvertirStringBuilder.TabIndex = 3;
            btnInvertirStringBuilder.Text = "Invertir String Builder";
            btnInvertirStringBuilder.UseVisualStyleBackColor = true;
            btnInvertirStringBuilder.Click += btnInvertirStringBuilder_Click;
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Location = new Point(54, 395);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(126, 35);
            lblTiempo.TabIndex = 4;
            lblTiempo.Text = "lblTiempo";
            // 
            // Form08StringBuilder
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(lblTiempo);
            Controls.Add(btnInvertirStringBuilder);
            Controls.Add(btnInvertirString);
            Controls.Add(txtTexto);
            Controls.Add(lblTexto);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form08StringBuilder";
            Text = "Form08StringBuilder";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTexto;
        private RichTextBox txtTexto;
        private Button btnInvertirString;
        private Button btnInvertirStringBuilder;
        private Label lblTiempo;
    }
}