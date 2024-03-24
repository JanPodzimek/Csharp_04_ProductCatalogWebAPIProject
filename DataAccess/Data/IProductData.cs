using DataAccess.Models;

namespace DataAccess.Data;
public interface IProductData
{

    Task<IEnumerable<IProductModel>> GetProducts();
    Task<IEnumerable<IProductModel>> GetProductsByCategory(int id);
    Task<IProductModel?> GetProduct(int id);
    Task<ProductPutModel?> GetProductByEan(string ean);
    Task<int> GetProductCount();
    Task PostProduct(ProductPostModel product);
    Task PutProduct(ProductPutModel product);
    Task PutProductAddCateogry(ProductPutAddCategoryModel product);
    Task DeleteProduct(int id);
    Task<bool> ProductExists(int id);
}