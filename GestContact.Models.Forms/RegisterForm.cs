using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestContact.Models.Forms
{
    public class RegisterForm
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(320, MinimumLength = 6)]
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("Mot de passe")]
        [Required]
        [StringLength(20, MinimumLength = 8)]
        [RegularExpression("^.*(?=.{8,})(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$")]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }
        [DisplayName("Confirmation")]
        [Required]
        [Compare(nameof(Passwd))]
        [DataType(DataType.Password)]
        public string Passwd2 { get; set; }
    }
}
