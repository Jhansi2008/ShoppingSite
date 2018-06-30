using ShoppingSIte.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingSite.Models
{
    public class ProductInventoryDb:DbContext
    {
        static ProductInventoryDb()
        {
            var _ = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            var __ = typeof(System.Data.Entity.SqlServer.SqlSpatialServices);
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
       
        public DbSet<Cart> Carts{ get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}