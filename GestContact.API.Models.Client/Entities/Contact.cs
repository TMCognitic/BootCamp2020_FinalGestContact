using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestContact.API.Models.Client.Entities
{
    [DataContract]
    public class Contact
    {
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        [IgnoreDataMember]
        [JsonIgnore]
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
