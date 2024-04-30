using DataAccess.Models;

namespace DataAccess.Data;
public interface IProductData
{

    Task<IEnumerable<IProductModel>> GetProductsAsync();
    Task<IEnumerable<IProductModel>> GetProductsByCategoryAsync(int id);
    Task<IProductModel?> GetProductAsync(int id);
    Task<ProductPutModel?> GetProductByEanAsync(string ean);
    Task<int> GetProductCountAsync();
    Task PostProduct(ProductPostModel product);
    Task PutProduct(ProductPutModel product);
    Task PutProductAddCateogry(ProductPutAddCategoryModel product);
    Task DeleteProduct(int id);
    Task<bool> ProductExists(int id);
}