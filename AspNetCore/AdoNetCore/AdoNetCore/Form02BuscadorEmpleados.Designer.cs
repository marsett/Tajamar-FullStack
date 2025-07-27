namespace AdoNetCore
{
    partial class Form02BuscadorEmpleados
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
            lblIntroducirSalario = new Label();
            txtSalario = new TextBox();
            btnBuscadorEmpleados = new Button();
            lblEmpleados = new Label();
            lstEmpleados = new ListBox();
            lblIntroducirOficio = new Label();
            btnBuscarPorOficio = new Button();
            txtOficio = new TextBox();
            SuspendLayout();
            // 
            // lblIntroducirSalario
            // 
            lblIntroducirSalario.AutoSize = true;
            lblIntroducirSalario.Location = new Point(97, 27);
            lblIntroducirSalario.Margin = new Padding(5, 0, 5, 0);
            lblIntroducirSalario.Name = "lblIntroducirSalario";
            lblIntroducirSalario.Size = new Size(213, 35);
            lblIntroducirSalario.TabIndex = 0;
            lblIntroducirSalario.Text = "Introduzca salario";
            // 
            // txtSalario
            // 
            txtSalario.Location = new Point(97, 88);
            txtSalario.Name = "txtSalario";
            txtSalario.Size = new Size(264, 41);
            txtSalario.TabIndex = 1;
            // 
            // btnBuscadorEmpleados
            // 
            btnBuscadorEmpleados.Location = new Point(96, 145);
            btnBuscadorEmpleados.Name = "btnBuscadorEmpleados";
            btnBuscadorEmpleados.Size = new Size(265, 55);
            btnBuscadorEmpleados.TabIndex = 2;
            btnBuscadorEmpleados.Text = "Buscar empleados";
            btnBuscadorEmpleados.UseVisualStyleBackColor = true;
            btnBuscadorEmpleados.Click += btnBuscadorEmpleados_Click;
            // 
            // lblEmpleados
            // 
            lblEmpleados.AutoSize = true;
            lblEmpleados.Location = new Point(96, 223);
            lblEmpleados.Name = "lblEmpleados";
            lblEmpleados.Size = new Size(138, 35);
            lblEmpleados.TabIndex = 3;
            lblEmpleados.Text = "Empleados";
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(97, 281);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(496, 249);
            lstEmpleados.TabIndex = 4;
            // 
            // lblIntroducirOficio
            // 
            lblIntroducirOficio.AutoSize = true;
            lblIntroducirOficio.Location = new Point(539, 27);
            lblIntroducirOficio.Name = "lblIntroducirOficio";
            lblIntroducirOficio.Size = new Size(202, 35);
            lblIntroducirOficio.TabIndex = 5;
            lblIntroducirOficio.Text = "Introduzca oficio";
            // 
            // btnBuscarPorOficio
            // 
            btnBuscarPorOficio.Location = new Point(538, 145);
            btnBuscarPorOficio.Name = "btnBuscarPorOficio";
            btnBuscarPorOficio.Size = new Size(265, 55);
            btnBuscarPorOficio.TabIndex = 6;
            btnBuscarPorOficio.Text = "Buscar por Oficio";
            btnBuscarPorOficio.UseVisualStyleBackColor = true;
            btnBuscarPorOficio.Click += btnBuscarPorOficio_Click;
            // 
            // txtOficio
            // 
            txtOficio.Location = new Point(539, 88);
            txtOficio.Name = "txtOficio";
            txtOficio.Size = new Size(264, 41);
            txtOficio.TabIndex = 7;
            // 
            // Form02BuscadorEmpleados
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(txtOficio);
            Controls.Add(btnBuscarPorOficio);
            Controls.Add(lblIntroducirOficio);
            Controls.Add(lstEmpleados);
            Controls.Add(lblEmpleados);
            Controls.Add(btnBuscadorEmpleados);
            Controls.Add(txtSalario);
            Controls.Add(lblIntroducirSalario);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form02BuscadorEmpleados";
            Text = "Form02BuscadorEmpleados";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIntroducirSalario;
        private TextBox txtSalario;
        private Button btnBuscadorEmpleados;
        private Label lblEmpleados;
        private ListBox lstEmpleados;
        private Label lblIntroducirOficio;
        private Button btnBuscarPorOficio;
        private TextBox txtOficio;
    }
}