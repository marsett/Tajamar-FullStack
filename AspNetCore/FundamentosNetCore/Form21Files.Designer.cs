namespace FundamentosNetCore
{
    partial class Form21Files
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
            lblContenidoFile = new Label();
            txtContenido = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            btnNuevoNombre = new Button();
            btnReadFile = new Button();
            btnWriteFile = new Button();
            lblNombres = new Label();
            lstNombres = new ListBox();
            SuspendLayout();
            // 
            // lblContenidoFile
            // 
            lblContenidoFile.AutoSize = true;
            lblContenidoFile.Location = new Point(27, 31);
            lblContenidoFile.Margin = new Padding(5, 0, 5, 0);
            lblContenidoFile.Name = "lblContenidoFile";
            lblContenidoFile.Size = new Size(174, 35);
            lblContenidoFile.TabIndex = 0;
            lblContenidoFile.Text = "Contenido File";
            // 
            // txtContenido
            // 
            txtContenido.Location = new Point(27, 96);
            txtContenido.Multiline = true;
            txtContenido.Name = "txtContenido";
            txtContenido.Size = new Size(311, 322);
            txtContenido.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(405, 31);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(108, 35);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(405, 96);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(208, 41);
            txtNombre.TabIndex = 3;
            // 
            // btnNuevoNombre
            // 
            btnNuevoNombre.Location = new Point(405, 160);
            btnNuevoNombre.Name = "btnNuevoNombre";
            btnNuevoNombre.Size = new Size(208, 82);
            btnNuevoNombre.TabIndex = 4;
            btnNuevoNombre.Text = "Nuevo nombre";
            btnNuevoNombre.UseVisualStyleBackColor = true;
            btnNuevoNombre.Click += btnNuevoNombre_Click;
            // 
            // btnReadFile
            // 
            btnReadFile.Location = new Point(405, 269);
            btnReadFile.Name = "btnReadFile";
            btnReadFile.Size = new Size(208, 63);
            btnReadFile.TabIndex = 5;
            btnReadFile.Text = "Read File";
            btnReadFile.UseVisualStyleBackColor = true;
            btnReadFile.Click += btnReadFile_Click;
            // 
            // btnWriteFile
            // 
            btnWriteFile.Location = new Point(405, 357);
            btnWriteFile.Name = "btnWriteFile";
            btnWriteFile.Size = new Size(208, 61);
            btnWriteFile.TabIndex = 6;
            btnWriteFile.Text = "Write File";
            btnWriteFile.UseVisualStyleBackColor = true;
            btnWriteFile.Click += btnWriteFile_Click;
            // 
            // lblNombres
            // 
            lblNombres.AutoSize = true;
            lblNombres.Location = new Point(664, 31);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(119, 35);
            lblNombres.TabIndex = 7;
            lblNombres.Text = "Nombres";
            // 
            // lstNombres
            // 
            lstNombres.FormattingEnabled = true;
            lstNombres.Location = new Point(664, 96);
            lstNombres.Name = "lstNombres";
            lstNombres.Size = new Size(238, 319);
            lstNombres.TabIndex = 8;
            // 
            // Form21Files
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(lstNombres);
            Controls.Add(lblNombres);
            Controls.Add(btnWriteFile);
            Controls.Add(btnReadFile);
            Controls.Add(btnNuevoNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtContenido);
            Controls.Add(lblContenidoFile);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form21Files";
            Text = "Form21Files";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblContenidoFile;
        private TextBox txtContenido;
        private Label lblNombre;
        private TextBox txtNombre;
        private Button btnNuevoNombre;
        private Button btnReadFile;
        private Button btnWriteFile;
        private Label lblNombres;
        private ListBox lstNombres;
    }
}