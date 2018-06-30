using ShoppingSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingSIte.Models
{

    public class Cart
    {
      
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public string EmailId  { get; set; }
        [ForeignKey("EmailId")]
        public virtual UserAccount UserAccount { get; set; }

        public int TotalItems { get; set ; }
    }
}