using PetAdopt.Models;
using PetAdopt.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;



namespace PetAdopt.Web.Models.ViewModels.Home
{
    public class PetAdvertisementHomeViewModel : IMapFrom<Pet>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public DateTime BirthDate { get; set; }

        public string Type { get; set; }

        public decimal Cost { get; set; }

        public string PictureUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CandidaturesCount { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Pet, PetAdvertisementHomeViewModel>()
                .ForMember(dest => dest.CandidaturesCount, opts => opts.MapFrom(p => p.Candidatures.Count))
                .ForMember(dest => dest.Type, opts => opts.MapFrom(p => p.Type.Name));
        }

        
    }
}