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
    public interface IPetAdoptData
    {
        int SaveChanges();

        IPetAdoptDbContext Context { get; set; }

        IRepository<User> Users { get; }

        IRepository<Pet> Pets { get; }

        IRepository<PetCandidature> Candidatures { get; }

        IRepository<PetType> PetTypes { get; }
    }
}
