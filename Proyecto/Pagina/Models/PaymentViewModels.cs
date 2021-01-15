using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina.Models
{
    public class PaymentViewModels
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentName { get; set; }

        public string PaymentNumber { get; set; }

        public string PaymentExpDate { get; set; }

        public string PaymentCCV { get; set; }

        public bool PaymentSave { get; set; }
    }
}