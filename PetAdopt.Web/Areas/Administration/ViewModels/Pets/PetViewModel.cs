using PetAdopt.Models;
using PetAdopt.Web.Areas.Administration.ViewModels.Base;
using PetAdopt.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAdopt.Web.Areas.Administration.ViewModels.Pets
{
    public class PetViewModel : AdministrationViewModel, IMapFrom<Pet>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        //public string OwnerId { get; set; }
        //
        //public virtual User Owner { get; set; }

        public decimal Cost { get; set; }

        public DateTime BirthDate { get; set; }

        public string Breed { get; set; }
    }
}