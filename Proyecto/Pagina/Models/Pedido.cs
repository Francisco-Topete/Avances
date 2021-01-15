using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pagina.Models
{
    public class Pedido
    {
        public int ID { get; set; }

        [Display(Name ="Producto")]
        public int ProductoID { get; set; }
        [ForeignKey("ProductoID")]
        [DisplayName("Producto")]
        public Producto Producto { get; set; }

        public string ClienteID { get; set; }
        [ForeignKey("ClienteID")]
        [DisplayName("Cliente")]
        public ApplicationUser Cliente { get; set; }
        public double Total { get; set; }

        public string Estado { get; set; }

        public ICollection<Producto> Productos { get; set; }
        public ICollection<ApplicationUser> Clientes { get; set; }
    }
}