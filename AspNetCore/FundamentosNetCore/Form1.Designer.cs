namespace FundamentosNetCore
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblRespuesta = new Label();
            txtNombre = new TextBox();
            btnPulsar = new Button();
            SuspendLayout();
            // 
            // lblRespuesta
            // 
            lblRespuesta.AutoSize = true;
            lblRespuesta.Location = new Point(78, 59);
            lblRespuesta.Name = "lblRespuesta";
            lblRespuesta.Size = new Size(155, 20);
            lblRespuesta.TabIndex = 0;
            lblRespuesta.Text = "Introduzca un nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(78, 105);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 1;
            // 
            // btnPulsar
            // 
            btnPulsar.Location = new Point(78, 167);
            btnPulsar.Name = "btnPulsar";
            btnPulsar.Size = new Size(125, 42);
            btnPulsar.TabIndex = 2;
            btnPulsar.Text = "Pulsar";
            btnPulsar.UseVisualStyleBackColor = true;
            btnPulsar.Click += btnPulsar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPulsar);
            Controls.Add(txtNombre);
            Controls.Add(lblRespuesta);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRespuesta;
        private TextBox txtNombre;
        private Button btnPulsar;
    }
}
