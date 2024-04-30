using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;
public interface IProductModel
{
    int Id { get; set; }
    
    public string Ean { get; set; }
    
    string Description { get; set; }
    int Price { get; set; }
    int Quantity { get; set; }
    List<CategoryModel> Categories { get; set; }
}
