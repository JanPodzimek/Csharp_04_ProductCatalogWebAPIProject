using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Models;

public class ProductModel
{
    public int Id { get; set; }
    [Required]
    public string Ean { get; set; }
    [Required]
    public string Description { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public List<CategoryModel> Categories { get; set; } = new(); 
}

public class ProductPostModel
{
    [Required]
    public string Ean { get; set; }
    [Required]
    public string Description { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    [Required]
    public int CategoryId { get; set; }
}

public class ProductPutModel
{
    [Required]
    public string Ean { get; set; }
    [Required]
    public string Description { get; set; }
    public int Price { get; set; }
    [JsonIgnore]
    public DateTime PriceUpdated { get; set; }
    public int Quantity { get; set; }
}

public class ProductPutAddCategoryModel
{
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int CategoryId { get; set; }
}
