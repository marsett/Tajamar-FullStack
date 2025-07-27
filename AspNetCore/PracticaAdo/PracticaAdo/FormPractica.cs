using PracticaAdo.Models;
using PracticaAdo.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class FormPractica : Form
    {
        private RepositoryPractica repo;
        public FormPractica()
        {
            InitializeComponent();
            this.repo = new RepositoryPractica();
            this.CargarClientes();
        }

        public async Task CargarClientes()
        {
            List<string> nombres = await this.repo.GetListaClientesAsync();
            this.cmbclientes.Items.Clear();
            foreach (string nombre in nombres)
            {
                this.cmbclientes.Items.Add(nombre);
            }
        }

        private async Task CargarClientes(string nombreSeleccionado)
        {
            this.txtempresa.Clear();
            this.txtcontacto.Clear();
            this.txtcargo.Clear();
            this.txtciudad.Clear();
            this.txttelefono.Clear();
            this.lstpedidos.Items.Clear();
            ClienteYPedido clp = await this.repo.GetClienteAsync(nombreSeleccionado);
            this.txtempresa.Text = clp.Cliente.Empresa.ToString();
            this.txtcontacto.Text = clp.Cliente.Contacto.ToString();
            this.txtcargo.Text = clp.Cliente.Cargo.ToString();
            this.txtciudad.Text = clp.Cliente.Ciudad.ToString();
            this.txttelefono.Text = clp.Cliente.Telefono.ToString();
            foreach (Pedido ped in clp.Pedido)
            {
                this.lstpedidos.Items.Add(ped.CodigoPedido);
            }
        }

        private async void cmbclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbclientes.SelectedIndex != -1)
            {
                string nombreSeleccionado = this.cmbclientes.SelectedItem.ToString();
                await this.CargarClientes(nombreSeleccionado);
            }
        }

        private async Task CargarPedidos(string codigoPedido)
        {

            this.txtcodigopedido.Clear();
            this.txtfechaentrega.Clear();
            this.txtformaenvio.Clear();
            this.txtimporte.Clear();
            Pedido pedido = await this.repo.GetPedidoAsync(codigoPedido);

            this.txtcodigopedido.Text = pedido.CodigoPedido.ToString();
            this.txtfechaentrega.Text = pedido.FechaEntrega.ToString();
            this.txtformaenvio.Text = pedido.FormaEnvio.ToString();
            this.txtimporte.Text = pedido.Importe.ToString();

        }

        private async void lstpedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstpedidos.SelectedIndex != -1)
            {
                string codigoPedidoSeleccionado = this.lstpedidos.SelectedItem.ToString();
                await this.CargarPedidos(codigoPedidoSeleccionado);
            }
        }

        private async void btneliminarpedido_Click(object sender, EventArgs e)
        {
            string codigoPedidoSeleccionado = this.lstpedidos.SelectedItem.ToString();
            await this.repo.DeletePedidoAsync(codigoPedidoSeleccionado);
            string nombreSeleccionado = this.cmbclientes.SelectedItem.ToString();
            await this.CargarClientes(nombreSeleccionado);
            this.txtcodigopedido.Clear();
            this.txtfechaentrega.Clear();
            this.txtformaenvio.Clear();
            this.txtimporte.Clear();
        }
    }
}
