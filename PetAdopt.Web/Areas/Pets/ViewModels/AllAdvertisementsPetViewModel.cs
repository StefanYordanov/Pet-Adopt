using PetAdopt.Models;
using PetAdopt.Web.Infrastructure.Mapping;
using PetAdopt.Web.Models.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAdopt.Web.Areas.Pets.ViewModels
{
    public class AllAdvertisementsPetViewModel
    {
        public IList<PetAdvertisementHomeViewModel> Advertisements { get; set; }

        public SearchFormProperties SearchProperties { get; set; }
    }

    public class SearchFormProperties
    {
        public IEnumerable<SelectListItem> Categories { get; set; }

        [Display(Name = "Pet Type")]
        public int? TypeId { get; set; }
    }
}