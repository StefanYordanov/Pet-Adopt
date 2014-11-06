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
        public IPetAdoptDbContext Context { get; set; }
        private IDictionary<Type, object> repositories;

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

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Pet> Pets
        {
            get { return this.GetRepository<Pet>(); }
        }

        public IRepository<PetAdvertisement> Advertisements
        {
            get { return this.GetRepository<PetAdvertisement>(); }
        }

        public IRepository<PetCandidature> Candidatures
        {
            get { return this.GetRepository<PetCandidature>(); }
        }

        public IRepository<PetType> PetTypes
        {
            get { return this.GetRepository<PetType>(); }
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
