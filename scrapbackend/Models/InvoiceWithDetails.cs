using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrapbackend.Models
{
    public class InvoiceWithDetails
    
    {
        public int InvoiceId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<ProductDetails> Products { get; set; } = new List<ProductDetails>();
    }
    
}