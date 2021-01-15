using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina.Models
{
    public class PedidosViewModel
    {
        public Producto Producto { get; set; }
        public Pedido Pedido { get; set; }
        public ApplicationUser Cliente { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
        public ICollection<Producto> Productos { get; set; }
        public List<ApplicationUser> Clientes { get; set; }
    }
}