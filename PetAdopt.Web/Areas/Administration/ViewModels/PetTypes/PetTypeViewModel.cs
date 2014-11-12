using PetAdopt.Models;
using PetAdopt.Web.Areas.Administration.ViewModels.Base;
using PetAdopt.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAdopt.Web.Areas.Administration.ViewModels.PetTypes
{
    public class PetTypeViewModel : AdministrationViewModel, IMapFrom<PetType>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}