using PetAdopt.Models.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Data.Repositories
{
    public class DeletableEntityRepository<T> : EFRepository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity
    {
        public DeletableEntityRepository()
            : this(new PetAdoptDbContext())
        {
        }

        public DeletableEntityRepository(DbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.All();
        }

        public override T Delete(T entity)
        {
            entity.DeletedOn = DateTime.Now;
            entity.IsDeleted = true;

            DbEntityEntry entry = this.context.Entry(entity);
            entry.State = EntityState.Modified;
            this.context.SaveChanges();
            return entity;
        }

        public T ActualDelete(T entity)
        {
            return base.Delete(entity);
        }
    }
}
