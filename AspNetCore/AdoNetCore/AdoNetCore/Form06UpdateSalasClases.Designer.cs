namespace AdoNetCore
{
    partial class Form06UpdateSalasClases
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
            btnModificarSalas = new Button();
            txtNuevaSala = new TextBox();
            lblNuevaSala = new Label();
            lstSalas = new ListBox();
            lblSalas = new Label();
            SuspendLayout();
            // 
            // btnModificarSalas
            // 
            btnModificarSalas.Location = new Point(67, 441);
            btnModificarSalas.Name = "btnModificarSalas";
            btnModificarSalas.Size = new Size(280, 70);
            btnModificarSalas.TabIndex = 9;
            btnModificarSalas.Text = "Modificar salas";
            btnModificarSalas.UseVisualStyleBackColor = true;
            btnModificarSalas.Click += btnModificarSalas_Click;
            // 
            // txtNuevaSala
            // 
            txtNuevaSala.Location = new Point(67, 369);
            txtNuevaSala.Name = "txtNuevaSala";
            txtNuevaSala.Size = new Size(280, 41);
            txtNuevaSala.TabIndex = 8;
            // 
            // lblNuevaSala
            // 
            lblNuevaSala.AutoSize = true;
            lblNuevaSala.Location = new Point(67, 309);
            lblNuevaSala.Name = "lblNuevaSala";
            lblNuevaSala.Size = new Size(136, 35);
            lblNuevaSala.TabIndex = 7;
            lblNuevaSala.Text = "Nueva sala";
            // 
            // lstSalas
            // 
            lstSalas.FormattingEnabled = true;
            lstSalas.Location = new Point(67, 60);
            lstSalas.Name = "lstSalas";
            lstSalas.Size = new Size(705, 214);
            lstSalas.TabIndex = 6;
            // 
            // lblSalas
            // 
            lblSalas.AutoSize = true;
            lblSalas.Location = new Point(67, 11);
            lblSalas.Name = "lblSalas";
            lblSalas.Size = new Size(71, 35);
            lblSalas.TabIndex = 5;
            lblSalas.Text = "Salas";
            // 
            // Form06UpdateSalasClases
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
            Margin = new Padding(5, 5, 5, 5);
            Name = "Form06UpdateSalasClases";
            Text = "Form06UpdateSalasClases";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnModificarSalas;
        private TextBox txtNuevaSala;
        private Label lblNuevaSala;
        private ListBox lstSalas;
        private Label lblSalas;
    }
}