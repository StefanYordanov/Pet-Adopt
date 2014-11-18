using PetAdopt.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Models
{
    public class Notification : DeleteableEntity, IAuditInfo, IDeletableEntity
    {
        public int Id{get; set;}

        public string RecieverId { get; set; }

        public User Reciever { get; set; }

        public string Content { get; set; }

        public bool IsRead { get; set; }

    }
}
