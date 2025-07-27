namespace AdoNetCore
{
    partial class Form01PrimerAdo
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
            btnConectar = new Button();
            btnDesconectar = new Button();
            btnLeerDatos = new Button();
            lblApellidos = new Label();
            lstApellidos = new ListBox();
            lstColumnas = new ListBox();
            lblColumnas = new Label();
            lstTiposDato = new ListBox();
            lblTiposDato = new Label();
            lblMensaje = new Label();
            SuspendLayout();
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(39, 50);
            btnConectar.Margin = new Padding(5);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(180, 67);
            btnConectar.TabIndex = 0;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // btnDesconectar
            // 
            btnDesconectar.Location = new Point(39, 142);
            btnDesconectar.Margin = new Padding(5);
            btnDesconectar.Name = "btnDesconectar";
            btnDesconectar.Size = new Size(180, 67);
            btnDesconectar.TabIndex = 1;
            btnDesconectar.Text = "Desconectar";
            btnDesconectar.UseVisualStyleBackColor = true;
            btnDesconectar.Click += btnDesconectar_Click;
            // 
            // btnLeerDatos
            // 
            btnLeerDatos.Location = new Point(39, 230);
            btnLeerDatos.Margin = new Padding(5);
            btnLeerDatos.Name = "btnLeerDatos";
            btnLeerDatos.Size = new Size(180, 67);
            btnLeerDatos.TabIndex = 2;
            btnLeerDatos.Text = "Leer datos";
            btnLeerDatos.UseVisualStyleBackColor = true;
            btnLeerDatos.Click += btnLeerDatos_Click;
            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Location = new Point(291, 50);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(118, 35);
            lblApellidos.TabIndex = 3;
            lblApellidos.Text = "Apellidos";
            // 
            // lstApellidos
            // 
            lstApellidos.FormattingEnabled = true;
            lstApellidos.Location = new Point(291, 111);
            lstApellidos.Name = "lstApellidos";
            lstApellidos.Size = new Size(244, 319);
            lstApellidos.TabIndex = 4;
            // 
            // lstColumnas
            // 
            lstColumnas.FormattingEnabled = true;
            lstColumnas.Location = new Point(577, 111);
            lstColumnas.Name = "lstColumnas";
            lstColumnas.Size = new Size(244, 319);
            lstColumnas.TabIndex = 6;
            // 
            // lblColumnas
            // 
            lblColumnas.AutoSize = true;
            lblColumnas.Location = new Point(577, 50);
            lblColumnas.Name = "lblColumnas";
            lblColumnas.Size = new Size(125, 35);
            lblColumnas.TabIndex = 5;
            lblColumnas.Text = "Columnas";
            // 
            // lstTiposDato
            // 
            lstTiposDato.FormattingEnabled = true;
            lstTiposDato.Location = new Point(854, 111);
            lstTiposDato.Name = "lstTiposDato";
            lstTiposDato.Size = new Size(244, 319);
            lstTiposDato.TabIndex = 8;
            // 
            // lblTiposDato
            // 
            lblTiposDato.AutoSize = true;
            lblTiposDato.Location = new Point(854, 50);
            lblTiposDato.Name = "lblTiposDato";
            lblTiposDato.Size = new Size(136, 35);
            lblTiposDato.TabIndex = 7;
            lblTiposDato.Text = "Tipos Dato";
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Location = new Point(39, 445);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(134, 35);
            lblMensaje.TabIndex = 9;
            lblMensaje.Text = "lblMensaje";
            // 
            // Form01PrimerAdo
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(lblMensaje);
            Controls.Add(lstTiposDato);
            Controls.Add(lblTiposDato);
            Controls.Add(lstColumnas);
            Controls.Add(lblColumnas);
            Controls.Add(lstApellidos);
            Controls.Add(lblApellidos);
            Controls.Add(btnLeerDatos);
            Controls.Add(btnDesconectar);
            Controls.Add(btnConectar);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form01PrimerAdo";
            Text = "Form01PrimerAdo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConectar;
        private Button btnDesconectar;
        private Button btnLeerDatos;
        private Label lblApellidos;
        private ListBox lstApellidos;
        private ListBox lstColumnas;
        private Label lblColumnas;
        private ListBox lstTiposDato;
        private Label lblTiposDato;
        private Label lblMensaje;
    }
}