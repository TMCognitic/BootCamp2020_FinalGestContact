using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GestContact.Models.Forms
{
    public class LoginForm
    {
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
    }
}
