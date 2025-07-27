using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaAdo.Models
{
    public class ClienteYPedido
    {
        public Cliente Cliente { get; set; }
        public List<Pedido> Pedido { get; set; }
    }
}
