using ShoppingSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppingSIte.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters. No Numerics")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters. No Numerics")]
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailID { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [DataType(DataType.PhoneNumber)]
      
        public long PhoneNumber { get; set; }
             
        

        [Required]
        [Range(100000000000, 9999999999999999, ErrorMessage = "must be between 12digits")]
        public long CreditCardNumber { get; set; }
        [Required]
        [Range(1, 12, ErrorMessage = "between 1 and 12")]
        public int ExpireMonth { get; set; }
        [Required]
        [Range(2018, 2025, ErrorMessage = "Select proper year between 2018 and 2025 ")]
        public int ExpireYear { get; set; }
        [Required]
        [RegularExpression(@"^(\d{3})$", ErrorMessage = "Use 3 digit numerics")]
        public int SecurityCode { get; set; }
    }
}