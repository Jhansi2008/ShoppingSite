using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingSite.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }            
        public string Category  { get; set; }
        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        [DataType(DataType.Currency)]
        public double UnitPrice { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "UnitsInStock must be numeric")]
        public int UnitsInStock { get; set; }
        public virtual List<ProductReview>ProductReviews { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "UnitsInStock must be numeric")]
        public int TotalUnits { get; set; }
    }

    
    
}