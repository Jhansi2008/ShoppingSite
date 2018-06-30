using ShoppingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSIte.Models
{
    public class CartItems
    {
        private ProductInventoryDb _db = new ProductInventoryDb();
        public int TotalItems(string UserId)
        {
            var carts = _db.Carts.Where(C => C.EmailId == UserId);
            if (carts == null)
            {
                return 0;
            }
            else
            {
                return carts.Count();
            }
        }
       
    }
}