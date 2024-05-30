using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using scrapbackend.Context;
using scrapbackend.Models;
using Dapper;
using Dapper.Oracle;

namespace scrapbackend.Repository
{
    public class SellScrapRepository : ISellScrapRepository
{
    private readonly DapperDBContext _context;

    public SellScrapRepository(DapperDBContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

  public async Task<IEnumerable<ScrapDetails>> GetAll()
      {
        try
        {
         using (var connection = _context.CreateConnection())
        {
            var oracleDynamicParameters = new OracleDynamicParameters();
            oracleDynamicParameters.Add("OUT_ALL", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
 
            connection.Open();
            var equipment = connection.Query<ScrapDetails>("getAlltb", oracleDynamicParameters, commandType: CommandType.StoredProcedure).ToList();
            connection.Close();
 
            return equipment;
         }
         }
        catch (Exception ex)
       {
          Console.WriteLine(ex.Message);
          throw;
        }
       }
// public async Task<IEnumerable<ScrapDetailswithImage>> GetAll()
// {
//     using (var connection = _context.CreateConnection())
//     {
//         connection.Open();
//         var queryResult = await connection.QueryAsync<ScrapDetailswithImage>("getAlltbb", commandType: CommandType.StoredProcedure);
//         connection.Close();

//         return queryResult;
//     }
// }

// public async Task<IEnumerable<ScrapDetailswithImage>> GetAllimages()
// {
//     try
//     {
//         using (var connection = _context.CreateConnection())
//         {
//             var oracleDynamicParameters = new OracleDynamicParameters();
//             oracleDynamicParameters.Add("OUT_ALL", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

//             connection.Open();
//             var results = await connection.QueryAsync<dynamic>("getAllScrapImageTB", oracleDynamicParameters, commandType: CommandType.StoredProcedure);
//             connection.Close();

//             var detailsList = new List<ScrapDetailswithImage>();

//     foreach (var record in results)
//     {
//         var detailsWithImages = new ScrapDetailswithImage
//         {
//             ScrapID = record.SCRAPID,
//             ScrapType = record.SCRAPTYPE,
//             ProductName = record.PRODUCTNAME,
//             Price = record.PRICE,
//             Quantity = record.QUANTITY,
//             Images = record.Images.Select(img => Convert.ToBase64String((byte[])img.Image)).ToList()
//         };

//         detailsList.Add(detailsWithImages);
//     }

//     return detailsList;
// }
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine(ex.Message);
//         throw;
//     }
// }


private async Task<int> Create(ScrapDetails scrap)
{
    using (var connection = _context.CreateConnection()){
    var parameters = new OracleDynamicParameters();
    // parameters.Add("p_Eqpmt_No", scrap.ScrapID, OracleMappingType.Varchar2, ParameterDirection.Input);
    parameters.Add("p_ScrapType", scrap.ScrapType, OracleMappingType.Varchar2, ParameterDirection.Input);
    parameters.Add("p_ProductName", scrap.ProductName, OracleMappingType.Varchar2, ParameterDirection.Input);
    parameters.Add("p_Price", scrap.Price, OracleMappingType.Decimal, ParameterDirection.Input);
    parameters.Add("p_Quantity", scrap.Quantity, OracleMappingType.Int64, ParameterDirection.Input);
    parameters.Add("p_ScrapID", dbType: OracleMappingType.Int64, direction: ParameterDirection.Output);
    await connection.ExecuteAsync("Insert_ScrapTBdetails", parameters, commandType: CommandType.StoredProcedure);
    int ScrapID = parameters.Get<int>("p_ScrapID");
     
    return ScrapID;
}
}
private async Task InsertImage(int ScrapID, IFormFile Image)
{
    using (var memoryStream = new MemoryStream())
    {
        await Image.CopyToAsync(memoryStream);
        byte[] photoData = memoryStream.ToArray();
 
        var parameters = new OracleDynamicParameters();
        parameters.Add("p_ScrapID", ScrapID, OracleMappingType.Int64, ParameterDirection.Input);
        parameters.Add("p_Image", photoData, OracleMappingType.Blob, ParameterDirection.Input);
 
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync("Insert_ScrapPhotoTB", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
public async Task Insert(ScrapDetails scrap)
{
    // string connectionString = configuration.GetConnectionString("Default");
    // using (var connection = new OracleConnection(connectionString))
       using (var connection = _context.CreateConnection())
    {
        // await connection.OpenAsync();
        // using (var transaction = connection.BeginTransaction())
        // {
            try
            {
                //var eqpmtId = await InsertEquipment(connection, equipment);
                var Entry = await Create(scrap);
                foreach (var Image in scrap.Image)
                {
                    await InsertImage(Entry, Image);
                }
 
                // transaction.Commit();
            }
            catch (Exception ex)
            {
                // transaction.Rollback();
                throw ex;
            }
        }
    }

  public async Task<IEnumerable<ScrapImage>> GetAllimages()
      {
        try
        {
         using (var connection = _context.CreateConnection())
        {
            var oracleDynamicParameters = new OracleDynamicParameters();
            oracleDynamicParameters.Add("OUT_ALL", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
 
            connection.Open();
            var equipment = connection.Query<ScrapImage>("getAllScrapImageTB", oracleDynamicParameters, commandType: CommandType.StoredProcedure).ToList();
            connection.Close();
 
            return equipment;
         }
         }
        catch (Exception ex)
       {
          Console.WriteLine(ex.Message);
          throw;
        }
       }
       public async Task<IEnumerable<Currencydropdown>> Getcurrency()
      {
        try
        {
         using (var connection = _context.CreateConnection())
        {
            var oracleDynamicParameters = new OracleDynamicParameters();
            oracleDynamicParameters.Add("OUT_ALL", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
 
            connection.Open();
            var equipment = connection.Query<Currencydropdown>("CurrencyTB", oracleDynamicParameters, commandType: CommandType.StoredProcedure).ToList();
            connection.Close();
 
            return equipment;
         }
         }
        catch (Exception ex)
       {
          Console.WriteLine(ex.Message);
          throw;
        }
       }





// SellScrapRepository
// public async Task<IEnumerable<ScrapImage>> GetByType(string scrapType)
// {
//     try
//     {
//         using (var connection = _context.CreateConnection())
//         {
//             var oracleDynamicParameters = new OracleDynamicParameters();
//             oracleDynamicParameters.Add("SCRAP_TYPE_IN", scrapType, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
//             oracleDynamicParameters.Add("OUT_SCRAP_BY_TYPE", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

//             connection.Open();
//             var scraps = connection.Query<ScrapImage>("getScrapByType", oracleDynamicParameters, commandType: CommandType.StoredProcedure).ToList();
//             connection.Close();

//             // Retrieve images for each scrap
// foreach (var scrap in scraps)
// {
//     var images = await GetImagesByScrapId(scrap.ScrapId);
//     scrap.Images = images.Select(img => img.Images).ToList();
// }


//             return scraps;
//         }
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine(ex.Message);
//         throw;
//     }
// }

public async Task<IEnumerable<ScrapDetailswithImage>> GetByType(string scrapType)
{
    using (var connection = _context.CreateConnection())
    {
        var oracleDynamicParameters = new OracleDynamicParameters();
        oracleDynamicParameters.Add("p_ScrapType", scrapType);
        oracleDynamicParameters.Add("p_Recordset", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

        connection.Open();
        var queryResult = await connection.QueryAsync<dynamic>("GetScrapDetailsByTypeTB", oracleDynamicParameters, commandType: CommandType.StoredProcedure);
        connection.Close();

        // Group images by ScrapID
        var groupedImages = queryResult
            .GroupBy(record => (int)record.SCRAPID)
            .Select(group => new ScrapDetailswithImage
            {
                ScrapID = group.Key,
                ScrapType = group.First().SCRAPTYPE,
                ProductName = group.First().PRODUCTNAME,
                Price = (decimal)group.First().PRICE,
                Quantity = (int)group.First().QUANTITY,
                Images = group.Select(record => new ScrapImageA
                {
                    ImageID = (int)record.IMAGEID,
                    Image = Convert.ToBase64String((byte[])record.IMAGE)
                }).ToList()
            });

        return groupedImages;
    }
}



        

private async Task<List<ScrapImage>> GetImagesByScrapId(int scrapId)
{
    using (var connection = _context.CreateConnection())
    {
        var oracleDynamicParameters = new OracleDynamicParameters();
        oracleDynamicParameters.Add("SCRAP_ID_IN", scrapId, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
        oracleDynamicParameters.Add("OUT_SCRAP_IMAGES", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

        connection.Open();
        var images = connection.Query<ScrapImage>("getImagesByScrapId", oracleDynamicParameters, commandType: CommandType.StoredProcedure).ToList();
        connection.Close();

        return images;
    }
}


        // public async Task<IEnumerable<ScrapImage>> GetAllImagesAsync()
        // {
        //     using (var connection = _context.CreateConnection())
        //     {
        //         var oracleDynamicParameters = new OracleDynamicParameters();
        //         oracleDynamicParameters.Add("OUT_ALL", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

        //         connection.Open();
        //         var images = await connection.QueryAsync<ScrapImage>("getAllScrapImageTB", oracleDynamicParameters, commandType: CommandType.StoredProcedure);
        //         connection.Close();

        //         // Convert BLOB to base64 string
        //         foreach (var image in images)
        //         {
        //             if (image.Image != null)
        //             {
        //                 image.ImageBase64 = Convert.ToBase64String(image.Image);
        //             }
        //         }

        //         return images;
        //     }
        // }


    //     public async Task InsertCart(string productName, int quantity, decimal totalPrice)
    // {
    //     using (var connection = _context.CreateConnection())
    //     {
    //         var parameters = new OracleDynamicParameters();
    //         parameters.Add("p_ProductName", productName, OracleMappingType.Varchar2, ParameterDirection.Input);
    //         parameters.Add("p_Quantity", quantity, OracleMappingType.Int32, ParameterDirection.Input);
    //         parameters.Add("p_TotalPrice", totalPrice, OracleMappingType.Decimal, ParameterDirection.Input);

    //         await connection.ExecuteAsync("InsertIntoCartTB", parameters, commandType: CommandType.StoredProcedure);
    //     }
    // }
// public async Task InsertCart(string productName, int quantity, decimal totalPrice)
// {
//     try
//     {
//         using (var connection = _context.CreateConnection())
//         {
//             var parameters = new OracleDynamicParameters();
//             parameters.Add("p_ProductName", productName, OracleMappingType.Varchar2, ParameterDirection.Input);
//             parameters.Add("p_Quantity", quantity, OracleMappingType.Int32, ParameterDirection.Input);
//             parameters.Add("p_TotalPrice", totalPrice, OracleMappingType.Decimal, ParameterDirection.Input);
           

//             await connection.ExecuteAsync("InsertIntoCartTB", parameters, commandType: CommandType.StoredProcedure);
//         }
//     }
//     catch (OracleException ex)
//     {
//         // Handle the exception
//         Console.WriteLine(ex.Message);
//         // Consider logging the exception and/or rethrowing it
//         throw;
//     }
// }
public async Task InsertCart(string productName, int quantity, double totalPrice, int scrapId)
{
    try
    {
        using (var connection = _context.CreateConnection())
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add("p_ProductName", productName, OracleMappingType.Varchar2, ParameterDirection.Input);
            parameters.Add("p_Quantity", quantity, OracleMappingType.Int32, ParameterDirection.Input);
            parameters.Add("p_TotalPrice", totalPrice, OracleMappingType.Double, ParameterDirection.Input);
            parameters.Add("p_ScrapID", scrapId, OracleMappingType.Int32, ParameterDirection.Input);

            await connection.ExecuteAsync("InsertIntoCartTB", parameters, commandType: CommandType.StoredProcedure);
        }
    }
    catch (OracleException ex)
    {
        // Handle the exception
        Console.WriteLine(ex.Message);
        // Consider logging the exception and/or rethrowing it
        throw;
    }
}

    public async Task<IEnumerable<Cart>> GetCart()
      {
        try
        {
         using (var connection = _context.CreateConnection())
        {
            var oracleDynamicParameters = new OracleDynamicParameters();
            oracleDynamicParameters.Add("p_cursor", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
 
            connection.Open();
            var equipment = connection.Query<Cart>("GetCartTBContents", oracleDynamicParameters, commandType: CommandType.StoredProcedure).ToList();
            connection.Close();
 
            return equipment;
         }
         }
        catch (Exception ex)
       {
          Console.WriteLine(ex.Message);
          throw;
        }
       }


    public async Task InsertBoughtItem(BoughtItem boughtItem)
{
    using (var connection = _context.CreateConnection())
    {
        var parameters = new OracleDynamicParameters();
        parameters.Add("p_ProductName", boughtItem.ProductName, OracleMappingType.Varchar2, ParameterDirection.Input);
        parameters.Add("p_TotalPrice", boughtItem.TotalPrice, OracleMappingType.Decimal, ParameterDirection.Input);
        parameters.Add("p_InvoicePeriod", boughtItem.InvoicePeriod, OracleMappingType.Varchar2,ParameterDirection.Input);
        

        await connection.ExecuteAsync("InsertBoughtItem", parameters, commandType: CommandType.StoredProcedure);
    }
}

public async Task<bool> RemoveFromCart(string productName)
{
    try
    {
        using (var connection = _context.CreateConnection())
        {
            var oracleDynamicParameters = new OracleDynamicParameters();
            oracleDynamicParameters.Add("p_ProductName", productName, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);

            connection.Open();
            await connection.ExecuteAsync("RemoveSingleFromCart", oracleDynamicParameters, commandType: CommandType.StoredProcedure);
            connection.Close();

            return true;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return false;
    }
}

public async Task BuyAndRemoveItem(int cartId)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new OracleDynamicParameters();
                    parameters.Add("p_CartID", cartId, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                   
                    connection.Open();
                    await connection.ExecuteAsync("BuyAndRemoveFromCartTB", parameters, commandType: CommandType.StoredProcedure);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

// public async Task BuyAndRemoveItem(int cartId, string defaultPeriod)
// {
//     try
//     {
//         using (var connection = _context.CreateConnection())
//         {
//             var parameters = new OracleDynamicParameters();
//             parameters.Add("p_CartID", cartId, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
//             parameters.Add("p_DefaultPeriod", defaultPeriod, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);

//             connection.Open();
//             await connection.ExecuteAsync("BuyAndRemoveFromCartTB", parameters, commandType: CommandType.StoredProcedure);
//             connection.Close();
//         }
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine(ex.Message);
//         throw;
//     }
// }


        public async Task InsertInvoicePeriod(string invoicePeriod)
{
    using (var connection = _context.CreateConnection())
    {
        var parameters = new OracleDynamicParameters();
        parameters.Add("p_InvoicePeriod", invoicePeriod, OracleMappingType.Varchar2, ParameterDirection.Input);

        await connection.ExecuteAsync("InsertInvoicePeriodTB", parameters, commandType: CommandType.StoredProcedure);
    }
}

public async Task<string> GetMostRecentPeriod()
{
    try
    {
        using (var connection = _context.CreateConnection())
        {
            var oracleDynamicParameters = new OracleDynamicParameters();
            oracleDynamicParameters.Add("p_period", dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Output, size: 50);

            connection.Open();
            await connection.ExecuteAsync("GetMostRecentPeriodTB", oracleDynamicParameters, commandType: CommandType.StoredProcedure);
            connection.Close();

            return oracleDynamicParameters.Get<string>("p_period");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        throw;
    }
}


        public async Task<IEnumerable<BoughtItem>> GetAllBoughtItems()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new OracleDynamicParameters();
                    parameters.Add("p_cursor", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                    connection.Open();
                    var result = await connection.QueryAsync<BoughtItem>("GetAllBoughtItemsTB", parameters, commandType: CommandType.StoredProcedure);
                    connection.Close();

                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

// public async Task<bool> HasBoughtItems()
// {
//     try
//     {
//         using (var connection = _context.CreateConnection())
//         {
//             connection.Open();
//             var result = await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM BoughtItemsTB");
//             connection.Close();

//             return result > 0;
//         }
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine(ex.Message);
//         throw;
//     }
// }
public async Task<bool> HasBoughtItems()
{
    try
    {
        using (var connection = _context.CreateConnection())
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add("p_hasUninvoicedProducts", dbType: OracleMappingType.Int16, direction: ParameterDirection.Output);

            await connection.ExecuteAsync("CheckInvoicedStatusTB", parameters, commandType: CommandType.StoredProcedure);

            // Retrieve the output parameter value
            var hasUninvoicedProducts = parameters.Get<short>("p_hasUninvoicedProducts");

            // Convert the numeric value to boolean
            bool hasUninvoiced = hasUninvoicedProducts != 0;

            return hasUninvoiced;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        throw;
    }
}


 public async Task GenerateInvoiceOnSchedule()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    connection.Open();
                    await connection.ExecuteAsync("Generate_Invoice_On_Schedule", commandType: CommandType.StoredProcedure);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

 public async Task<IEnumerable<InvoiceWithDetails>> GetUnpaidInvoices()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var oracleDynamicParameters = new OracleDynamicParameters();
                    oracleDynamicParameters.Add("OUT_UNPAID", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                    connection.Open();
                    var unpaidInvoices = connection.Query<InvoiceWithDetails, ProductDetails, InvoiceWithDetails>(
                        "GetUnpaidInvoicesTB",
                        (invoice, product) =>
                        {
                            invoice.Products.Add(product);
                            return invoice;
                        },
                        splitOn: "BOUGHTPRODID",
                        param: oracleDynamicParameters,
                        commandType: CommandType.StoredProcedure).AsList();
                    connection.Close();

                    var result = unpaidInvoices.GroupBy(i => i.InvoiceId).Select(g =>
                    {
                        var groupedInvoice = g.First();
                        groupedInvoice.Products = g.SelectMany(i => i.Products).ToList();
                        return groupedInvoice;
                    });

                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

public async Task MarkInvoiceAsPaid(int invoiceId)
{
    using (var connection = _context.CreateConnection())
    {
        var parameters = new OracleDynamicParameters();
        parameters.Add("p_invoice_id", invoiceId, OracleMappingType.Int32, ParameterDirection.Input);

        await connection.ExecuteAsync("Mark_Invoice_As_PaidTB", parameters, commandType: CommandType.StoredProcedure);
    }
}


public async Task<IEnumerable<BoughtItem>> GetUninvoicedItems()
{
    try
    {
        using (var connection = _context.CreateConnection())
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add("out_cursor", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
 
            connection.Open();
            var uninvoicedItems = await connection.QueryAsync<BoughtItem>("Get_Uninvoiced_ItemsTB", parameters, commandType: CommandType.StoredProcedure);
            connection.Close();
 
            return uninvoicedItems;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        throw;
    }
}

}
 
}

