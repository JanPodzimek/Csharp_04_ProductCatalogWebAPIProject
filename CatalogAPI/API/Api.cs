using DataAccess.DbAccess;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CatalogAPI.API;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {

        app.MapGet("/Products", GetProducts);
        app.MapGet("/Products/FilterByCategoryId/{id}", GetProductsByCategory);
        app.MapGet("/Products/{id}", GetProduct);
        app.MapPost("/Products", PostProduct);
        app.MapPut("/Products", PutProduct);
        app.MapPut("/Products/AddProductToCategory", PutProductAddCategory);
        app.MapDelete("/Products", DeleteProduct);
    }

    /// <summary>
    /// Retrieve all products
    /// </summary>
    private static async Task<IResult> GetProducts(IProductData data)
    {
        try
        {
            return Results.Ok(await data.GetProducts());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /// <summary>
    /// Retrieve all products under specific category
    /// </summary>
    /// <remarks>
    /// <b>List of availiable categories:</b><br></br>
    /// ID 1: Computers and Laptops<br></br>
    /// ID 2: Gaming and Entertainment<br></br>
    /// ID 3: Phones, Smartwatches and Tablets<br></br>
    /// ID 4: TV, Audio and Video<br></br>
    /// ID 5: Household<br></br>
    /// ID 6: Hobby and Garden<br></br>
    /// ID 7: Toys<br></br>
    /// ID 8: Drugstore<br></br>
    /// ID 9: Beauty<br></br>
    /// ID 10: Sport and Outdoors<br></br>
    /// ID 11: Car and Moto<br></br>
    /// ID 12: Office supplies<br></br>
    /// ID 13: Books<br></br>
    /// ID 14: Food and Alcohol<br></br>
    /// ID 15: Health<br></br>
    /// ID 16: Major appliances<br></br>
    /// </remarks>
    private static async Task<IResult> GetProductsByCategory(int id, IProductData data)
    {
        try
        {
            return Results.Ok(await data.GetProductsByCategory(id));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /// <summary>
    /// Find a product by ID and show its detail
    /// </summary>
    private static async Task<IResult> GetProduct(int id, IProductData data)
    {
        try
        {
            var results = await data.GetProduct(id);
            if (results == null) return Results.NotFound($"Product with ID {id} was not found.");

            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /// <summary>
    /// Create a new product and save it into the databse
    /// </summary>
    /// <remarks>
    /// <b>List of availiable categories:</b><br></br>
    /// ID 1: Computers and Laptops<br></br>
    /// ID 2: Gaming and Entertainment<br></br>
    /// ID 3: Phones, Smartwatches and Tablets<br></br>
    /// ID 4: TV, Audio and Video<br></br>
    /// ID 5: Household<br></br>
    /// ID 6: Hobby and Garden<br></br>
    /// ID 7: Toys<br></br>
    /// ID 8: Drugstore<br></br>
    /// ID 9: Beauty<br></br>
    /// ID 10: Sport and Outdoors<br></br>
    /// ID 11: Car and Moto<br></br>
    /// ID 12: Office supplies<br></br>
    /// ID 13: Books<br></br>
    /// ID 14: Food and Alcohol<br></br>
    /// ID 15: Health<br></br>
    /// ID 16: Major appliances<br></br>
    /// <b><u>If you want to select more categories at once, seperate IDs by comma, for example: </u><br></br>
    /// "categories": [ 2,3,4 ]</b>
    /// </remarks>
    /// <response code="201">Product successfully created.</response>
    private static async Task<IResult> PostProduct(ProductPostModel product, IProductData data)
    {
        try
        {
            await data.PostProduct(product);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /// <summary>
    /// Find a product by EAN and update it
    /// </summary>
    private static async Task<IResult> PutProduct(ProductPutModel product, IProductData data)
    {
        ProductPutModel? existingProduct = await data.GetProductByEan(product.Ean);

        if (existingProduct == null) return Results.NotFound($"Product with ID {product.Ean} was not found.");

        try
        {
            await data.PutProduct(product);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /// <summary>
    /// Add category to existing product
    /// </summary>
    /// <remarks>
    /// <b>List of availiable categories:</b><br></br>
    /// ID 1: Computers and Laptops<br></br>
    /// ID 2: Gaming and Entertainment<br></br>
    /// ID 3: Phones, Smartwatches and Tablets<br></br>
    /// ID 4: TV, Audio and Video<br></br>
    /// ID 5: Household<br></br>
    /// ID 6: Hobby and Garden<br></br>
    /// ID 7: Toys<br></br>
    /// ID 8: Drugstore<br></br>
    /// ID 9: Beauty<br></br>
    /// ID 10: Sport and Outdoors<br></br>
    /// ID 11: Car and Moto<br></br>
    /// ID 12: Office supplies<br></br>
    /// ID 13: Books<br></br>
    /// ID 14: Food and Alcohol<br></br>
    /// ID 15: Health<br></br>
    /// ID 16: Major appliances<br></br>
    /// </remarks>
    private static async Task<IResult> PutProductAddCategory(ProductPutAddCategoryModel product, IProductData data)
    {
        IProductModel? existingProduct = await data.GetProduct(product.ProductId);

        if (existingProduct == null) return Results.NotFound($"Product with ID {product.ProductId} was not found.");
        ProductPutAddCategoryModel ppacm = new ProductPutAddCategoryModel()
        {
            ProductId = existingProduct.Id,
            CategoryId = product.CategoryId
        };

        try
        {
            await data.PutProductAddCateogry(ppacm);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    /// <summary>
    /// Find a product by ID and delete it permanently
    /// </summary>
    private static async Task<IResult> DeleteProduct(int id, IProductData data)
    {
        if (!await data.ProductExists(id)) return Results.NotFound($"Product with ID {id} was not found.");

        try
        {
            await data.DeleteProduct(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
