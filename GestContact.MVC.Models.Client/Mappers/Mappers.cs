using GCustomer = GestContact.MVC.Models.Global.Entities.Customer;
using GContact = GestContact.MVC.Models.Global.Entities.Contact;
using GestContact.MVC.Models.Client.Entities;

namespace GestContact.MVC.Models.Client.Mappers
{
    static class Mappers
    {
        internal static GCustomer ToGlobal(this Customer entity)
        {
            return new GCustomer() { Id = entity.Id, LastName = entity.LastName, FirstName = entity.FirstName, Email = entity.Email, Passwd = entity.Passwd };
        }

        internal static Customer ToClient(this GCustomer entity)
        {
            return new Customer(entity.Id, entity.LastName, entity.FirstName, entity.Email, entity.Token);
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
