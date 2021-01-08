using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestContact.MVC.Models.Client.Entities
{
    public class Contact
    {
        public int Id { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int CustomerId { get; set; }

        public Contact(string lastName, string firstName, string email, string phone, DateTime birthDate, int customerId)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            CustomerId = customerId;
        }

        internal Contact(int id, string lastName, string firstName, string email, string phone, DateTime birthDate, int customerId) 
            : this(lastName, firstName, email, phone, birthDate, customerId)
        {
            Id = id;
        }
    }
}
