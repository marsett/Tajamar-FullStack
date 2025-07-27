namespace FundamentosNetCore
{
    partial class Form03DiaNacimiento
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
            lblDia = new Label();
            txtDia = new TextBox();
            lblMes = new Label();
            txtMes = new TextBox();
            lblAno = new Label();
            txtAno = new TextBox();
            btnCalcularDia = new Button();
            lblDiaSemana = new Label();
            SuspendLayout();
            // 
            // lblDia
            // 
            lblDia.AutoSize = true;
            lblDia.Font = new Font("Segoe UI", 15F);
            lblDia.Location = new Point(37, 26);
            lblDia.Name = "lblDia";
            lblDia.Size = new Size(52, 35);
            lblDia.TabIndex = 0;
            lblDia.Text = "Día";
            // 
            // txtDia
            // 
            txtDia.Font = new Font("Segoe UI", 15F);
            txtDia.Location = new Point(40, 82);
            txtDia.Name = "txtDia";
            txtDia.Size = new Size(125, 41);
            txtDia.TabIndex = 1;
            // 
            // lblMes
            // 
            lblMes.AutoSize = true;
            lblMes.Font = new Font("Segoe UI", 15F);
            lblMes.Location = new Point(37, 135);
            lblMes.Name = "lblMes";
            lblMes.Size = new Size(61, 35);
            lblMes.TabIndex = 2;
            lblMes.Text = "Mes";
            // 
            // txtMes
            // 
            txtMes.Font = new Font("Segoe UI", 15F);
            txtMes.Location = new Point(40, 191);
            txtMes.Name = "txtMes";
            txtMes.Size = new Size(125, 41);
            txtMes.TabIndex = 3;
            // 
            // lblAno
            // 
            lblAno.AutoSize = true;
            lblAno.Font = new Font("Segoe UI", 15F);
            lblAno.Location = new Point(41, 251);
            lblAno.Name = "lblAno";
            lblAno.Size = new Size(60, 35);
            lblAno.TabIndex = 4;
            lblAno.Text = "Año";
            // 
            // txtAno
            // 
            txtAno.Font = new Font("Segoe UI", 15F);
            txtAno.Location = new Point(39, 311);
            txtAno.Name = "txtAno";
            txtAno.Size = new Size(125, 41);
            txtAno.TabIndex = 5;
            // 
            // btnCalcularDia
            // 
            btnCalcularDia.Font = new Font("Segoe UI", 15F);
            btnCalcularDia.Location = new Point(346, 66);
            btnCalcularDia.Name = "btnCalcularDia";
            btnCalcularDia.Size = new Size(208, 113);
            btnCalcularDia.TabIndex = 6;
            btnCalcularDia.Text = "Calcular día de nacimiento";
            btnCalcularDia.UseVisualStyleBackColor = true;
            btnCalcularDia.Click += btnCalcularDia_Click;
            // 
            // lblDiaSemana
            // 
            lblDiaSemana.AutoSize = true;
            lblDiaSemana.Font = new Font("Segoe UI", 15F);
            lblDiaSemana.Location = new Point(350, 244);
            lblDiaSemana.Name = "lblDiaSemana";
            lblDiaSemana.Size = new Size(167, 35);
            lblDiaSemana.TabIndex = 7;
            lblDiaSemana.Text = "lblDiaSemana";
            // 
            // Form03DiaNacimiento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblDiaSemana);
            Controls.Add(btnCalcularDia);
            Controls.Add(txtAno);
            Controls.Add(lblAno);
            Controls.Add(txtMes);
            Controls.Add(lblMes);
            Controls.Add(txtDia);
            Controls.Add(lblDia);
            Name = "Form03DiaNacimiento";
            Text = "Form03DiaNacimiento";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDia;
        private TextBox txtDia;
        private Label lblMes;
        private TextBox txtMes;
        private Label lblAno;
        private TextBox txtAno;
        private Button btnCalcularDia;
        private Label lblDiaSemana;
    }
}