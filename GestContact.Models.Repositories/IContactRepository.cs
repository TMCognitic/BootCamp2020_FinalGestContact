using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestContact.Models.Repositories
{
    public interface IContactRepository<TEntity>
    {
        IEnumerable<TEntity> Get(int customerId);
        TEntity Get(int customerId, int id);
        void Insert(TEntity entity);
        void Update(int id, TEntity entity);
        void Delete(int customerId, int id);
    }
}
