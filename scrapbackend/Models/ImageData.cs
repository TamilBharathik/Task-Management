using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scrapbackend.Models
{
    public class ScrapImage
    {
    public int ImageId { get; set; }
    public int ScrapId { get; set; }
    // public byte[] Image { get; set; }
    public List<byte[]> Images { get; set; }
    // public int ImageID { get; set; }
    // public byte[] ImageData { get; set; }
    }
}







// {
//     public class ScrapImage
//     {
//     // // public int ImageId { get; set; }
//     // public int ScrapId { get; set; }
//     public byte[] Image { get; set; }
//     // public List<byte[]> Images { get; set; }
//     public int ImageID { get; set; }
//     public byte[] ImageData { get; set; }
//     }


// }


//     public class ScrapImage
// {

//     public int ImageID { get; set; }
//     public byte[] ImageData { get; set; }
//     public string ImageBase64 { get; set; } // This will hold the Base64 string
//     public string Image { get; set; }
    
// }