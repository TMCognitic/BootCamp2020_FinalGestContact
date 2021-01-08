using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GestContact.MVC.Models.Client.Entities
{
    [DataContract]
    public class Customer
    {
        public int Id { get; private set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string Email { get; private set; }
        public string Passwd { get; private set; }
        internal Customer(int id, string lastName, string firstName)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
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
