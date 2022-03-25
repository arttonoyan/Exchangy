using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exchangy.FixerIoFramework.DataAccess
{
    internal class Repository<Tentity> : IRepository<Tentity> where Tentity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(Tentity entity)
        {
            Context.Set<Tentity>().Add(entity);
        }

        public void AddRange(IEnumerable<Tentity> entities)
        {
            Context.Set<Tentity>().AddRange(entities);
        }

        public IEnumerable<Tentity> Find(Expression<Func<Tentity, bool>> predicate)
        {
            return Context.Set<Tentity>().Where(predicate);
        }

        public Tentity Get(int id)
        {
           return Context.Set<Tentity>().Find(id); 
        }

        public IEnumerable<Tentity> GetAll()
        {
            return Context.Set<Tentity>().ToList();
        }

        public void Remove(Tentity entity)
        {
           Context.Set<Tentity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Tentity> entities)
        {
            Context.Set<Tentity>().RemoveRange(entities);
        }

        public void Save()
        {
           Context.SaveChanges();
        }
    }
}
