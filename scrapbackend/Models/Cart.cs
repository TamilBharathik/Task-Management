using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using OracleInternal.Secure.Network;

namespace scrapbackend.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }

        public double TotalPrice { get; set; }
        
        public int ScrapID { get; set; }
    }
}
