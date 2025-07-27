namespace AdoNetCorePractica
{
    partial class FormHospitales
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
            cmbHospitales = new ComboBox();
            lblEmpleadosHospital = new Label();
            lstEmpleadosHospital = new ListBox();
            lblSumaSalarial = new Label();
            txtSumaSalarial = new TextBox();
            txtMediaSalarial = new TextBox();
            txtPersonas = new TextBox();
            lblMediaSalarial = new Label();
            lblPersonas = new Label();
            SuspendLayout();
            // 
            // lblHospitales
            // 
            lblHospitales.AutoSize = true;
            lblHospitales.Location = new Point(44, 38);
            lblHospitales.Name = "lblHospitales";
            lblHospitales.Size = new Size(131, 35);
            lblHospitales.TabIndex = 0;
            lblHospitales.Text = "Hospitales";
            // 
            // cmbHospitales
            // 
            cmbHospitales.FormattingEnabled = true;
            cmbHospitales.Location = new Point(44, 97);
            cmbHospitales.Name = "cmbHospitales";
            cmbHospitales.Size = new Size(151, 43);
            cmbHospitales.TabIndex = 1;
            cmbHospitales.SelectedIndexChanged += cmbHospitales_SelectedIndexChanged;
            // 
            // lblEmpleadosHospital
            // 
            lblEmpleadosHospital.AutoSize = true;
            lblEmpleadosHospital.Location = new Point(370, 38);
            lblEmpleadosHospital.Name = "lblEmpleadosHospital";
            lblEmpleadosHospital.Size = new Size(237, 35);
            lblEmpleadosHospital.TabIndex = 2;
            lblEmpleadosHospital.Text = "Empleados Hospital";
            // 
            // lstEmpleadosHospital
            // 
            lstEmpleadosHospital.FormattingEnabled = true;
            lstEmpleadosHospital.Location = new Point(370, 97);
            lstEmpleadosHospital.Name = "lstEmpleadosHospital";
            lstEmpleadosHospital.Size = new Size(389, 319);
            lstEmpleadosHospital.TabIndex = 3;
            // 
            // lblSumaSalarial
            // 
            lblSumaSalarial.AutoSize = true;
            lblSumaSalarial.Location = new Point(37, 228);
            lblSumaSalarial.Name = "lblSumaSalarial";
            lblSumaSalarial.Size = new Size(161, 35);
            lblSumaSalarial.TabIndex = 4;
            lblSumaSalarial.Text = "Suma salarial";
            // 
            // txtSumaSalarial
            // 
            txtSumaSalarial.Location = new Point(44, 285);
            txtSumaSalarial.Name = "txtSumaSalarial";
            txtSumaSalarial.Size = new Size(201, 41);
            txtSumaSalarial.TabIndex = 5;
            // 
            // txtMediaSalarial
            // 
            txtMediaSalarial.Location = new Point(44, 410);
            txtMediaSalarial.Name = "txtMediaSalarial";
            txtMediaSalarial.Size = new Size(201, 41);
            txtMediaSalarial.TabIndex = 6;
            // 
            // txtPersonas
            // 
            txtPersonas.Location = new Point(44, 544);
            txtPersonas.Name = "txtPersonas";
            txtPersonas.Size = new Size(201, 41);
            txtPersonas.TabIndex = 7;
            // 
            // lblMediaSalarial
            // 
            lblMediaSalarial.AutoSize = true;
            lblMediaSalarial.Location = new Point(37, 348);
            lblMediaSalarial.Name = "lblMediaSalarial";
            lblMediaSalarial.Size = new Size(168, 35);
            lblMediaSalarial.TabIndex = 8;
            lblMediaSalarial.Text = "Media salarial";
            // 
            // lblPersonas
            // 
            lblPersonas.AutoSize = true;
            lblPersonas.Location = new Point(44, 484);
            lblPersonas.Name = "lblPersonas";
            lblPersonas.Size = new Size(114, 35);
            lblPersonas.TabIndex = 9;
            lblPersonas.Text = "Personas";
            // 
            // FormHospitales
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(lblPersonas);
            Controls.Add(lblMediaSalarial);
            Controls.Add(txtPersonas);
            Controls.Add(txtMediaSalarial);
            Controls.Add(txtSumaSalarial);
            Controls.Add(lblSumaSalarial);
            Controls.Add(lstEmpleadosHospital);
            Controls.Add(lblEmpleadosHospital);
            Controls.Add(cmbHospitales);
            Controls.Add(lblHospitales);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "FormHospitales";
            Text = "FormHospitales";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHospitales;
        private ComboBox cmbHospitales;
        private Label lblEmpleadosHospital;
        private ListBox lstEmpleadosHospital;
        private Label lblSumaSalarial;
        private TextBox txtSumaSalarial;
        private TextBox txtMediaSalarial;
        private TextBox txtPersonas;
        private Label lblMediaSalarial;
        private Label lblPersonas;
    }
}