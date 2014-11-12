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

        [Required]
        public string Name { get; set; }

        //public string OwnerId { get; set; }
        //
        //public virtual User Owner { get; set; }

        public decimal Cost { get; set; }

        public DateTime BirthDate { get; set; }

        public string Breed { get; set; }

        public string PictureUrl { get; set; }

        public int TypeId { get; set; }

        public virtual PetType Type { get; set; }

        [Key, ForeignKey("PetAdvertisement")]
        public int PetAdvertisementId { get; set; }

        public virtual PetAdvertisement PetAdvertisement { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }




    }
}
