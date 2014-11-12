using PetAdopt.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Models
{
    public class PetCandidature : DeleteableEntity, IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string CandidateId { get; set; }

        public virtual User Candidate { get; set; }

        public int AdvertisementId { get; set; }

        public virtual PetAdvertisement Advertisement { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }
    }
}
