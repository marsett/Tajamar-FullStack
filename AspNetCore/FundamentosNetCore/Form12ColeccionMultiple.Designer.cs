namespace FundamentosNetCore
{
    partial class Form12ColeccionMultiple
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
            lblIndexSeleccionados = new Label();
            lblItemsSeleccionados = new Label();
            btnBorrarTodo = new Button();
            btnEliminar = new Button();
            btnInsertar = new Button();
            txtNuevoElemento = new TextBox();
            lblNuevoElemento = new Label();
            lstElementos = new ListBox();
            lblElementos = new Label();
            btnSeleccionados = new Button();
            SuspendLayout();
            // 
            // lblIndexSeleccionados
            // 
            lblIndexSeleccionados.AutoSize = true;
            lblIndexSeleccionados.Location = new Point(86, 477);
            lblIndexSeleccionados.Name = "lblIndexSeleccionados";
            lblIndexSeleccionados.Size = new Size(260, 35);
            lblIndexSeleccionados.TabIndex = 17;
            lblIndexSeleccionados.Text = "lblIndexSeleccionados";
            // 
            // lblItemsSeleccionados
            // 
            lblItemsSeleccionados.AutoSize = true;
            lblItemsSeleccionados.Location = new Point(84, 419);
            lblItemsSeleccionados.Name = "lblItemsSeleccionados";
            lblItemsSeleccionados.Size = new Size(261, 35);
            lblItemsSeleccionados.TabIndex = 16;
            lblItemsSeleccionados.Text = "lblItemsSeleccionados";
            // 
            // btnBorrarTodo
            // 
            btnBorrarTodo.Location = new Point(511, 324);
            btnBorrarTodo.Name = "btnBorrarTodo";
            btnBorrarTodo.Size = new Size(199, 72);
            btnBorrarTodo.TabIndex = 15;
            btnBorrarTodo.Text = "Borrar todo";
            btnBorrarTodo.UseVisualStyleBackColor = true;
            btnBorrarTodo.Click += btnBorrarTodo_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.ForeColor = Color.Transparent;
            btnEliminar.Location = new Point(511, 243);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(199, 64);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(511, 155);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(199, 67);
            btnInsertar.TabIndex = 13;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // txtNuevoElemento
            // 
            txtNuevoElemento.Location = new Point(511, 87);
            txtNuevoElemento.Name = "txtNuevoElemento";
            txtNuevoElemento.Size = new Size(347, 41);
            txtNuevoElemento.TabIndex = 12;
            // 
            // lblNuevoElemento
            // 
            lblNuevoElemento.AutoSize = true;
            lblNuevoElemento.Location = new Point(511, 21);
            lblNuevoElemento.Name = "lblNuevoElemento";
            lblNuevoElemento.Size = new Size(199, 35);
            lblNuevoElemento.TabIndex = 11;
            lblNuevoElemento.Text = "Nuevo elemento";
            // 
            // lstElementos
            // 
            lstElementos.FormattingEnabled = true;
            lstElementos.Location = new Point(84, 77);
            lstElementos.Name = "lstElementos";
            lstElementos.Size = new Size(286, 319);
            lstElementos.TabIndex = 10;
            // 
            // lblElementos
            // 
            lblElementos.AutoSize = true;
            lblElementos.Location = new Point(84, 21);
            lblElementos.Margin = new Padding(5, 0, 5, 0);
            lblElementos.Name = "lblElementos";
            lblElementos.Size = new Size(130, 35);
            lblElementos.TabIndex = 9;
            lblElementos.Text = "Elementos";
            // 
            // btnSeleccionados
            // 
            btnSeleccionados.Location = new Point(511, 412);
            btnSeleccionados.Name = "btnSeleccionados";
            btnSeleccionados.Size = new Size(199, 61);
            btnSeleccionados.TabIndex = 18;
            btnSeleccionados.Text = "Seleccionados";
            btnSeleccionados.UseVisualStyleBackColor = true;
            btnSeleccionados.Click += btnSeleccionados_Click;
            // 
            // Form12ColeccionMultiple
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(btnSeleccionados);
            Controls.Add(lblIndexSeleccionados);
            Controls.Add(lblItemsSeleccionados);
            Controls.Add(btnBorrarTodo);
            Controls.Add(btnEliminar);
            Controls.Add(btnInsertar);
            Controls.Add(txtNuevoElemento);
            Controls.Add(lblNuevoElemento);
            Controls.Add(lstElementos);
            Controls.Add(lblElementos);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form12ColeccionMultiple";
            Text = "Form12ColeccionMultiple";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIndexSeleccionados;
        private Label lblItemsSeleccionados;
        private Button btnBorrarTodo;
        private Button btnEliminar;
        private Button btnInsertar;
        private TextBox txtNuevoElemento;
        private Label lblNuevoElemento;
        private ListBox lstElementos;
        private Label lblElementos;
        private Button btnSeleccionados;
    }
}