using PetAdopt.Data.Repositories;
using PetAdopt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PetAdopt.Web.Areas.Pets.ViewModels;
using System.Data.Entity;
using PetAdopt.Web.Infrastructure.Populators;

namespace PetAdopt.Web.Areas.Pets.Controllers
{
    public class AdvertisementController : Controller
    {
        IRepository<PetAdvertisement> advertisements;
        IDropDownListPopulator populator;

        public AdvertisementController(IRepository<PetAdvertisement> advertisements, IDropDownListPopulator populator)
        {
            this.advertisements = advertisements;
            this.populator = populator;
        }

        // GET: Pets/Advertisement
        public ActionResult All()
        {
            var advertisements = this.advertisements.All()
                .Include(a=>a.Pet)
                .Project<PetAdvertisement>()
                .To<AllAdvertisementsViewModel>()
                .ToList();
            return View(advertisements);
        }

        public ActionResult Details(int id, string date)
        {
            return null;
        }

        [Authorize]
        public ActionResult Create()
        {
            var addTicketViewModel = new CreatePetViewModel
            {
                Categories = this.populator.GetPetTypes()
            };

            return View(addTicketViewModel);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(CreatePetViewModel model)
        {

            return null;
        }
    }
}