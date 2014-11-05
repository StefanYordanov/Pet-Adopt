using Microsoft.AspNet.Identity.EntityFramework;
using PetAdopt.Data.Migrations;
using PetAdopt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Data
{
    public class PetAdoptDbContext : IdentityDbContext<User>
    {
        public PetAdoptDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PetAdoptDbContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Pet>()
            //.HasKey(e => e.PetAdvertisementId);
            //modelBuilder.Entity<Pet>()
            //            .Property(e => e.PetAdvertisementId)
            //            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //modelBuilder.Entity<Pet>()
            //            .HasRequired(e => e.PetAdvertisement)
            //            .WithRequiredDependent(s => s.Pet);
            //
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pet>()
            .HasKey(e => e.PetAdvertisementId);
            modelBuilder.Entity<Pet>()
                        .Property(e => e.PetAdvertisementId)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Pet>()
                        .HasRequired(e => e.PetAdvertisement)
                        .WithRequiredDependent(s => s.Pet);

            base.OnModelCreating(modelBuilder);
        }

        public static PetAdoptDbContext Create()
        {
            return new PetAdoptDbContext();
        }

        public IDbSet<Pet> Pets { get; set; }

        public IDbSet<PetAdvertisement> PetAdvertisements { get; set; }

        public IDbSet<PetCandidature> PetCandidatures { get; set; }

        public IDbSet<PetType> PetTypes { get; set; }


    }
}
