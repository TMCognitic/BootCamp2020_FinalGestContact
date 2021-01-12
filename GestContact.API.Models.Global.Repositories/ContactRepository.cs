using GestContact.API.Models.Global.Repositories.Mappers;
using GestContact.API.Models.Global.Entities;
using GestContact.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Tools.Connections.Database;

namespace GestContact.API.Models.Global.Repositories
{
    public class ContactRepository : IContactRepository<Contact>
    {
        private readonly IConnection _connection;

        public ContactRepository(IConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Contact> Get(int customerId)
        {
            Command command = new Command("Select Id, LastName, FirstNAme, Email, Phone, BirthDate, CustomerId from Contact where CustomerId = @CustomerId");
            command.AddParameter("CustomerId", customerId);

            return _connection.ExecuteReader(command, (dr) => dr.ToContact());
        }

        public Contact Get(int customerId, int id)
        {
            Command command = new Command("Select Id, LastName, FirstNAme, Email, Phone, BirthDate, CustomerId from Contact where CustomerId = @CustomerId and Id = @Id");
            command.AddParameter("CustomerId", customerId);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, (dr) => dr.ToContact()).SingleOrDefault();
        }

        public void Insert(Contact entity)
        {
            Command command = new Command("CSP_AddContact", true);
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Phone", entity.Phone);
            command.AddParameter("BirthDate", entity.BirthDate);
            command.AddParameter("CustomerId", entity.CustomerId);
            _connection.ExecuteNonQuery(command);
        }

        public void Update(int id, Contact entity)
        {
            Command command = new Command("CSP_UpdateContact", true);
            command.AddParameter("Id", id);
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Phone", entity.Phone);
            command.AddParameter("BirthDate", entity.BirthDate);
            command.AddParameter("CustomerId", entity.CustomerId);
            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int customerId, int id)
        {
            Command command = new Command("CSP_DeleteContact", true);
            command.AddParameter("Id", id);
            command.AddParameter("CustomerId", customerId);
            _connection.ExecuteNonQuery(command);
        }
    }
}
