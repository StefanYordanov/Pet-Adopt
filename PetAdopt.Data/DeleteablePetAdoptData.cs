using PetAdopt.Data.Repositories;
using PetAdopt.Models;
using PetAdopt.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Data
{
    public class DeleteablePetAdoptData : IDeleteablePetAdoptData
    {
        public IPetAdoptDbContext Context { get; set; }
        protected IDictionary<Type, object> repositories;

        public DeleteablePetAdoptData()
            : this(new PetAdoptDbContext())
        {
        }

        public DeleteablePetAdoptData(IPetAdoptDbContext context)
        {
            this.Context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IDeletableEntityRepository<Pet> Pets
        {
            get { return GetDeleteableRepository<Pet>(); }
        }

        public IDeletableEntityRepository<PetCandidature> Candidatures
        {
            get { return GetDeleteableRepository<PetCandidature>(); }
        }

        public IDeletableEntityRepository<PetType> PetTypes
        {
            get { return GetDeleteableRepository<PetType>(); }
        }

        private IDeletableEntityRepository<T> GetDeleteableRepository<T>() where T : class, IDeletableEntity
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(DeletableEntityRepository<T>), Context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeOfRepository];
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
    }
}
