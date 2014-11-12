using PetAdopt.Data.Repositories;
using PetAdopt.Models;
using PetAdopt.Web.Infrastructure.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAdopt.Web.Infrastructure.Populators
{
    public class DropDownListPopulator : IDropDownListPopulator
    {
        private IRepository<PetType> petTypes;
        private ICacheService cache;

        public DropDownListPopulator(IRepository<PetType> petTypes, ICacheService cache)
        {
            this.petTypes = petTypes;
            this.cache = cache;
        }

        public IEnumerable<SelectListItem> GetPetTypes()
        {
            var categories = this.cache.Get<IEnumerable<SelectListItem>>("categories",
                () =>
                {
                    return this.petTypes
                       .All()
                       .OrderBy(t=> t.Name)
                       .Select(c => new SelectListItem
                       {
                           Value = c.Id.ToString(),
                           Text = c.Name
                       })
                       .ToList();
                }, TimeSpan.FromHours(4));

            return categories;
        }
    }
}