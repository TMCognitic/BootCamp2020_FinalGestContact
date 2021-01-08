using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestContact.Models.Forms
{
    public class UpdateContactForm
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [StringLength(75, MinimumLength = 1)]
        public string LastName { get; set; }
        [Required]
        [StringLength(75, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(320, MinimumLength = 6)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
