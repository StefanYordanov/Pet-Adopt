using PetAdopt.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Models
{
    public class Pet : DeleteableEntity, IAuditInfo, IDeletableEntity
    {
        //public int Id { get; set; }

        private ICollection<PetCandidature> candidatures;

        public Pet()
        {
            this.candidatures = new HashSet<PetCandidature>();
        }

        public string AnnouncerId { get; set; }

        public virtual User Announcer { get; set; }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public bool IsApproved { get; set; }

        public DateTime BirthDate { get; set; }

        public string Breed { get; set; }

        public string PictureUrl { get; set; }

        public int TypeId { get; set; }

        public virtual PetType Type { get; set; }

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
