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
using Microsoft.AspNet.Identity;

namespace PetAdopt.Web.Areas.Pets.Controllers
{
    public class AdvertisementController : Controller
    {
        private IRepository<PetAdvertisement> advertisements;
        private IDropDownListPopulator populator;
        private IRepository<Pet> pets;

        public AdvertisementController(
            IRepository<PetAdvertisement> advertisements, 
            IRepository<Pet> pets, 
            IDropDownListPopulator populator)
        {
            this.advertisements = advertisements;
            this.populator = populator;
            this.pets = pets;
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
            if (model == null || !ModelState.IsValid)
            {
                return View(model);
            }

            var dbModel = Mapper.Map<CreatePetViewModel, Pet>(model);

            var dbAdvertisement = new PetAdvertisement
            {
                AnnouncerId = User.Identity.GetUserId(),
                Pet = dbModel
            };

            this.advertisements.Add(dbAdvertisement);
            this.pets.Add(dbModel);
            this.advertisements.SaveChanges();


            //dbModel.PetAdvertisementId = dbAdvertisement.Id;

            TempData["success"] = "Pet Successfully Created!";
            return Redirect("/");
        }
    }
}