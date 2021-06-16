using System.Collections.Generic;

namespace Repositories.Base
{
    public interface IBaseRepository<T> where T : class

    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
        void Save();
    }
}
