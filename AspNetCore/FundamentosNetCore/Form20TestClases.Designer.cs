namespace FundamentosNetCore
{
    partial class Form20TestClases
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
            lblLibrerias = new Label();
            lstClases = new ListBox();
            btnPersona = new Button();
            btnEmpleado = new Button();
            SuspendLayout();
            // 
            // lblLibrerias
            // 
            lblLibrerias.AutoSize = true;
            lblLibrerias.Location = new Point(51, 23);
            lblLibrerias.Margin = new Padding(5, 0, 5, 0);
            lblLibrerias.Name = "lblLibrerias";
            lblLibrerias.Size = new Size(109, 35);
            lblLibrerias.TabIndex = 0;
            lblLibrerias.Text = "Librerías";
            // 
            // lstClases
            // 
            lstClases.FormattingEnabled = true;
            lstClases.Location = new Point(51, 84);
            lstClases.Name = "lstClases";
            lstClases.Size = new Size(831, 319);
            lstClases.TabIndex = 1;
            // 
            // btnPersona
            // 
            btnPersona.Location = new Point(51, 436);
            btnPersona.Name = "btnPersona";
            btnPersona.Size = new Size(257, 69);
            btnPersona.TabIndex = 2;
            btnPersona.Text = "Persona";
            btnPersona.UseVisualStyleBackColor = true;
            btnPersona.Click += btnPersona_Click;
            // 
            // btnEmpleado
            // 
            btnEmpleado.Location = new Point(447, 437);
            btnEmpleado.Name = "btnEmpleado";
            btnEmpleado.Size = new Size(183, 68);
            btnEmpleado.TabIndex = 3;
            btnEmpleado.Text = "Empleado";
            btnEmpleado.UseVisualStyleBackColor = true;
            btnEmpleado.Click += btnEmpleado_Click;
            // 
            // Form20TestClases
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(btnEmpleado);
            Controls.Add(btnPersona);
            Controls.Add(lstClases);
            Controls.Add(lblLibrerias);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form20TestClases";
            Text = "Form20TestClases";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLibrerias;
        private ListBox lstClases;
        private Button btnPersona;
        private Button btnEmpleado;
    }
}