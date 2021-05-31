using Investimentos.Domain.Entities;
using Investimentos.Domain.Interfaces.Repositories;
using Investimentos.Domain.Interfaces.Services;
using Investimentos.Domain.Interfaces.UOW;
using System.Collections.Generic;

namespace Investimentos.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : EntityBase
    {
        private readonly IRepositoryBase<T> _rep;
        private readonly IUnitOfWork _uow;

        public ServiceBase(IRepositoryBase<T> rep, IUnitOfWork uow)
        {
            _rep = rep;
            _uow = uow;
        }

        public void Update(T entity)
        {
            _rep.Update(entity);
            _uow.Commit();
        }

        public void Delete(int id)
        {
            _rep.Delete(id);
            _uow.Commit();
        }

        public void Delete(T entity)
        {
            _rep.Delete(entity);
            _uow.Commit();
        }

        public int Insert(T entity)
        {
            _rep.Insert(entity);
            _uow.Commit();

            return entity.Id;
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