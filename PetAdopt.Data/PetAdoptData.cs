using PetAdopt.Data.Repositories;
using PetAdopt.Models;
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
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public PetAdoptData()
            : this(new PetAdoptDbContext())
        {
        }

        public PetAdoptData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public IRepository<User> Users
        {
            get { throw new NotImplementedException(); }
        }

        public IRepository<Pet> Pets
        {
            get { throw new NotImplementedException(); }
        }

        public IRepository<PetAdvertisement> Advertisements
        {
            get { throw new NotImplementedException(); }
        }

        public IRepository<PetCandidature> Candidatures
        {
            get { throw new NotImplementedException(); }
        }

        public IRepository<PetType> PetTypes
        {
            get { throw new NotImplementedException(); }
        }
    }
}
