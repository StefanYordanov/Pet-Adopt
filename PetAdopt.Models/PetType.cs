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
    public class PetType: DeleteableEntity, IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [Index(IsUnique=true)]
        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn{ get; set; }

        public bool PreserveCreatedOn { get; set; }
    }
}
