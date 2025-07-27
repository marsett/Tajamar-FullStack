using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FundamentosNetCore
{
    public partial class Form14TiendaProductos : Form
    {
        public Form14TiendaProductos()
        {
            InitializeComponent();
            this.lstProductos.SelectionMode = SelectionMode.MultiExtended;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string producto = txtProducto.Text.ToUpper();
            if (this.lstProductos.Items.Contains(producto))
            {
                MessageBox.Show("Ya existe ese producto en la Tienda", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtProducto.Text = "";
                this.txtProducto.Focus();
            }
            else
            {
                this.lstProductos.Items.Add(producto);
                this.txtProducto.Text = "";
                this.txtProducto.Focus();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int productosSeleccionados = this.lstProductos.SelectedIndices.Count;
            for (int i = productosSeleccionados - 1; i >= 0; i--)
            {
                int index = this.lstProductos.SelectedIndices[i];
                this.lstProductos.Items.RemoveAt(index);
            }
        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            this.lstProductos.Items.Clear();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            var seleccionados = new List<string>();
            foreach (string producto in this.lstProductos.SelectedItems)
            {
                seleccionados.Add(producto);
            }
            foreach (string producto in seleccionados)
            {
                this.lstProductos.Items.Remove(producto);
                this.lstAlmacen.Items.Add(producto);
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            foreach (string producto in this.lstProductos.Items)
            {
                this.lstAlmacen.Items.Add(producto);
            }
            this.lstProductos.Items.Clear();
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            if (lstAlmacen.SelectedIndex > 0)
            {
                int index = lstAlmacen.SelectedIndex;
                string productoSeleccionado = lstAlmacen.SelectedItem.ToString();

                lstAlmacen.Items.RemoveAt(index);
                lstAlmacen.Items.Insert(index - 1, productoSeleccionado);

                lstAlmacen.SelectedIndex = index - 1;
            }
        }

        private void btnBajar_Click(object sender, EventArgs e)
        {
            if (lstAlmacen.SelectedIndex > 0)
            {
                int index = lstAlmacen.SelectedIndex;
                string productoSeleccionado = lstAlmacen.SelectedItem.ToString();

                lstAlmacen.Items.RemoveAt(index);
                lstAlmacen.Items.Insert(index + 1, productoSeleccionado);

                lstAlmacen.SelectedIndex = index + 1;
            }
        }

        private void lstAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.lstAlmacen.SelectedIndex;
            if (index == 0)
            {
                this.btnSubir.Enabled = false;
            }
            else
            {
                this.btnSubir.Enabled = true;
            }
            if (index == this.lstAlmacen.Items.Count - 1)
            {
                this.btnBajar.Enabled = false;
            }
            else
            {
                this.btnSubir.Enabled = true;
            }
        }
    }
}
