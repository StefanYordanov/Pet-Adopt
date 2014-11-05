using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Models
{
    public class PetCandidature
    {
        public int Id { get; set; }

        public string CandidateId { get; set; }

        public virtual User Candidate { get; set; }

        public DateTime DatePosted { get; set; }

        public int AdvertisementId { get; set; }

        public virtual PetAdvertisement Advertisement { get; set; }
    }
}
