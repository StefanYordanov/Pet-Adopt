using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

//using Microsoft
namespace PetAdopt.Models
{
    public class User : IdentityUser
    {
        private ICollection<PetAdvertisement> petAdvertisements;
        private ICollection<PetCandidature> petCandidatures;

        public User()
        {
            this.petAdvertisements = new HashSet<PetAdvertisement>();
            this.petCandidatures = new HashSet<PetCandidature>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<PetAdvertisement> PetAdvertisements
        {
            get
            {
                return this.petAdvertisements;
            }
            set
            {
                this.petAdvertisements = value;
            }
        }

        public virtual ICollection<PetCandidature> PetCandidatures
        {
            get
            {
                return this.petCandidatures;
            }
            set
            {
                this.petCandidatures = value;
            }
        }
    }
}
