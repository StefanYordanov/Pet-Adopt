using PetAdopt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetAdopt.Web.Models.ViewModels.Home
{
    public class HomeViewModel
    {
        public ICollection<PetAdvertisementHomeViewModel> TopAdvertisements { get; set; }
        public ICollection<PetAdvertisementHomeViewModel> LatestAdvertisements { get; set; }
    }
}