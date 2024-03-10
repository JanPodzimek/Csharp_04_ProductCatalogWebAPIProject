using DataAccess.Models;

namespace DataAccess.Data;
public interface IProductData
{

    Task<IEnumerable<ProductModel>> GetProducts();
    Task<IEnumerable<ProductModel>> GetProductsByCategory(int id);
    Task<ProductModel?> GetProduct(int id);
    Task<ProductPutModel?> GetProductByEan(string ean);
    Task PostProduct(ProductPostModel product);
    Task PutProduct(ProductPutModel product);
    Task PutProductAddCateogry(ProductPutAddCategoryModel product);
    Task DeleteProduct(int id);
    Task<bool> ProductExists(int id);
}