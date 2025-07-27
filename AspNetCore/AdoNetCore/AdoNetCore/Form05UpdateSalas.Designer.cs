namespace AdoNetCore
{
    partial class Form05UpdateSalas
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
            lblSalas = new Label();
            lstSalas = new ListBox();
            lblNuevaSala = new Label();
            txtNuevaSala = new TextBox();
            btnModificarSalas = new Button();
            SuspendLayout();
            // 
            // lblSalas
            // 
            lblSalas.AutoSize = true;
            lblSalas.Location = new Point(74, 21);
            lblSalas.Name = "lblSalas";
            lblSalas.Size = new Size(71, 35);
            lblSalas.TabIndex = 0;
            lblSalas.Text = "Salas";
            // 
            // lstSalas
            // 
            lstSalas.FormattingEnabled = true;
            lstSalas.Location = new Point(74, 70);
            lstSalas.Name = "lstSalas";
            lstSalas.Size = new Size(705, 214);
            lstSalas.TabIndex = 1;
            // 
            // lblNuevaSala
            // 
            lblNuevaSala.AutoSize = true;
            lblNuevaSala.Location = new Point(74, 319);
            lblNuevaSala.Name = "lblNuevaSala";
            lblNuevaSala.Size = new Size(136, 35);
            lblNuevaSala.TabIndex = 2;
            lblNuevaSala.Text = "Nueva sala";
            // 
            // txtNuevaSala
            // 
            txtNuevaSala.Location = new Point(74, 379);
            txtNuevaSala.Name = "txtNuevaSala";
            txtNuevaSala.Size = new Size(280, 41);
            txtNuevaSala.TabIndex = 3;
            // 
            // btnModificarSalas
            // 
            btnModificarSalas.Location = new Point(74, 451);
            btnModificarSalas.Name = "btnModificarSalas";
            btnModificarSalas.Size = new Size(280, 70);
            btnModificarSalas.TabIndex = 4;
            btnModificarSalas.Text = "Modificar salas";
            btnModificarSalas.UseVisualStyleBackColor = true;
            btnModificarSalas.Click += btnModificarSalas_Click;
            // 
            // Form05UpdateSalas
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(btnModificarSalas);
            Controls.Add(txtNuevaSala);
            Controls.Add(lblNuevaSala);
            Controls.Add(lstSalas);
            Controls.Add(lblSalas);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form05UpdateSalas";
            Text = "Form05UpdateSalas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSalas;
        private ListBox lstSalas;
        private Label lblNuevaSala;
        private TextBox txtNuevaSala;
        private Button btnModificarSalas;
    }
}