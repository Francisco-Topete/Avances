using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina.Models
{
    public class ProductoesViewModel
    {
        public Gema Gema { get; set; }
        public Tipo Tipo { get; set; }
        public Producto Producto { get; set; }
        public ICollection<Gema> Gemas { get; set; }
        public ICollection<Tipo> Tipos { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}