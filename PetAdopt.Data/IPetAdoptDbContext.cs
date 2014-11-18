using PetAdopt.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
namespace PetAdopt.Data
{
    public interface IPetAdoptDbContext
    {
        IDbSet<Message> Messages { get; set; }
        IDbSet<Notification> Notifications { get; set; }
        IDbSet<PetCandidature> PetCandidatures { get; set; }
        IDbSet<Pet> Pets { get; set; }
        IDbSet<PetType> PetTypes { get; set; }
        int SaveChanges();
        DbEntityEntry Entry(object entry);
    }
}
