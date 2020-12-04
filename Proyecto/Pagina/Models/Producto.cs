using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pagina.Models
{
    public class Producto
    {
        public int ID { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Tipo")]
        public int TipoID { get; set; }
        [ForeignKey("TipoID")]
        public Tipo Tipo { get; set; }

        [Display(Name = "Gema")]
        public int GemaID { get; set; }
        [ForeignKey("GemaID")]
        public Gema Gema { get; set; }

        [Display(Name = "Precio")]
        public double Precio { get; set; }
    }
}