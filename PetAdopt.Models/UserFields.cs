using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Models
{
    public partial class User
    {
        private ICollection<PetAdvertisement> petAdvertisements;
        private ICollection<PetCandidature> petCandidatures;
        private ICollection<Message> sentMessages;
        private ICollection<Message> recievedMessages;
        private ICollection<Notification> notifications;

        [Required]
        public string FirstName { get; set; }

        [Required]
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

        public virtual ICollection<Message> SentMessages
        {
            get
            {
                return this.sentMessages;
            }
            set
            {
                this.sentMessages = value;
            }
        }

        public virtual ICollection<Message> RecievedMessages
        {
            get
            {
                return this.recievedMessages;
            }
            set
            {
                this.recievedMessages = value;
            }
        }

        public virtual ICollection<Notification> Notifications
        {
            get
            {
                return this.notifications;
            }
            set
            {
                this.notifications = value;
            }
        }
    }
}
