using Investimentos.Domain.Entities;
using Investimentos.Domain.Interfaces.Repositories;
using Investimentos.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Investimentos.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly EFContext _ctx;

        public RepositoryBase(EFContext ctx) : base()
        {
            _ctx = ctx;
        }

        public void Update(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _ctx.Set<T>().Remove(entity);
            }
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
        }

        public void Insert(T entity)
        {
            //_ctx.Set<T>().Add(entity).Entity.Id;
            _ctx.Set<T>().Add(entity);
        }

        public T GetById(int id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public IEnumerable<T> Get()
        {
            return _ctx.Set<T>().ToList();
        }
    }
}
