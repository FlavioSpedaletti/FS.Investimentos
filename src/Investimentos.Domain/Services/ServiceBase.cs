using Investimentos.Domain.Entities;
using Investimentos.Domain.Interfaces.Repositories;
using Investimentos.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Investimentos.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : EntityBase
    {
        protected readonly IRepositoryBase<T> _rep;

        public ServiceBase(IRepositoryBase<T> rep)
        {
            _rep = rep;
        }

        public void Update(T entity)
        {
            _rep.Update(entity);
        }

        public void Delete(int id)
        {
            _rep.Delete(id);
        }

        public void Delete(T entity)
        {
            _rep.Delete(entity);
        }

        public int Insert(T entity)
        {
            return _rep.Insert(entity);
        }

        public T GetById(int id)
        {
            return _rep.GetById(id);
        }

        public IEnumerable<T> Get()
        {
            return _rep.Get();
        }
    }
}