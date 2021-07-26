using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProSeller.Models
{
    public class Seller
    {
        [Display(Name = "Seller ID")]
        public int SellerID { get; set; }

        [Required(ErrorMessage = "Seller name is required.")]
        [Display(Name = "Seller Name")]
        public string SellerName { get; set; }

        [Required(ErrorMessage = "Owner Name is required.")]
        public string OwnerName { get; set; }
    }
}