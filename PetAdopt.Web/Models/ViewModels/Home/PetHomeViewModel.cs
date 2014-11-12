using PetAdopt.Models;
using PetAdopt.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetAdopt.Web.Models.ViewModels.Home
{
    public class PetHomeViewModel : IMapFrom<Pet>
    {
        public string Name { get; set; }

        public string Breed { get; set; }

        public DateTime BirthDate { get; set; }

        public PetType Type { get; set; }

        public decimal Cost { get; set; }

        public string PictureUrl { get; set; }

        public int Candidatures { get; set; }
    }
}