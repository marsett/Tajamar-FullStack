namespace FundamentosNetCore
{
    partial class Form14TiendaProductos
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
            lblProducto = new Label();
            txtProducto = new TextBox();
            btnNuevo = new Button();
            btnEliminar = new Button();
            btnBorrarTodo = new Button();
            lblTienda = new Label();
            lstProductos = new ListBox();
            btnSeleccion = new Button();
            btnTodos = new Button();
            lblAlmacen = new Label();
            lstAlmacen = new ListBox();
            btnSubir = new Button();
            btnBajar = new Button();
            SuspendLayout();
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(35, 29);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(117, 35);
            lblProducto.TabIndex = 0;
            lblProducto.Text = "Producto";
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(35, 86);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(175, 41);
            txtProducto.TabIndex = 1;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(35, 156);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(175, 52);
            btnNuevo.TabIndex = 2;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(35, 236);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(175, 52);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnBorrarTodo
            // 
            btnBorrarTodo.Location = new Point(35, 314);
            btnBorrarTodo.Name = "btnBorrarTodo";
            btnBorrarTodo.Size = new Size(175, 52);
            btnBorrarTodo.TabIndex = 4;
            btnBorrarTodo.Text = "Borrar todo";
            btnBorrarTodo.UseVisualStyleBackColor = true;
            btnBorrarTodo.Click += btnBorrarTodo_Click;
            // 
            // lblTienda
            // 
            lblTienda.AutoSize = true;
            lblTienda.Location = new Point(301, 29);
            lblTienda.Name = "lblTienda";
            lblTienda.Size = new Size(89, 35);
            lblTienda.TabIndex = 5;
            lblTienda.Text = "Tienda";
            // 
            // lstProductos
            // 
            lstProductos.FormattingEnabled = true;
            lstProductos.Location = new Point(301, 86);
            lstProductos.Name = "lstProductos";
            lstProductos.Size = new Size(212, 389);
            lstProductos.TabIndex = 6;
            // 
            // btnSeleccion
            // 
            btnSeleccion.Location = new Point(548, 202);
            btnSeleccion.Name = "btnSeleccion";
            btnSeleccion.Size = new Size(175, 52);
            btnSeleccion.TabIndex = 7;
            btnSeleccion.Text = "Selección";
            btnSeleccion.UseVisualStyleBackColor = true;
            btnSeleccion.Click += btnSeleccion_Click;
            // 
            // btnTodos
            // 
            btnTodos.Location = new Point(548, 280);
            btnTodos.Name = "btnTodos";
            btnTodos.Size = new Size(175, 52);
            btnTodos.TabIndex = 8;
            btnTodos.Text = "Todos";
            btnTodos.UseVisualStyleBackColor = true;
            btnTodos.Click += btnTodos_Click;
            // 
            // lblAlmacen
            // 
            lblAlmacen.AutoSize = true;
            lblAlmacen.Location = new Point(764, 29);
            lblAlmacen.Name = "lblAlmacen";
            lblAlmacen.Size = new Size(111, 35);
            lblAlmacen.TabIndex = 9;
            lblAlmacen.Text = "Almacén";
            // 
            // lstAlmacen
            // 
            lstAlmacen.FormattingEnabled = true;
            lstAlmacen.Location = new Point(764, 86);
            lstAlmacen.Name = "lstAlmacen";
            lstAlmacen.Size = new Size(212, 389);
            lstAlmacen.TabIndex = 10;
            lstAlmacen.SelectedIndexChanged += lstAlmacen_SelectedIndexChanged;
            // 
            // btnSubir
            // 
            btnSubir.Location = new Point(1015, 202);
            btnSubir.Name = "btnSubir";
            btnSubir.Size = new Size(175, 52);
            btnSubir.TabIndex = 11;
            btnSubir.Text = "Subir";
            btnSubir.UseVisualStyleBackColor = true;
            btnSubir.Click += btnSubir_Click;
            // 
            // btnBajar
            // 
            btnBajar.Location = new Point(1015, 280);
            btnBajar.Name = "btnBajar";
            btnBajar.Size = new Size(175, 52);
            btnBajar.TabIndex = 12;
            btnBajar.Text = "Bajar";
            btnBajar.UseVisualStyleBackColor = true;
            btnBajar.Click += btnBajar_Click;
            // 
            // Form14TiendaProductos
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(btnBajar);
            Controls.Add(btnSubir);
            Controls.Add(lstAlmacen);
            Controls.Add(lblAlmacen);
            Controls.Add(btnTodos);
            Controls.Add(btnSeleccion);
            Controls.Add(lstProductos);
            Controls.Add(lblTienda);
            Controls.Add(btnBorrarTodo);
            Controls.Add(btnEliminar);
            Controls.Add(btnNuevo);
            Controls.Add(txtProducto);
            Controls.Add(lblProducto);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form14TiendaProductos";
            Text = "Form14TiendaProductos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProducto;
        private TextBox txtProducto;
        private Button btnNuevo;
        private Button btnEliminar;
        private Button btnBorrarTodo;
        private Label lblTienda;
        private ListBox lstProductos;
        private Button btnSeleccion;
        private Button btnTodos;
        private Label lblAlmacen;
        private ListBox lstAlmacen;
        private Button btnSubir;
        private Button btnBajar;
    }
}