using scrapbackend.Models;
using scrapbackend.Repository;
using Microsoft.AspNetCore.Mvc;
using scrapbackend.Context;
using System.Threading.Tasks;

namespace scrapbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellScrapController : ControllerBase
    {
        
        private readonly ISellScrapRepository repo;
        // private const string ImageDirectory = @"C:\AImages\";

        public SellScrapController(ISellScrapRepository repo)
        {
            this.repo = repo; 
        }

[HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var _list = await this.repo.GetAll();
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }
     [HttpPost("Insert")]

public async Task<IActionResult> Insert(ScrapDetails scrap)
    {
       if (scrap == null || scrap.Image == null)
        return BadRequest("Invalid input");
 
      try
    {
        await repo.Insert(scrap);
        return Ok(scrap);
   
    }
      catch (Exception ex)
    {
        return StatusCode(500, $"An error occurred while adding equipment with files: {ex.Message}");
    }
    }



// [HttpGet("all")]
// public async Task<IActionResult> GetAll(string scrapType)
// {
//     try
//     {
//         var scrap = await this.repo.GetAll(scrapType);
//         return Ok(scrap);
//     }
//     catch (Exception ex)
//     {
//         return StatusCode(500, ex.Message);
//     }
// }
        [HttpGet("images")]
        public async Task<IActionResult> GetAllimages()
        {
            try
            {
                var scrap = await repo.GetAllimages();
                return Ok(scrap);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // [HttpGet("Images")]
        // public async Task<ActionResult<IEnumerable<ScrapImage>>> GetAllImages()
        // {
        //     var images = await this.repo.GetAllImagesAsync();
        //     return Ok(images);
        // }



        [HttpGet("Getcurrency")]
        public async Task<IActionResult> Getcurrency()
        {
            var _list = await this.repo.Getcurrency();
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }

        
[HttpGet("GetByType/{type}")]
public async Task<IActionResult> GetByType(string type)
{
    try
    {
        var result = await this.repo.GetByType(type);
        if (result.Any())
        {
            return Ok(result);
        }
        return NotFound();
    }
    catch (Exception ex)
    {
        // Handle exception
        return StatusCode(500, ex.Message);
    }
}

// [HttpPost]
// [Route("CreateScrapWithImage")]
// public async Task<IActionResult> CreateScrapWithImage([FromForm] ScrapDetailsDto scrapDetailsDto)
// {
//     if (scrapDetailsDto.Image != null && scrapDetailsDto.Image.Any())
//     {
//         List<int> imageIds = new List<int>();

//         foreach (var imageFile in scrapDetailsDto.Image)
//         {
//             if (imageFile.Length > 0)
//             {
//                 byte[] imageBlob;
//                 using (var ms = new MemoryStream())
//                 {
//                     await imageFile.CopyToAsync(ms);
//                     imageBlob = ms.ToArray();
//                 }

//                 var scrapDetails = new ScrapDetails
//                 {
//                     ScrapType = scrapDetailsDto.ScrapType,
//                     ProductName = scrapDetailsDto.ProductName,
//                     Price = (int)scrapDetailsDto.Price,
//                     Quantity = scrapDetailsDto.Quantity
//                 };

//                 int imageId = await this.repo.CreateScrapWithImage(scrapDetails, imageBlob);
//                 imageIds.Add(imageId);
//             }
//         }

//         if (imageIds.Count > 0)
//         {
//             return Ok(new { ImageIDs = imageIds });
//         }
//         else
//         {
//             return BadRequest("No images were uploaded.");
//         }
//     }
//     else
//     {
//         return BadRequest("Image files are missing.");
//     }
// }
 [HttpPost("InsertCart")]
    public async Task<IActionResult> InsertIntoCart([FromBody] Cart model)
    {
        if (model == null)
        {
            return BadRequest();
        }

        await this.repo.InsertCart(model.ProductName, model.Quantity, model.TotalPrice, model.ScrapID);
        return Ok(model);
    }
    [HttpGet("GetCart")]
        public async Task<IActionResult> GetCart()
        {
            var _list = await this.repo.GetCart();
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("InsertBoughtItem")]
public async Task<IActionResult> InsertBoughtItem(BoughtItem boughtItem)
{
    if (boughtItem == null)
        return BadRequest("Invalid input");

    try
    {
        await repo.InsertBoughtItem(boughtItem);
        return Ok(boughtItem);
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"An error occurred while inserting the bought item: {ex.Message}");
    }
}

[HttpPost("RemoveFromCart")]
public async Task<IActionResult> RemoveFromCart([FromBody] string productName)
{
    var result = await this.repo.RemoveFromCart(productName);
    if (result)
    {
        return Ok();
    }
    else
    {
        return BadRequest();
    }
}


 [HttpPost("BuyAndRemoveItem/{cartId}")]
        public async Task<IActionResult> BuyAndRemoveItem(int cartId)
        {
            try
            {
                await repo.BuyAndRemoveItem(cartId);
                return Ok(new { message = "Item successfully bought and removed from cart." });
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging purposes
                Console.WriteLine(ex.Message);
                // Return a generic error message to the client
                return StatusCode(500, new { message = "An error occurred while processing your request." });
            }
        }
// [HttpPost("BuyAndRemoveItem/{cartId}")]
// public async Task<IActionResult> BuyAndRemoveItem(int cartId)
// {
//     try
//     {
//         // Get the most recent period
//         var mostRecentPeriod = await this.repo.GetMostRecentPeriod();
        
//         // Call the BuyAndRemoveItem method with the most recent period as input
//         await repo.BuyAndRemoveItem(cartId, mostRecentPeriod);
        
//         return Ok(new { message = "Item successfully bought and removed from cart." });
//     }
//     catch (Exception ex)
//     {
//         // Log the exception details for debugging purposes
//         Console.WriteLine(ex.Message);
//         // Return a generic error message to the client
//         return StatusCode(500, new { message = "An error occurred while processing your request." });
//     }
// }

    [HttpPost("InsertInvoicePeriod")]
    public async Task<IActionResult> InsertInvoicePeriod([FromBody] string invoicePeriod)
    {
        await this.repo.InsertInvoicePeriod(invoicePeriod);
        return Ok(invoicePeriod);
    }
[HttpGet("GetMostRecentPeriod")]
public async Task<IActionResult> GetMostRecentPeriod()
{
    try
    {
        var mostRecentPeriod = await this.repo.GetMostRecentPeriod();
        return Ok(mostRecentPeriod);
    }
    catch (Exception ex)
    {
        return StatusCode(500, ex.Message);
    }
}


[HttpGet("GetAllBoughtItems")]
public async Task<IActionResult> GetAllBoughtItems()
{
    var boughtItems = await repo.GetAllBoughtItems();
    if (boughtItems != null && boughtItems.Any())
    {
        return Ok(boughtItems);
    }
    else
    {
        return NotFound();
    }
}


[HttpGet("HasBoughtItems")]
public async Task<IActionResult> HasBoughtItems()
{
    var hasBoughtItems = await repo.HasBoughtItems();
    return Ok(hasBoughtItems);
}

 [HttpPost("GenerateInvoiceOnSchedule")]
        public async Task<IActionResult> GenerateInvoiceOnSchedule()
        {
            try
            {
                await this.repo.GenerateInvoiceOnSchedule();
                return Ok("Invoice generation triggered successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

[HttpGet("GetUnpaidInvoices")]
        public async Task<IActionResult> GetUnpaidInvoices()
        {
            var unpaidInvoices = await this.repo.GetUnpaidInvoices();
            if (unpaidInvoices != null)
            {
                return Ok(unpaidInvoices);
            }
            else
            {
                return NotFound();
            }
        }

[HttpPost("MarkInvoiceAsPaid")]
        public async Task<IActionResult> MarkInvoiceAsPaid([FromBody] MarkPaid request)
        {
            if (request == null || request.InvoiceId <= 0)
            {
                return BadRequest("Invalid invoice ID.");
            }

            try
            {
                await this.repo.MarkInvoiceAsPaid(request.InvoiceId);
                return Ok(new { message = "Invoice marked as paid successfully." });
            }
            catch (Exception ex)
            {
                // Log exception if needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetUnpaidBoughtItems")]
        public async Task<IActionResult> GetUninvoicedItems()
        {
            var unpaidInvoices = await this.repo.GetUninvoicedItems();
            if (unpaidInvoices != null)
            {
                return Ok(unpaidInvoices);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
