using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using scrapbackend.Controllers;
using scrapbackend.Models;

namespace scrapbackend.Repository
{
    public interface ISellScrapRepository
    {
         
    public Task<IEnumerable<ScrapDetails>> GetAll();
    public Task Insert(ScrapDetails scrap);

    public Task<IEnumerable<Currencydropdown>> Getcurrency();
   
    public Task<IEnumerable<ScrapImage>> GetAllimages();

    public Task<IEnumerable<ScrapDetailswithImage>> GetByType(string scrapType);

    public Task InsertCart(string productName, int quantity, double totalPrice, int scrapId)
;
    public Task<bool> RemoveFromCart(string productName);
    public Task BuyAndRemoveItem(int cartId);
    public Task<IEnumerable<Cart>> GetCart();
    public Task InsertBoughtItem(BoughtItem boughtItem);
    public Task InsertInvoicePeriod(string invoicePeriod);
    public  Task<string> GetMostRecentPeriod();
    public Task<IEnumerable<BoughtItem>> GetAllBoughtItems();
    public Task<bool> HasBoughtItems();
    public Task GenerateInvoiceOnSchedule();
    public Task<IEnumerable<InvoiceWithDetails>> GetUnpaidInvoices();
    public Task MarkInvoiceAsPaid(int invoiceId);
    public Task<IEnumerable<BoughtItem>> GetUninvoicedItems();


}

    }





 // public Task<IEnumerable<ScrapImage>> GetByType(string scrapType);
//         // Task<List<SellScrap>> GetAll();
//         // public Task<SellScrap> Create(SellScrap Entry);
//     // public Task Insert(ScrapDetails scrap);

//     // Task Create(ScrapDetails scrapDetails, byte[] imageId, byte[] image);
   
//     //   public Task<IEnumerable<ScrapImage>> GetAllimages();
// // public Task<IEnumerable<ScrapDetailswithImage>> GetAllimages();

// // public Task<IEnumerable<Scrapall>> GetAll();

// // public Task<IEnumerable<ScrapDetailswithImage>> GetAll();
//         public Task<IEnumerable<ScrapDetailswithImage>> GetByType(string scrapType);
//         public Task<IEnumerable<ScrapImage>> GetAllImagesAsync();
//         // public Task<IEnumerable<ScrapDetails>> GetAll();
//         public Task<IEnumerable<Currencydropdown>> Getcurrency();
//         // public Task<int> CreateScrapWithImage(ScrapDetails scrapDetails, byte[] imageBlob);
//         public Task<IEnumerable<ScrapDetails>> GetAll(string scrapType);

// public Task Insert(ScrapDetails scrap);
// //   public Task<IEnumerable<ScrapDetails>> GetAll();

