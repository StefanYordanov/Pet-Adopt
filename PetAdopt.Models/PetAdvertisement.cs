using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Models
{
    public class PetAdvertisement
    {
        private ICollection<PetCandidature> candidatures;

        public PetAdvertisement()
        {
            this.candidatures = new HashSet<PetCandidature>();
        }

        public int Id { get; set; }

        public int PetId { get; set; }

        public DateTime DatePosted { get; set; }

        [Required]
        public virtual Pet Pet { get; set; }

        public string AnnouncerId { get; set; }

        public virtual User Announcer { get; set; }

        public virtual ICollection<PetCandidature> Candidatures 
        {
            get
            {
                return this.candidatures;
            }
            set
            {
                this.candidatures = value;
            }
        }
    }
}
