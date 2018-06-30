using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite.Models
{
    public class Reviews
    {
        private ProductInventoryDb _db = new ProductInventoryDb();
        public int AverageReviews(int productId)
        {
            List<ProductReview> reviews = _db.Products.Where(P => P.ProductId == productId).FirstOrDefault().ProductReviews.ToList();

            int avgRating = 0,sum=0;
            if (reviews.Count == 0)
            {
                return 0;
            }
            foreach(ProductReview review in reviews)
            {
                sum += review.Rating;                
            }
            
            avgRating = sum / reviews.Count;
            return avgRating;
        }
    }
}