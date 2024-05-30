using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrapbackend.Models
{
public class Scrapall
{
    public int ScrapID { get; set; }
    public string? ScrapType { get; set; }
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public List<ScrapImage>? Images { get; set; } 
}

}