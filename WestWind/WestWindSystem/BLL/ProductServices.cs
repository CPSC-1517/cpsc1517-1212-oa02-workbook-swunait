﻿using WestWindSystem.DAL;   // for WestContext;
using WestWindSystem.Entities;  // for Product

using Microsoft.EntityFrameworkCore;    // for EF extension methods

namespace WestWindSystem.BLL
{
    public class ProductServices
    {
        // Step 1: Define a readonly public DbContext field that is intialized using
        // constructor injection
        private readonly WestWindContext _dbContext;
        internal ProductServices(WestWindContext context)
        {
            _dbContext = context;
        }

        public int Product_AddProduct(Product newProduct)
        {
            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();
            return newProduct.ProductID;
        }

        public int Product_UpdateProduct(Product existingProduct)
        {
            _dbContext.Products.Attach(existingProduct).State = EntityState.Modified;
            int rowsUpdated = _dbContext.SaveChanges();
            return rowsUpdated;
        }

        public int Product_DeleteProduct(Product existingProduct)
        {
            // To remove record from database
            // _dbContext.Products.Attach(existingProduct).State = EntityState.Deleted;

            // To mark a record as deleted but keep record in database
            existingProduct.Discontinued = true;
            _dbContext.Products.Attach(existingProduct).State = EntityState.Modified;

            int rowsDeleted = _dbContext.SaveChanges();
            return rowsDeleted;
        }

        // Step 2: Define operations to perform with entity
        public List<Product> Product_GetByCategoryID(int categoryID)
        {
            return _dbContext
                .Products
                .Where(p => p.CategoryID == categoryID)
                .ToList();
        }
        public List<Product> Product_GetByCategoryID(int categoryID,
            int pageSize,
            int pageNumber,
            out int totalCount)
        {
            var query = _dbContext
                .Products
                .Where(p => p.CategoryID == categoryID);
            totalCount = query.Count();
            return query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
                
        }

        public List<Product> Product_GetByPartialProductName(string partialProductName)
        {
            return _dbContext
                .Products
                .Where(p => p.ProductName.Contains(partialProductName))
                .ToList();
        }

        public List<Product> Product_GetByPartialProductName(string partialProductName, 
            int pageSize, int pageNumber, out int count)
        {
            var query = _dbContext
                .Products
                .Where(p => p.ProductName.Contains(partialProductName));

            count = query.Count();

            return query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public Product Product_GetByID(int productID)
        {
            Product info = _dbContext
                .Products
                .Where(p => p.ProductID == productID)
                .FirstOrDefault();
            return info;

        }

    }
}
