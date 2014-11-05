using System;
using System.Linq;
namespace PetAdopt.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        IQueryable<T> All();
        T Delete(object id);
        T Delete(T entity);
        T Find(object id);
        int SaveChanges();
        void Update(T entity);
    }
}
