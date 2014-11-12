using System;
namespace PetAdopt.Models.Common
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
        bool PreserveCreatedOn { get; set; }
    }
}
