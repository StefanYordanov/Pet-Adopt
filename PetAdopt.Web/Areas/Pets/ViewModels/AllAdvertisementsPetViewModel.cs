using PetAdopt.Models;
using PetAdopt.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetAdopt.Web.Areas.Pets.ViewModels
{
    public class AllAdvertisementsPetViewModel : IMapFrom<Pet>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string Breed { get; set; }

        public string Type { get; set; }

        public DateTime BirthDate { get; set; }

        public string PictureUrl { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Pet, AllAdvertisementsPetViewModel>()
                .ForMember(dest=> dest.Type, opts=> opts.MapFrom(p=>p.Type.Name));
        }
    }
}