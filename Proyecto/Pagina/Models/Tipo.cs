using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pagina.Models
{
    public class Tipo
    {
        public int ID { get; set; }
        [Required]
        [Display(Name="Nombre")]
        public string Nombre { get; set; }
    }
}