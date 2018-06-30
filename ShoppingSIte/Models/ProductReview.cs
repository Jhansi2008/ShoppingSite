using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingSite.Models
{
    public class ProductReview
    {
        public int ID { get; set; }
        [Required]
        public String ReviewerName { get; set; }
        [Range(1, 5)]
        [Required]
        public int Rating { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public String Comments { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }      

    }
}