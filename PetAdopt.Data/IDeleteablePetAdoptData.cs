using PetAdopt.Data.Repositories;
using PetAdopt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Data
{
    public interface IDeleteablePetAdoptData
    {
        int SaveChanges();

        IPetAdoptDbContext Context { get; set; }

        IRepository<User> Users { get; }

        IDeletableEntityRepository<Pet> Pets { get; }

        IDeletableEntityRepository<PetCandidature> Candidatures { get; }

        IDeletableEntityRepository<PetType> PetTypes { get; }
    }
}
