using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Models.Common
{
    public class DeleteableEntity : AuditInfo, IDeletableEntity
    {
        [Editable(false)]
        public bool IsDeleted { get; set; }

        [Editable(false)]
        public DateTime? DeletedOn { get; set; }
    }
}
