namespace AdoNetCore
{
    partial class Form11UpdatePlantillaProcedures
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
            lblHospitales = new Label();
            lblIncremento = new Label();
            btnModificarSalarios = new Button();
            lblPlantilla = new Label();
            lstPlantilla = new ListBox();
            txtIncremento = new TextBox();
            cmbHospitales = new ComboBox();
            SuspendLayout();
            // 
            // lblHospitales
            // 
            lblHospitales.AutoSize = true;
            lblHospitales.Location = new Point(55, 35);
            lblHospitales.Name = "lblHospitales";
            lblHospitales.Size = new Size(131, 35);
            lblHospitales.TabIndex = 0;
            lblHospitales.Text = "Hospitales";
            // 
            // lblIncremento
            // 
            lblIncremento.AutoSize = true;
            lblIncremento.Location = new Point(397, 35);
            lblIncremento.Name = "lblIncremento";
            lblIncremento.Size = new Size(142, 35);
            lblIncremento.TabIndex = 1;
            lblIncremento.Text = "Incremento";
            // 
            // btnModificarSalarios
            // 
            btnModificarSalarios.Location = new Point(166, 160);
            btnModificarSalarios.Name = "btnModificarSalarios";
            btnModificarSalarios.Size = new Size(271, 61);
            btnModificarSalarios.TabIndex = 2;
            btnModificarSalarios.Text = "Modificar salarios";
            btnModificarSalarios.UseVisualStyleBackColor = true;
            btnModificarSalarios.Click += btnModificarSalarios_Click;
            // 
            // lblPlantilla
            // 
            lblPlantilla.AutoSize = true;
            lblPlantilla.Location = new Point(55, 236);
            lblPlantilla.Name = "lblPlantilla";
            lblPlantilla.Size = new Size(101, 35);
            lblPlantilla.TabIndex = 3;
            lblPlantilla.Text = "Plantilla";
            // 
            // lstPlantilla
            // 
            lstPlantilla.FormattingEnabled = true;
            lstPlantilla.Location = new Point(55, 297);
            lstPlantilla.Name = "lstPlantilla";
            lstPlantilla.Size = new Size(700, 319);
            lstPlantilla.TabIndex = 4;
            // 
            // txtIncremento
            // 
            txtIncremento.Location = new Point(397, 93);
            txtIncremento.Name = "txtIncremento";
            txtIncremento.Size = new Size(262, 41);
            txtIncremento.TabIndex = 5;
            // 
            // cmbHospitales
            // 
            cmbHospitales.FormattingEnabled = true;
            cmbHospitales.Location = new Point(55, 91);
            cmbHospitales.Name = "cmbHospitales";
            cmbHospitales.Size = new Size(151, 43);
            cmbHospitales.TabIndex = 6;
            cmbHospitales.SelectedIndexChanged += cmbHospitales_SelectedIndexChanged;
            // 
            // Form11UpdatePlantillaProcedures
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(cmbHospitales);
            Controls.Add(txtIncremento);
            Controls.Add(lstPlantilla);
            Controls.Add(lblPlantilla);
            Controls.Add(btnModificarSalarios);
            Controls.Add(lblIncremento);
            Controls.Add(lblHospitales);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form11UpdatePlantillaProcedures";
            Text = "Form11UpdatePlantillaProcedures";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHospitales;
        private Label lblIncremento;
        private Button btnModificarSalarios;
        private Label lblPlantilla;
        private ListBox lstPlantilla;
        private TextBox txtIncremento;
        private ComboBox cmbHospitales;
    }
}