using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Data.Repositories
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public class EFRepository<T> : IRepository<T> where T: class
    {
        protected DbContext context;
        private IDbSet<T> set;

        public EFRepository() : this(new PetAdoptDbContext())
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public EFRepository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public virtual IQueryable<T> All()
        {
            return this.set;
        }

        public T Find(object id)
        {
            return this.set.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public virtual T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public T Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
            return entity;
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }


        public virtual void Detach(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);

            entry.State = EntityState.Detached;
        }
    }
}
