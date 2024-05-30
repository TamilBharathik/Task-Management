using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrapbackend.Models
{
    public class ScrapDetailsDto
    {
    public string? ScrapType { get; set; }
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public List<IFormFile> Image { get; set; }
    }
}