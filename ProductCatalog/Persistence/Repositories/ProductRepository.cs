﻿using Core.Persistence;
using ProductCatalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ProductDbContext _dbContext;

        public ProductRepository(ProductDbContext dbContext) {
            _dbContext = dbContext;
        }


        public void AddProduct(Product product)
        {
            _dbContext.Add(product);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.Where(x => !x.Deleted).ToList();
        }
    }
}