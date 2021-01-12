using GestContact.API.Models.Global.Repositories.Mappers;
using GestContact.API.Models.Global.Entities;
using GestContact.Models.Repositories;
using System;
using System.Linq;
using Tools.Connections.Database;

namespace GestContact.API.Models.Global.Repositories
{
    public class AuthRepository : IAuthRepository<Customer>
    {
        private readonly IConnection _connection;

        public AuthRepository(IConnection connection)
        {
            _connection = connection;
        }

        public Customer Login(string email, string passwd)
        {
            Command command = new Command("CSP_CheckCustomer", true);
            command.AddParameter("Email", email);
            command.AddParameter("Passwd", passwd);
            return _connection.ExecuteReader(command, (dr) => dr.ToCustomer()).SingleOrDefault();
        }

        public void Register(Customer entity)
        {
            Command command = new Command("CSP_RegisterCustomer", true);
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Passwd", entity.Passwd);
            _connection.ExecuteNonQuery(command);
        }
    }
}
