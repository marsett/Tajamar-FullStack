namespace AdoNetCore
{
    partial class Form04EliminarPlantilla
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
            label1 = new Label();
            txtIdEmpleado = new TextBox();
            btnEliminarPlantilla = new Button();
            lblPlantilla = new Label();
            lstPlantilla = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 55);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(156, 35);
            label1.TabIndex = 0;
            label1.Text = "Id Empleado";
            // 
            // txtIdEmpleado
            // 
            txtIdEmpleado.Location = new Point(69, 118);
            txtIdEmpleado.Name = "txtIdEmpleado";
            txtIdEmpleado.Size = new Size(218, 41);
            txtIdEmpleado.TabIndex = 1;
            // 
            // btnEliminarPlantilla
            // 
            btnEliminarPlantilla.Location = new Point(69, 191);
            btnEliminarPlantilla.Name = "btnEliminarPlantilla";
            btnEliminarPlantilla.Size = new Size(218, 54);
            btnEliminarPlantilla.TabIndex = 2;
            btnEliminarPlantilla.Text = "Eliminar Plantilla";
            btnEliminarPlantilla.UseVisualStyleBackColor = true;
            btnEliminarPlantilla.Click += btnEliminarPlantilla_Click;
            // 
            // lblPlantilla
            // 
            lblPlantilla.AutoSize = true;
            lblPlantilla.Location = new Point(418, 55);
            lblPlantilla.Name = "lblPlantilla";
            lblPlantilla.Size = new Size(101, 35);
            lblPlantilla.TabIndex = 3;
            lblPlantilla.Text = "Plantilla";
            // 
            // lstPlantilla
            // 
            lstPlantilla.FormattingEnabled = true;
            lstPlantilla.Location = new Point(418, 118);
            lstPlantilla.Name = "lstPlantilla";
            lstPlantilla.Size = new Size(244, 249);
            lstPlantilla.TabIndex = 4;
            // 
            // Form04EliminarPlantilla
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(lstPlantilla);
            Controls.Add(lblPlantilla);
            Controls.Add(btnEliminarPlantilla);
            Controls.Add(txtIdEmpleado);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form04EliminarPlantilla";
            Text = "Form04EliminarPlantilla";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIdEmpleado;
        private Button btnEliminarPlantilla;
        private Label lblPlantilla;
        private ListBox lstPlantilla;
    }
}