using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        
        public int TipoID { get; set; }
        [ForeignKey("TipoID")]
        [DisplayName("Tipo")]
        public Tipo Tipo { get; set; }

        
        public int GemaID { get; set; }
        [ForeignKey("GemaID")]
        [DisplayName("Gema")]
        public Gema Gema { get; set; }

        [Display(Name = "Precio")]
        public double Precio { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
        public ICollection<Gema> Gemas { get; set; }
    }
}