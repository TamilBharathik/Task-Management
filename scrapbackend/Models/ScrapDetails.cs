namespace scrapbackend.Models
{
public class ScrapDetails
{
    public int ScrapID { get; set; }
    public string? ScrapType { get; set; }
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public List<IFormFile> Image { get; set; }
    
    
}
}

