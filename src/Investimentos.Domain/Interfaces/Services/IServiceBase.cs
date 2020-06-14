using Investimentos.Domain.Entities;
using System.Collections.Generic;

namespace Investimentos.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : EntityBase
    {
        int Insert(T entity);
        void Delete(int id);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        IEnumerable<T> Get();
    }
}
