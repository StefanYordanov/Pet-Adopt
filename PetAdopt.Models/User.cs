using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PetAdopt.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

//using Microsoft
namespace PetAdopt.Models
{
    public partial class User : IdentityUser
    {
        public User()
        {
            CreatedOn = DateTime.Now;
            this.petAdvertisements = new HashSet<PetAdvertisement>();
            this.petCandidatures = new HashSet<PetCandidature>();

            this.notifications = new HashSet<Notification>();
            this.sentMessages = new HashSet<Message>();
            this.recievedMessages = new HashSet<Message>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn{ get; set; }

        public bool PreserveCreatedOn { get; set; }
        
    }
}
