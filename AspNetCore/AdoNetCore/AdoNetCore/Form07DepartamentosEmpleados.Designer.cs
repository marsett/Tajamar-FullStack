namespace AdoNetCore
{
    partial class Form07DepartamentosEmpleados
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
            lstDepartamentos = new ListBox();
            lblEmpleados = new Label();
            lstEmpleados = new ListBox();
            btnEliminar = new Button();
            SuspendLayout();
            // 
            // lblDepartamentos
            // 
            lblDepartamentos.AutoSize = true;
            lblDepartamentos.Location = new Point(45, 36);
            lblDepartamentos.Margin = new Padding(5, 0, 5, 0);
            lblDepartamentos.Name = "lblDepartamentos";
            lblDepartamentos.Size = new Size(187, 35);
            lblDepartamentos.TabIndex = 0;
            lblDepartamentos.Text = "Departamentos";
            // 
            // lstDepartamentos
            // 
            lstDepartamentos.FormattingEnabled = true;
            lstDepartamentos.Location = new Point(45, 100);
            lstDepartamentos.Name = "lstDepartamentos";
            lstDepartamentos.Size = new Size(258, 284);
            lstDepartamentos.TabIndex = 1;
            lstDepartamentos.SelectedIndexChanged += lstDepartamentos_SelectedIndexChanged;
            // 
            // lblEmpleados
            // 
            lblEmpleados.AutoSize = true;
            lblEmpleados.Location = new Point(361, 36);
            lblEmpleados.Name = "lblEmpleados";
            lblEmpleados.Size = new Size(138, 35);
            lblEmpleados.TabIndex = 2;
            lblEmpleados.Text = "Empleados";
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(361, 100);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(270, 284);
            lstEmpleados.TabIndex = 3;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(703, 174);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(161, 65);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Form07DepartamentosEmpleados
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(btnEliminar);
            Controls.Add(lstEmpleados);
            Controls.Add(lblEmpleados);
            Controls.Add(lstDepartamentos);
            Controls.Add(lblDepartamentos);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form07DepartamentosEmpleados";
            Text = "Form07DepartamentosEmpleados";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDepartamentos;
        private ListBox lstDepartamentos;
        private Label lblEmpleados;
        private ListBox lstEmpleados;
        private Button btnEliminar;
    }
}