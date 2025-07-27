namespace AdoNetCore
{
    partial class Form10UpdateEmpleadosOficios
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
            lblOficios = new Label();
            lstOficios = new ListBox();
            lstEmpleados = new ListBox();
            lblEmpleados = new Label();
            lblIncremento = new Label();
            txtIncremento = new TextBox();
            btnIncrementarSalarios = new Button();
            lblSumaSalarial = new Label();
            lblMediaSalarial = new Label();
            lblMaximoSalario = new Label();
            lblOficio = new Label();
            txtOficio = new TextBox();
            SuspendLayout();
            // 
            // lblOficios
            // 
            lblOficios.AutoSize = true;
            lblOficios.Location = new Point(30, 18);
            lblOficios.Name = "lblOficios";
            lblOficios.Size = new Size(92, 35);
            lblOficios.TabIndex = 0;
            lblOficios.Text = "Oficios";
            // 
            // lstOficios
            // 
            lstOficios.FormattingEnabled = true;
            lstOficios.Location = new Point(30, 75);
            lstOficios.Name = "lstOficios";
            lstOficios.Size = new Size(228, 249);
            lstOficios.TabIndex = 1;
            lstOficios.SelectedIndexChanged += lstOficios_SelectedIndexChanged;
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(367, 75);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(228, 249);
            lstEmpleados.TabIndex = 3;
            // 
            // lblEmpleados
            // 
            lblEmpleados.AutoSize = true;
            lblEmpleados.Location = new Point(367, 18);
            lblEmpleados.Name = "lblEmpleados";
            lblEmpleados.Size = new Size(138, 35);
            lblEmpleados.TabIndex = 2;
            lblEmpleados.Text = "Empleados";
            // 
            // lblIncremento
            // 
            lblIncremento.AutoSize = true;
            lblIncremento.Location = new Point(734, 138);
            lblIncremento.Name = "lblIncremento";
            lblIncremento.Size = new Size(142, 35);
            lblIncremento.TabIndex = 4;
            lblIncremento.Text = "Incremento";
            // 
            // txtIncremento
            // 
            txtIncremento.Location = new Point(734, 201);
            txtIncremento.Name = "txtIncremento";
            txtIncremento.Size = new Size(182, 41);
            txtIncremento.TabIndex = 5;
            // 
            // btnIncrementarSalarios
            // 
            btnIncrementarSalarios.Location = new Point(734, 280);
            btnIncrementarSalarios.Name = "btnIncrementarSalarios";
            btnIncrementarSalarios.Size = new Size(182, 88);
            btnIncrementarSalarios.TabIndex = 6;
            btnIncrementarSalarios.Text = "Incrementar salarios";
            btnIncrementarSalarios.UseVisualStyleBackColor = true;
            btnIncrementarSalarios.Click += btnIncrementarSalarios_Click;
            // 
            // lblSumaSalarial
            // 
            lblSumaSalarial.AutoSize = true;
            lblSumaSalarial.Location = new Point(30, 373);
            lblSumaSalarial.Name = "lblSumaSalarial";
            lblSumaSalarial.Size = new Size(183, 35);
            lblSumaSalarial.TabIndex = 7;
            lblSumaSalarial.Text = "lblSumaSalarial";
            // 
            // lblMediaSalarial
            // 
            lblMediaSalarial.AutoSize = true;
            lblMediaSalarial.Location = new Point(30, 433);
            lblMediaSalarial.Name = "lblMediaSalarial";
            lblMediaSalarial.Size = new Size(190, 35);
            lblMediaSalarial.TabIndex = 8;
            lblMediaSalarial.Text = "lblMediaSalarial";
            // 
            // lblMaximoSalario
            // 
            lblMaximoSalario.AutoSize = true;
            lblMaximoSalario.Location = new Point(30, 495);
            lblMaximoSalario.Name = "lblMaximoSalario";
            lblMaximoSalario.Size = new Size(206, 35);
            lblMaximoSalario.TabIndex = 9;
            lblMaximoSalario.Text = "lblMaximoSalario";
            // 
            // lblOficio
            // 
            lblOficio.AutoSize = true;
            lblOficio.Location = new Point(734, 18);
            lblOficio.Name = "lblOficio";
            lblOficio.Size = new Size(81, 35);
            lblOficio.TabIndex = 10;
            lblOficio.Text = "Oficio";
            // 
            // txtOficio
            // 
            txtOficio.Location = new Point(734, 75);
            txtOficio.Name = "txtOficio";
            txtOficio.Size = new Size(182, 41);
            txtOficio.TabIndex = 11;
            // 
            // Form10UpdateEmpleadosOficios
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(txtOficio);
            Controls.Add(lblOficio);
            Controls.Add(lblMaximoSalario);
            Controls.Add(lblMediaSalarial);
            Controls.Add(lblSumaSalarial);
            Controls.Add(btnIncrementarSalarios);
            Controls.Add(txtIncremento);
            Controls.Add(lblIncremento);
            Controls.Add(lstEmpleados);
            Controls.Add(lblEmpleados);
            Controls.Add(lstOficios);
            Controls.Add(lblOficios);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form10UpdateEmpleadosOficios";
            Text = "Form10UpdateEmpleadosOficios";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOficios;
        private ListBox lstOficios;
        private ListBox lstEmpleados;
        private Label lblEmpleados;
        private Label lblIncremento;
        private TextBox txtIncremento;
        private Button btnIncrementarSalarios;
        private Label lblSumaSalarial;
        private Label lblMediaSalarial;
        private Label lblMaximoSalario;
        private Label lblOficio;
        private TextBox txtOficio;
    }
}