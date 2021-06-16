using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbContext dBContext;
        protected DbSet<T> ts;

        public BaseRepository(DBContextApp dBContext)
        {
            this.dBContext = dBContext;
            this.ts = dBContext.Set<T>();
        }

        public T Add(T entity)
        {
            ts.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            ts.Remove(GetById(id));
        }

        public virtual IEnumerable<T> GetAll()
        {
            return ts.ToList();
        }

        public virtual T GetById(int id)
        {
            return ts.Find(id);
        }

        public void Save()
        {
            dBContext.SaveChanges();
        }

        public T Update(T entity)
        {
            ts.Attach(entity);
            dBContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
