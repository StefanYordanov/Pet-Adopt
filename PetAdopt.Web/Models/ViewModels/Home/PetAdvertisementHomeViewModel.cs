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
    public class PetAdvertisementHomeViewModel : IMapFrom<PetAdvertisement>, IHaveCustomMappings
    {
        public PetHomeViewModel Pet { get; set; }

        public int CandidaturesCount { get; set; }

        /*public static Expression<Func<PetAdvertisement, PetAdvertisementHomeViewModel>> FromPetAdvertisement
        {
            get
            {
                return p => new PetAdvertisementHomeViewModel
                {
                    BirthDate = p.Pet.BirthDate,
                    Name = p.Pet.Name,
                    Cost = p.Pet.Cost,
                    Type = p.Pet.Type,
                    CandidaturesCount = p.Candidatures.Count,
                    PictureUrl = p.Pet.PictureUrl
                };
            }
        }
         * */

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<PetAdvertisement, PetAdvertisementHomeViewModel>()
                .ForMember(dest => dest.CandidaturesCount, opts => opts.MapFrom(p => p.Candidatures.Count));
        }
    }
}