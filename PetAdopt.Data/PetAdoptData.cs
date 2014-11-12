using PetAdopt.Data.Repositories;
using PetAdopt.Models;
using PetAdopt.Models.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Data
{
    public class PetAdoptData : IPetAdoptData
    {
        public IPetAdoptDbContext Context { get; set; }
        protected IDictionary<Type, object> repositories;

        public PetAdoptData()
            : this(new PetAdoptDbContext())
        {
        }

        public PetAdoptData(IPetAdoptDbContext context)
        {
            this.Context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), Context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        private IRepository<T> GetDeleteableRepository<T>() where T : class, IDeletableEntity
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(DeletableEntityRepository<T>), Context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public virtual IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public virtual IRepository<Pet> Pets
        {
            get { return this.GetDeleteableRepository<Pet>(); }
        }

        public virtual IRepository<PetAdvertisement> Advertisements
        {
            get { return this.GetDeleteableRepository<PetAdvertisement>(); }
        }

        public virtual IRepository<PetCandidature> Candidatures
        {
            get { return this.GetDeleteableRepository<PetCandidature>(); }
        }

        public virtual IRepository<PetType> PetTypes
        {
            get { return this.GetDeleteableRepository<PetType>(); }
        }


        IPetAdoptDbContext IPetAdoptData.Context
        {
            get
            {
                return this.Context;
            }
            set
            {
                this.Context = value;
            }
        }
    }
}
