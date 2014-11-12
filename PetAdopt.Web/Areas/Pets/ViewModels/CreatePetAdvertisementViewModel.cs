using PetAdopt.Web.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAdopt.Web.Areas.Pets.ViewModels
{
    public class CreatePetViewModel
    {
        [Required]
        [UIHint("SingleLineText")]
        public string Name { get; set; }

        [UIHint("Decimal")]
        public decimal Cost { get; set; }

        [Required]
        [PastDateAttribute(ErrorMessage="The date must be in the future!")]
        [UIHint("Date")]
        public DateTime BirthDate { get; set; }

        [UIHint("SingleLineText")]
        public string Breed { get; set; }

        [Display(Name = "Type")]
        [UIHint("DropDownList")]
        public int TypeId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}