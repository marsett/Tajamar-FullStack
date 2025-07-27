namespace AdoNetCore
{
    partial class Form13ParametrosSalida
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
            lblDepartamentos = new Label();
            cmbDepartamentos = new ComboBox();
            btnMostrarDatos = new Button();
            lblSumaSalarial = new Label();
            txtSumaSalarial = new TextBox();
            lblMediaSalarial = new Label();
            txtMediaSalarial = new TextBox();
            lblPersonas = new Label();
            txtPersonas = new TextBox();
            lblEmpleados = new Label();
            lstEmpleados = new ListBox();
            SuspendLayout();
            // 
            // lblDepartamentos
            // 
            lblDepartamentos.AutoSize = true;
            lblDepartamentos.Location = new Point(43, 28);
            lblDepartamentos.Name = "lblDepartamentos";
            lblDepartamentos.Size = new Size(187, 35);
            lblDepartamentos.TabIndex = 0;
            lblDepartamentos.Text = "Departamentos";
            // 
            // cmbDepartamentos
            // 
            cmbDepartamentos.FormattingEnabled = true;
            cmbDepartamentos.Location = new Point(43, 85);
            cmbDepartamentos.Name = "cmbDepartamentos";
            cmbDepartamentos.Size = new Size(227, 43);
            cmbDepartamentos.TabIndex = 1;
            // 
            // btnMostrarDatos
            // 
            btnMostrarDatos.Location = new Point(43, 160);
            btnMostrarDatos.Name = "btnMostrarDatos";
            btnMostrarDatos.Size = new Size(227, 60);
            btnMostrarDatos.TabIndex = 2;
            btnMostrarDatos.Text = "Mostrar datos";
            btnMostrarDatos.UseVisualStyleBackColor = true;
            btnMostrarDatos.Click += btnMostrarDatos_Click;
            // 
            // lblSumaSalarial
            // 
            lblSumaSalarial.AutoSize = true;
            lblSumaSalarial.Location = new Point(43, 264);
            lblSumaSalarial.Name = "lblSumaSalarial";
            lblSumaSalarial.Size = new Size(161, 35);
            lblSumaSalarial.TabIndex = 3;
            lblSumaSalarial.Text = "Suma salarial";
            // 
            // txtSumaSalarial
            // 
            txtSumaSalarial.Location = new Point(43, 325);
            txtSumaSalarial.Name = "txtSumaSalarial";
            txtSumaSalarial.Size = new Size(227, 41);
            txtSumaSalarial.TabIndex = 4;
            // 
            // lblMediaSalarial
            // 
            lblMediaSalarial.AutoSize = true;
            lblMediaSalarial.Location = new Point(43, 397);
            lblMediaSalarial.Name = "lblMediaSalarial";
            lblMediaSalarial.Size = new Size(168, 35);
            lblMediaSalarial.TabIndex = 5;
            lblMediaSalarial.Text = "Media salarial";
            // 
            // txtMediaSalarial
            // 
            txtMediaSalarial.Location = new Point(43, 459);
            txtMediaSalarial.Name = "txtMediaSalarial";
            txtMediaSalarial.Size = new Size(227, 41);
            txtMediaSalarial.TabIndex = 6;
            // 
            // lblPersonas
            // 
            lblPersonas.AutoSize = true;
            lblPersonas.Location = new Point(43, 543);
            lblPersonas.Name = "lblPersonas";
            lblPersonas.Size = new Size(114, 35);
            lblPersonas.TabIndex = 7;
            lblPersonas.Text = "Personas";
            // 
            // txtPersonas
            // 
            txtPersonas.Location = new Point(43, 614);
            txtPersonas.Name = "txtPersonas";
            txtPersonas.Size = new Size(227, 41);
            txtPersonas.TabIndex = 8;
            // 
            // lblEmpleados
            // 
            lblEmpleados.AutoSize = true;
            lblEmpleados.Location = new Point(447, 28);
            lblEmpleados.Name = "lblEmpleados";
            lblEmpleados.Size = new Size(138, 35);
            lblEmpleados.TabIndex = 9;
            lblEmpleados.Text = "Empleados";
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(447, 85);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(360, 424);
            lstEmpleados.TabIndex = 10;
            // 
            // Form13ParametrosSalida
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(lstEmpleados);
            Controls.Add(lblEmpleados);
            Controls.Add(txtPersonas);
            Controls.Add(lblPersonas);
            Controls.Add(txtMediaSalarial);
            Controls.Add(lblMediaSalarial);
            Controls.Add(txtSumaSalarial);
            Controls.Add(lblSumaSalarial);
            Controls.Add(btnMostrarDatos);
            Controls.Add(cmbDepartamentos);
            Controls.Add(lblDepartamentos);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form13ParametrosSalida";
            Text = "Form13ParametrosSalida";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDepartamentos;
        private ComboBox cmbDepartamentos;
        private Button btnMostrarDatos;
        private Label lblSumaSalarial;
        private TextBox txtSumaSalarial;
        private Label lblMediaSalarial;
        private TextBox txtMediaSalarial;
        private Label lblPersonas;
        private TextBox txtPersonas;
        private Label lblEmpleados;
        private ListBox lstEmpleados;
    }
}