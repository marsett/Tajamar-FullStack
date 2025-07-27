using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PracticaAdo.Helpers;
using PracticaAdo.Models;

#region
/*
create procedure SP_ALLCLIENTES
as
	select * from clientes
go

create procedure SP_CLIENTEEMPRESA
(@nombreCliente nvarchar(50))
as
	select * from V_CLIENTES where Empresa = @nombreCliente
go

create view V_CLIENTES
as
	select clientes.CodigoCliente, clientes.Empresa,
	clientes.Contacto, clientes.Cargo, clientes.Ciudad,
	clientes.Telefono, pedidos.CodigoPedido, pedidos.FechaEntrega,
	pedidos.FormaEnvio, pedidos.Importe from clientes
	LEFT JOIN pedidos
	on pedidos.CodigoCliente = clientes.CodigoCliente
go

create procedure SP_PEDIDO
    @codigoPedido nvarchar(50)
as
    select 
        CodigoPedido, 
        CodigoCliente, 
        FechaEntrega, 
        FormaEnvio, 
        Importe
    from pedidos
    where CodigoPedido = @codigoPedido;
go

create procedure SP_ELIMINARPEDIDO
    @codigoPedido nvarchar(50)
as
    delete from pedidos
    where CodigoPedido = @codigoPedido;
go
*/
#endregion

namespace PracticaAdo.Repositories
{
    public class RepositoryPractica
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryPractica()
        {
            string conexion = HelperConfiguration.GetConnectionString();
            this.cn = new SqlConnection(conexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<string>> GetListaClientesAsync()
        {
            string sql = "SP_ALLCLIENTES";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> lista = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string empresa = this.reader["Empresa"].ToString();
                lista.Add(empresa);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return lista;
        }
        public async Task<ClienteYPedido> GetClienteAsync(string nombreCliente)
        {
            string sql = "SP_CLIENTEEMPRESA";
            this.com.Parameters.AddWithValue("@nombreCliente", nombreCliente);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            Cliente cliente = null;
            Pedido pedido = null;
            List<Pedido> listaPedidos = new List<Pedido>();
            ClienteYPedido clp = new ClienteYPedido();
            while(await this.reader.ReadAsync())
            {
                string codigocliente = this.reader["CodigoCliente"].ToString();
                string empresa = this.reader["Empresa"].ToString();
                string contacto = this.reader["Contacto"].ToString();
                string cargo = this.reader["Cargo"].ToString();
                string ciudad = this.reader["Ciudad"].ToString();
                int telefono = int.Parse(this.reader["Telefono"].ToString());
                string codigopedido = this.reader["CodigoPedido"].ToString();

                string fechaentrega = this.reader["FechaEntrega"].ToString();
                string formaenvio = this.reader["FormaEnvio"].ToString();
                int importe = 0;
                int.TryParse(this.reader["Importe"].ToString(), out importe);
                cliente = new Cliente
                {
                    CodigoCliente = codigocliente,
                    Empresa = empresa,
                    Contacto = contacto,
                    Cargo = cargo,
                    Ciudad = ciudad,
                    Telefono = telefono
                };
                pedido = new Pedido
                {
                    CodigoPedido = codigopedido,
                    CodigoCliente = codigocliente,
                    FechaEntrega = fechaentrega,
                    FormaEnvio = formaenvio,
                    Importe = importe
                };
                listaPedidos.Add(pedido);
            }
            await this.reader.CloseAsync();
            clp.Cliente = cliente;
            clp.Pedido = listaPedidos;
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return clp;
        }

        public async Task<Pedido> GetPedidoAsync(string codigoPedido)
        {
            string sql = "SP_PEDIDO";
            this.com.Parameters.AddWithValue("@codigoPedido", codigoPedido);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();

            Pedido pedido = null;
            if (await this.reader.ReadAsync())
            {
                pedido = new Pedido
                {
                    CodigoPedido = this.reader["CodigoPedido"].ToString(),
                    CodigoCliente = this.reader["CodigoCliente"].ToString(),
                    FechaEntrega = this.reader["FechaEntrega"].ToString(),
                    FormaEnvio = this.reader["FormaEnvio"].ToString(),
                    Importe = int.Parse(this.reader["Importe"].ToString())
                };
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return pedido;
        }

        public async Task DeletePedidoAsync(string codigopedido)
        {
            string sql = "SP_ELIMINARPEDIDO";
            this.com.Parameters.AddWithValue("@codigoPedido", codigopedido); ;
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            int afectados = await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            MessageBox.Show("Número de pedidos eliminados: " + afectados);
        }
    }
}
