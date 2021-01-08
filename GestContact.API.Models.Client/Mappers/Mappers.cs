﻿using GCustomer = GestContact.Models.Global.Entities.Customer;
using GContact = GestContact.Models.Global.Entities.Contact;
using GestContact.API.Models.Client.Entities;

namespace GestContact.API.Models.Client.Mappers
{
    static class Mappers
    {
        internal static GCustomer ToGlobal(this Customer entity)
        {
            return new GCustomer() { Id = entity.Id, LastName = entity.LastName, FirstName = entity.FirstName, Email = entity.Email, Passwd = entity.Passwd };
        }

        internal static Customer ToClient(this GCustomer entity)
        {
            return new Customer(entity.Id, entity.LastName, entity.FirstName);
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
