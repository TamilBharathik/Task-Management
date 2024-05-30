using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrapbackend.Models
{
    public class ProductDetails
    
    {
        public int BoughtProdId { get; set; }
        public string? ProductName { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string? InvoicePeriod { get; set; }
    }
    }