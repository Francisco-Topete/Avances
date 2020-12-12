using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pagina.Models
{
    public class Gema
    {
        public int ID { get; set; }
        [Display(Name = "Gema")]
        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set;}
    }
}