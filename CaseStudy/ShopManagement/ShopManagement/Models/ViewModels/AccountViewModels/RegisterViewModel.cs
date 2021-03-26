using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]               
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password"
            , ErrorMessage = "Password And Confirm Password  do not match")]
        public string ConfirmPassword { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage = "Max Length Name 50")]      
        public string FullName { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
    }
}
