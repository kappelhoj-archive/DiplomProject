﻿using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ProductCatalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class ProductDbContext : DbContext 
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }
        public new void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

        }


        DbSet<Product> Products { get; set; }
    }
}
