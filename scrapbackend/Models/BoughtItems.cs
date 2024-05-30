using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace scrapbackend.Models
{
public class BoughtItem
{
    public string? ProductName { get; set; }
    public decimal TotalPrice { get; set; }
    public string? InvoicePeriod { get; set; }
    public DateTime PurchaseDate{ get; set; }
    public decimal Quantity { get; set; }
    public int ScrapID { get; set; }
}

}