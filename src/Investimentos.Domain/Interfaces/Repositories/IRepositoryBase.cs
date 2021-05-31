using Investimentos.Domain.Entities;
using System.Collections.Generic;

namespace Investimentos.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        void Insert(T entity);
        void Delete(int id);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        IEnumerable<T> Get();
    }
}
