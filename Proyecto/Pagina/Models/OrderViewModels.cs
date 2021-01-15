using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina.Models
{
    public class OrderViewModels
    {
        public ApplicationUser Usuario { get; set; }
        public Pedido Pedido { get; set; }
        public ICollection<ApplicationUser> Usuarios { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}