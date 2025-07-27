namespace FundamentosNetCore
{
    partial class Form04DateTime
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
            lblFechaActual = new Label();
            txtFechaActual = new TextBox();
            groupBox1 = new GroupBox();
            btnIncrementar = new Button();
            txtIncremento = new TextBox();
            lblIncremento = new Label();
            rbAnos = new RadioButton();
            rbMes = new RadioButton();
            rbDias = new RadioButton();
            lblNuevaFecha = new Label();
            chkCambiarFormato = new CheckBox();
            txtNuevaFecha = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblFechaActual
            // 
            lblFechaActual.AutoSize = true;
            lblFechaActual.Font = new Font("Segoe UI", 15F);
            lblFechaActual.Location = new Point(32, 20);
            lblFechaActual.Name = "lblFechaActual";
            lblFechaActual.Size = new Size(155, 35);
            lblFechaActual.TabIndex = 0;
            lblFechaActual.Text = "Fecha Actual";
            // 
            // txtFechaActual
            // 
            txtFechaActual.Font = new Font("Segoe UI", 15F);
            txtFechaActual.Location = new Point(32, 74);
            txtFechaActual.Name = "txtFechaActual";
            txtFechaActual.Size = new Size(653, 41);
            txtFechaActual.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnIncrementar);
            groupBox1.Controls.Add(txtIncremento);
            groupBox1.Controls.Add(lblIncremento);
            groupBox1.Controls.Add(rbAnos);
            groupBox1.Controls.Add(rbMes);
            groupBox1.Controls.Add(rbDias);
            groupBox1.Font = new Font("Segoe UI", 15F);
            groupBox1.Location = new Point(37, 180);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(566, 226);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // btnIncrementar
            // 
            btnIncrementar.Location = new Point(321, 155);
            btnIncrementar.Name = "btnIncrementar";
            btnIncrementar.Size = new Size(179, 51);
            btnIncrementar.TabIndex = 5;
            btnIncrementar.Text = "Incrementar";
            btnIncrementar.UseVisualStyleBackColor = true;
            btnIncrementar.Click += btnIncrementar_Click;
            // 
            // txtIncremento
            // 
            txtIncremento.Location = new Point(331, 95);
            txtIncremento.Name = "txtIncremento";
            txtIncremento.Size = new Size(153, 41);
            txtIncremento.TabIndex = 4;
            // 
            // lblIncremento
            // 
            lblIncremento.AutoSize = true;
            lblIncremento.Location = new Point(331, 37);
            lblIncremento.Name = "lblIncremento";
            lblIncremento.Size = new Size(142, 35);
            lblIncremento.TabIndex = 3;
            lblIncremento.Text = "Incremento";
            // 
            // rbAnos
            // 
            rbAnos.AutoSize = true;
            rbAnos.Location = new Point(32, 142);
            rbAnos.Name = "rbAnos";
            rbAnos.Size = new Size(92, 39);
            rbAnos.TabIndex = 2;
            rbAnos.TabStop = true;
            rbAnos.Text = "Años";
            rbAnos.UseVisualStyleBackColor = true;
            // 
            // rbMes
            // 
            rbMes.AutoSize = true;
            rbMes.Location = new Point(32, 97);
            rbMes.Name = "rbMes";
            rbMes.Size = new Size(82, 39);
            rbMes.TabIndex = 1;
            rbMes.TabStop = true;
            rbMes.Text = "Mes";
            rbMes.UseVisualStyleBackColor = true;
            // 
            // rbDias
            // 
            rbDias.AutoSize = true;
            rbDias.Location = new Point(32, 52);
            rbDias.Name = "rbDias";
            rbDias.Size = new Size(84, 39);
            rbDias.TabIndex = 0;
            rbDias.TabStop = true;
            rbDias.Text = "Días";
            rbDias.UseVisualStyleBackColor = true;
            // 
            // lblNuevaFecha
            // 
            lblNuevaFecha.AutoSize = true;
            lblNuevaFecha.Font = new Font("Segoe UI", 15F);
            lblNuevaFecha.Location = new Point(34, 409);
            lblNuevaFecha.Name = "lblNuevaFecha";
            lblNuevaFecha.Size = new Size(153, 35);
            lblNuevaFecha.TabIndex = 3;
            lblNuevaFecha.Text = "Nueva fecha";
            // 
            // chkCambiarFormato
            // 
            chkCambiarFormato.AutoSize = true;
            chkCambiarFormato.Font = new Font("Segoe UI", 15F);
            chkCambiarFormato.Location = new Point(37, 121);
            chkCambiarFormato.Name = "chkCambiarFormato";
            chkCambiarFormato.Size = new Size(294, 39);
            chkCambiarFormato.TabIndex = 4;
            chkCambiarFormato.Text = "Cambiar formato fecha";
            chkCambiarFormato.UseVisualStyleBackColor = true;
            chkCambiarFormato.CheckedChanged += chkCambiarFormato_CheckedChanged;
            // 
            // txtNuevaFecha
            // 
            txtNuevaFecha.Font = new Font("Segoe UI", 15F);
            txtNuevaFecha.Location = new Point(32, 465);
            txtNuevaFecha.Name = "txtNuevaFecha";
            txtNuevaFecha.Size = new Size(642, 41);
            txtNuevaFecha.TabIndex = 5;
            // 
            // Form04DateTime
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(891, 530);
            Controls.Add(txtNuevaFecha);
            Controls.Add(chkCambiarFormato);
            Controls.Add(lblNuevaFecha);
            Controls.Add(groupBox1);
            Controls.Add(txtFechaActual);
            Controls.Add(lblFechaActual);
            Name = "Form04DateTime";
            Text = "Form04DateTime";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFechaActual;
        private TextBox txtFechaActual;
        private GroupBox groupBox1;
        private Button btnIncrementar;
        private TextBox txtIncremento;
        private Label lblIncremento;
        private RadioButton rbAnos;
        private RadioButton rbMes;
        private RadioButton rbDias;
        private Label lblNuevaFecha;
        private CheckBox chkCambiarFormato;
        private TextBox txtNuevaFecha;
    }
}