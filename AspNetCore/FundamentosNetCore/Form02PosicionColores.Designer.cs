namespace FundamentosNetCore
{
    partial class Form02PosicionColores
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
            lblPosicionX = new Label();
            lblPosicionY = new Label();
            btnCambiarPosicion = new Button();
            txtPosicionX = new TextBox();
            txtPosicionY = new TextBox();
            lblRojo = new Label();
            lblVerde = new Label();
            lblAzul = new Label();
            txtRojo = new TextBox();
            txtVerde = new TextBox();
            txtAzul = new TextBox();
            btnCambiarColor = new Button();
            SuspendLayout();
            // 
            // lblPosicionX
            // 
            lblPosicionX.AutoSize = true;
            lblPosicionX.Font = new Font("Segoe UI", 15F);
            lblPosicionX.Location = new Point(48, 38);
            lblPosicionX.Name = "lblPosicionX";
            lblPosicionX.Size = new Size(134, 35);
            lblPosicionX.TabIndex = 0;
            lblPosicionX.Text = "Posición X:";
            // 
            // lblPosicionY
            // 
            lblPosicionY.AutoSize = true;
            lblPosicionY.Font = new Font("Segoe UI", 15F);
            lblPosicionY.Location = new Point(48, 98);
            lblPosicionY.Name = "lblPosicionY";
            lblPosicionY.Size = new Size(133, 35);
            lblPosicionY.TabIndex = 1;
            lblPosicionY.Text = "Posición Y:";
            // 
            // btnCambiarPosicion
            // 
            btnCambiarPosicion.Font = new Font("Segoe UI", 12F);
            btnCambiarPosicion.Location = new Point(48, 178);
            btnCambiarPosicion.Name = "btnCambiarPosicion";
            btnCambiarPosicion.Size = new Size(233, 60);
            btnCambiarPosicion.TabIndex = 2;
            btnCambiarPosicion.Text = "Cambiar Posición";
            btnCambiarPosicion.UseVisualStyleBackColor = true;
            btnCambiarPosicion.Click += btnCambiarPosicion_Click;
            // 
            // txtPosicionX
            // 
            txtPosicionX.Location = new Point(200, 46);
            txtPosicionX.Name = "txtPosicionX";
            txtPosicionX.Size = new Size(125, 27);
            txtPosicionX.TabIndex = 3;
            // 
            // txtPosicionY
            // 
            txtPosicionY.Location = new Point(200, 106);
            txtPosicionY.Name = "txtPosicionY";
            txtPosicionY.Size = new Size(125, 27);
            txtPosicionY.TabIndex = 4;
            // 
            // lblRojo
            // 
            lblRojo.AutoSize = true;
            lblRojo.Font = new Font("Segoe UI", 15F);
            lblRojo.Location = new Point(467, 38);
            lblRojo.Name = "lblRojo";
            lblRojo.Size = new Size(65, 35);
            lblRojo.TabIndex = 5;
            lblRojo.Text = "Rojo";
            // 
            // lblVerde
            // 
            lblVerde.AutoSize = true;
            lblVerde.Font = new Font("Segoe UI", 15F);
            lblVerde.Location = new Point(467, 97);
            lblVerde.Name = "lblVerde";
            lblVerde.Size = new Size(79, 35);
            lblVerde.TabIndex = 6;
            lblVerde.Text = "Verde";
            // 
            // lblAzul
            // 
            lblAzul.AutoSize = true;
            lblAzul.Font = new Font("Segoe UI", 15F);
            lblAzul.Location = new Point(467, 161);
            lblAzul.Name = "lblAzul";
            lblAzul.Size = new Size(62, 35);
            lblAzul.TabIndex = 7;
            lblAzul.Text = "Azul";
            // 
            // txtRojo
            // 
            txtRojo.Location = new Point(581, 46);
            txtRojo.Name = "txtRojo";
            txtRojo.Size = new Size(125, 27);
            txtRojo.TabIndex = 8;
            // 
            // txtVerde
            // 
            txtVerde.Location = new Point(581, 107);
            txtVerde.Name = "txtVerde";
            txtVerde.Size = new Size(125, 27);
            txtVerde.TabIndex = 9;
            // 
            // txtAzul
            // 
            txtAzul.Location = new Point(581, 170);
            txtAzul.Name = "txtAzul";
            txtAzul.Size = new Size(125, 27);
            txtAzul.TabIndex = 10;
            // 
            // btnCambiarColor
            // 
            btnCambiarColor.Font = new Font("Segoe UI", 12F);
            btnCambiarColor.Location = new Point(467, 258);
            btnCambiarColor.Name = "btnCambiarColor";
            btnCambiarColor.Size = new Size(202, 65);
            btnCambiarColor.TabIndex = 11;
            btnCambiarColor.Text = "Cambiar Color";
            btnCambiarColor.UseVisualStyleBackColor = true;
            btnCambiarColor.Click += btnCambiarColor_Click;
            // 
            // Form02PosicionColores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCambiarColor);
            Controls.Add(txtAzul);
            Controls.Add(txtVerde);
            Controls.Add(txtRojo);
            Controls.Add(lblAzul);
            Controls.Add(lblVerde);
            Controls.Add(lblRojo);
            Controls.Add(txtPosicionY);
            Controls.Add(txtPosicionX);
            Controls.Add(btnCambiarPosicion);
            Controls.Add(lblPosicionY);
            Controls.Add(lblPosicionX);
            Name = "Form02PosicionColores";
            Text = "Form02PosicionColores";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPosicionX;
        private Label lblPosicionY;
        private Button btnCambiarPosicion;
        private TextBox txtPosicionX;
        private TextBox txtPosicionY;
        private Label lblRojo;
        private Label lblVerde;
        private Label lblAzul;
        private TextBox txtRojo;
        private TextBox txtVerde;
        private TextBox txtAzul;
        private Button btnCambiarColor;
    }
}