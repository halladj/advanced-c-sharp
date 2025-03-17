using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesManager.Product;

public class ProductRepository : IRepository<Products>
{
    private readonly List<Products> _products = new List<Products>()
    {
        new Products { Id = 1, Name = "Laptop", Description = "Gaming Laptop", Price = 1200.99m, StockQuantity = 5, UserId = 1 },
        new Products { Id = 2, Name = "Phone", Description = "Smartphone", Price = 699.99m, StockQuantity = 10, UserId = 2 }
    };

    public void create(Products entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException();
        }
        entity.Id = _products.Select(p => p.Id).DefaultIfEmpty(0).Max() + 1;
        _products.Add(entity);
    }

    public void delete(Products entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException();
        }
        _products.Remove(entity);
    }

    public IEnumerable<Products> GetAll()
    {
        return _products;
    }

    public Products? GetByID(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public void update(Products entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException();
        }
        var existingProduct = GetByID(entity.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = entity.Name;
            existingProduct.Description = entity.Description;
            existingProduct.Price = entity.Price;
            existingProduct.StockQuantity = entity.StockQuantity;
        }
    }
}
