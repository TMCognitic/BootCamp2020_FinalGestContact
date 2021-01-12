using GCustomer = GestContact.API.Models.Global.Entities.Customer;
using GContact = GestContact.API.Models.Global.Entities.Contact;
using GestContact.API.Models.Client.Entities;

namespace GestContact.API.Models.Client.Mappers
{
    public static class Mappers
    {
        public static GCustomer ToGlobal(this Customer entity)
        {
            return new GCustomer() { Id = entity.Id, LastName = entity.LastName, FirstName = entity.FirstName, Email = entity.Email, Passwd = entity.Passwd };
        }

        public static Customer ToClient(this GCustomer entity)
        {
            return new Customer(entity.Id, entity.LastName, entity.FirstName, entity.Email);
        }

        internal static GContact ToGlobal(this Contact entity)
        {
            return new GContact() { Id = entity.Id, LastName = entity.LastName, FirstName = entity.FirstName, Email = entity.Email, Phone = entity.Phone, BirthDate = entity.BirthDate, CustomerId = entity.CustomerId };
        }

        internal static Contact ToClient(this GContact entity)
        {
            return new Contact(entity.Id, entity.LastName, entity.FirstName, entity.Email, entity.Phone, entity.BirthDate, entity.CustomerId);
        }
    }
}
