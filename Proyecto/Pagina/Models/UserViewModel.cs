using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina.Models
{
    public class UserViewModel
    {
        public string ID { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string Role { get; set; }
    }
}