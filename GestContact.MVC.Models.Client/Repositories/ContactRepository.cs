using GestContact.MVC.Models.Client.Entities;
using GestContact.Models.Repositories;
using GContact = GestContact.MVC.Models.Global.Entities.Contact;
using System.Collections.Generic;
using System.Linq;
using GestContact.MVC.Models.Client.Mappers;

namespace GestContact.MVC.Models.Client.Repositories
{
    public class ContactRepository : IContactRepository<Contact>
    {
        private readonly IContactRepository<GContact> _globalRepository;

        public ContactRepository(IContactRepository<GContact> globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public IEnumerable<Contact> Get(int customerId)
        {
            return _globalRepository.Get(customerId).Select(c => c.ToClient());
        }

        public Contact Get(int customerId, int id)
        {
            return _globalRepository.Get(customerId, id)?.ToClient();
        }

        public void Insert(Contact entity)
        {
            _globalRepository.Insert(entity.ToGlobal());
        }

        public void Update(int id, Contact entity)
        {
            _globalRepository.Update(id, entity.ToGlobal());
        }

        public void Delete(int customerId, int id)
        {
            _globalRepository.Delete(customerId, id);
        }
    }
}
