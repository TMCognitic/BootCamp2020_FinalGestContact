using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GestContact.API.Models.Client.Entities
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string LastName { get; private set; }
        [DataMember]
        public string FirstName { get; private set; }
        [IgnoreDataMember]
        [JsonIgnore]
        public string Email { get; private set; }
        [IgnoreDataMember]
        [JsonIgnore]
        public string Passwd { get; private set; }
        [DataMember]
        public string Token { get; set; }

        internal Customer(int id, string lastName, string firstName, string email)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
        }

        public Customer(string lastName, string firstName, string email, string passwd)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Passwd = passwd;
        }
    }
}
