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
    public class Message : DeleteableEntity, IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public string SenderId { get; set; }

        public virtual User Sender { get; set; }

        public string RecieverId { get; set; }

        public virtual User Reciever { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsRead { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }
    }
}
