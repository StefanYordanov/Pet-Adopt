using PetAdopt.Models;
using PetAdopt.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetAdopt.Web.Areas.Pets.ViewModels
{
    public class AllAdvertisementsViewModel : IMapFrom<PetAdvertisement>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public AllAdvertisementsPetViewModel Pet { get; set; }

        public string AnnouncerName { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<PetAdvertisement, AllAdvertisementsViewModel>()
                .ForMember(dest => dest.AnnouncerName, opts => opts.MapFrom(p => p.Announcer.UserName)).ReverseMap();
        }
    }
}