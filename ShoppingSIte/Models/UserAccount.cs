using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingSIte.Models
{
    public class UserAccount
    {
        [Key]
        public string EmailId  { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
    }
}