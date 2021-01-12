using GestContact.API.Models.Client.Entities;
using GestContact.Models.Repositories;
using GCustomer = GestContact.API.Models.Global.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestContact.API.Models.Client.Mappers;

namespace GestContact.API.Models.Client.Repositories
{
    public class AuthRepository : IAuthRepository<Customer>
    {
        private readonly IAuthRepository<GCustomer> _globalRepository;

        public AuthRepository(IAuthRepository<GCustomer> globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public Customer Login(string email, string passwd)
        {
            return _globalRepository.Login(email, passwd).ToClient();
        }

        public void Register(Customer entity)
        {
            _globalRepository.Register(entity.ToGlobal());
        }
    }
}
