using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MysqlTest.Models
{
    public class Customer
    {
        [Key]
        [MaxLength(50)]
        [Display(Name = "Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Address required")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [MaxLength(30)]
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name required")]
        public string firstName { get; set; }

        [MaxLength(30)]
        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name required")]
        public string lastName { get; set; }

        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        [MaxLength(18, ErrorMessage = "Maximum 18 characters required")]
        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string pwd { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please confirm you password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Doesn't match with password")]
        public string rpwd { get; set; }
    }
}