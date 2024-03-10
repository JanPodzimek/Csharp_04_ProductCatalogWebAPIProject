﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.DbAccess;
using DataAccess.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess.Data;
public class ProductData : IProductData
{
    private readonly ISqlDataAccess _db;

    public ProductData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<ProductModel>> GetProducts()
    {
        var products = await _db.LoadData<ProductModel, dynamic>("spProduct_GetAll", new { });

        List<ProductCategoryModel> productCategories = await Task.Run(() => _db.LoadData<ProductCategoryModel,
            dynamic>("spProductCategory_GetAll", new { }).Result.ToList());

        foreach (var productCategory in productCategories)
        {
            CategoryModel category = new CategoryModel(){ Id = productCategory.CategoryId, 
                Name = productCategory.CategoryName,
                IsMain = productCategory.IsMain};
            
            foreach (var product in products)
            {
                if (productCategory.ProductId == product.Id) product.Categories.Add(category);
            }
        }

        return products;
    }

    public async Task<IEnumerable<ProductModel>> GetProductsByCategory(int id)
    {
        var products = await _db.LoadData<ProductModel, dynamic>("spProduct_GetByCategory", new { Id = id });

        List<ProductCategoryModel> productCategories = await Task.Run(() => _db.LoadData<ProductCategoryModel,
            dynamic>("spProductCategory_GetByCategory", new { Id = id }).Result.ToList());

        foreach (var productCategory in productCategories)
        {
            CategoryModel category = new CategoryModel()
            {
                Id = productCategory.CategoryId,
                Name = productCategory.CategoryName,
                IsMain = productCategory.IsMain
            };

            foreach (var product in products)
            {
                if (productCategory.ProductId == product.Id) product.Categories.Add(category);
            }
        }

        return products;
    }


    public async Task<ProductModel?> GetProduct(int id)
    {
        var result = await _db.LoadData<ProductModel, dynamic>("spProduct_Get", new { Id = id });
        
        List<ProductCategoryModel> productCategories = await Task.Run(() => _db.LoadData<ProductCategoryModel,
            dynamic>("spProductCategory_Get", new { Id = id }).Result.ToList());

        List<CategoryModel> categories = new List<CategoryModel>();
        ProductModel? product = result.FirstOrDefault();

        if (product != null)
        {
            foreach (var productCategory in productCategories)
            {
                CategoryModel category = new CategoryModel()
                {
                    Id = productCategory.CategoryId,
                    Name = productCategory.CategoryName,
                    IsMain = productCategory.IsMain
                };
                categories.Add(category);
            }
            product.Categories = categories;
        }

        return product;
    }

    public async Task<ProductPutModel?> GetProductByEan(string ean)
    {
        var result = await _db.LoadData<ProductPutModel, dynamic>("spProduct_GetByEan", new { Ean = ean });
        ProductPutModel? product = result.FirstOrDefault();

        return product;
    }

    public Task PostProduct(ProductPostModel product)
    {
        //Version for inserting more than 1 category at once that I have implemented before
        //DataTable categoriesTable = new DataTable();
        //categoriesTable.Columns.Add("CategoryId", typeof(int));
        //foreach (var categoryId in product.Categories) categoriesTable.Rows.Add(categoryId);

        return _db.SaveData("spProduct_Post",
            new { product.Ean, product.Description, product.Price, product.Quantity, product.CategoryId });
    }


    public Task PutProduct(ProductPutModel newProductData)
    {
        TimeSpan twelveHours = TimeSpan.FromHours(12);

        ProductPutModel? oldProductData = GetProductByEan(newProductData.Ean).Result;

        if (oldProductData != null) {
            if (DateTime.Now - oldProductData.PriceUpdated > twelveHours
                && newProductData.Price != oldProductData.Price)
            {
                newProductData.PriceUpdated = DateTime.Now;
                return _db.SaveData("spProduct_PutPriceUpdated", newProductData);
            }

            newProductData.PriceUpdated = oldProductData.PriceUpdated;

            if (newProductData.PriceUpdated == DateTime.MinValue)
                // just piece of trash data passed to stored procedure so it would not throw an exception
                // without this, exception DateTime is out of range
                newProductData.PriceUpdated = DateTime.Now - twelveHours;

        }
        return _db.SaveData("spProduct_Put", newProductData);
    }

    public Task PutProductAddCateogry(ProductPutAddCategoryModel product)
    {
        return _db.SaveData("spProduct_PutProductAddCategory", product);
    }

    public Task DeleteProduct(int id) => _db.SaveData("spProduct_Delete", new { Id = id });

    public Task<bool> ProductExists(int id)
    {
        return Task.FromResult(GetProducts().Result.Any(p => p.Id == id));
    }
}
