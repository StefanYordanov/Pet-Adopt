using Microsoft.AspNet.Identity.EntityFramework;
using PetAdopt.Data.Migrations;
using PetAdopt.Models;
using PetAdopt.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Data
{
    public class PetAdoptDbContext : IdentityDbContext<User>, IPetAdoptDbContext
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

            modelBuilder.Entity<Message>()
                    .HasRequired(m => m.Reciever)
                    .WithMany(t => t.RecievedMessages)
                    .HasForeignKey(m => m.RecieverId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                        .HasRequired(m => m.Sender)
                        .WithMany(t => t.SentMessages)
                        .HasForeignKey(m => m.SenderId)
                        .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public static PetAdoptDbContext Create()
        {
            return new PetAdoptDbContext();
        }

        public IDbSet<Pet> Pets { get; set; }

        public IDbSet<PetCandidature> PetCandidatures { get; set; }

        public IDbSet<PetType> PetTypes { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
