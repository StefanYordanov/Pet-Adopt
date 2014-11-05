using PetAdopt.Data.Repositories;
using PetAdopt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Data
{
    public interface IPetAdoptData
    {
        int SaveChanges();

        IRepository<User> Users { get; }

        IRepository<Pet> Pets { get; }

        IRepository<PetAdvertisement> Advertisements { get; }

        IRepository<PetCandidature> Candidatures { get; }

        IRepository<PetType> PetTypes { get; }
    }
}
