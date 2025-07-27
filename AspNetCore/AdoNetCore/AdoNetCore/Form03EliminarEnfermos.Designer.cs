namespace AdoNetCore
{
    partial class Form03EliminarEnfermos
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
            lblInscripcion = new Label();
            txtInscripcion = new TextBox();
            btnEliminarEnfermo = new Button();
            lblEnfermos = new Label();
            lstEnfermos = new ListBox();
            SuspendLayout();
            // 
            // lblInscripcion
            // 
            lblInscripcion.AutoSize = true;
            lblInscripcion.Location = new Point(78, 59);
            lblInscripcion.Margin = new Padding(5, 0, 5, 0);
            lblInscripcion.Name = "lblInscripcion";
            lblInscripcion.Size = new Size(136, 35);
            lblInscripcion.TabIndex = 0;
            lblInscripcion.Text = "Inscripción";
            // 
            // txtInscripcion
            // 
            txtInscripcion.Location = new Point(78, 117);
            txtInscripcion.Name = "txtInscripcion";
            txtInscripcion.Size = new Size(229, 41);
            txtInscripcion.TabIndex = 1;
            // 
            // btnEliminarEnfermo
            // 
            btnEliminarEnfermo.Location = new Point(78, 184);
            btnEliminarEnfermo.Name = "btnEliminarEnfermo";
            btnEliminarEnfermo.Size = new Size(229, 65);
            btnEliminarEnfermo.TabIndex = 2;
            btnEliminarEnfermo.Text = "Eliminar enfermo";
            btnEliminarEnfermo.UseVisualStyleBackColor = true;
            btnEliminarEnfermo.Click += btnEliminarEnfermo_Click;
            // 
            // lblEnfermos
            // 
            lblEnfermos.AutoSize = true;
            lblEnfermos.Location = new Point(400, 59);
            lblEnfermos.Name = "lblEnfermos";
            lblEnfermos.Size = new Size(120, 35);
            lblEnfermos.TabIndex = 3;
            lblEnfermos.Text = "Enfermos";
            // 
            // lstEnfermos
            // 
            lstEnfermos.FormattingEnabled = true;
            lstEnfermos.Location = new Point(400, 117);
            lstEnfermos.Name = "lstEnfermos";
            lstEnfermos.Size = new Size(276, 249);
            lstEnfermos.TabIndex = 4;
            // 
            // Form03EliminarEnfermos
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(lstEnfermos);
            Controls.Add(lblEnfermos);
            Controls.Add(btnEliminarEnfermo);
            Controls.Add(txtInscripcion);
            Controls.Add(lblInscripcion);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Form03EliminarEnfermos";
            Text = "Form03EliminarEnfermos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInscripcion;
        private TextBox txtInscripcion;
        private Button btnEliminarEnfermo;
        private Label lblEnfermos;
        private ListBox lstEnfermos;
    }
}