using System;

namespace GestContact.Models.Repositories
{
    public interface IAuthRepository<TEntity>
    {
        TEntity Login(string email, string passwd);
        void Register(TEntity entity);
    }
}
