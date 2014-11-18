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
using PetAdopt.Web.Models.ViewModels.Home;
using System.IO;
using PetAdopt.Common;
using System.Data.Entity;

namespace PetAdopt.Web.Areas.Pets.Controllers
{
    public class AdvertisementController : Controller
    {
        private IDropDownListPopulator populator;
        private IRepository<Pet> pets;
        private IRepository<PetCandidature> candidatures;

        public AdvertisementController(
            IRepository<Pet> pets,
            IRepository<PetCandidature> candidatures, 
            IDropDownListPopulator populator)
        {
            this.populator = populator;
            this.pets = pets;
            this.candidatures = candidatures;
        }

        [HttpPost]
        public ActionResult All(SearchFormProperties props)
        {
            if (props==null)
            {
                return Redirect("/Pets/Advertisements/All");
            }
            if (props.TypeId==null)
            {
                return Redirect("/Pets/Advertisements/All");
            }

            var advertisements = this.pets.All().Where(p => !p.IsApproved && p.TypeId == props.TypeId)
                .Project<Pet>()
                .To<PetAdvertisementHomeViewModel>()
                .ToList();

            var listItems = this.populator.GetPetTypes();
            var viewModel = new AllAdvertisementsPetViewModel
            {
                Advertisements = advertisements,
                SearchProperties = new SearchFormProperties
                 {
                     Categories = listItems
                 }
            };
            return View(viewModel);


        }

        // GET: Pets/Advertisement
        public ActionResult All()
        {
            var advertisements = this.pets.All().Where(p=>!p.IsApproved)
                .Project<Pet>()
                .To<PetAdvertisementHomeViewModel>()
                .ToList();

            var listItems = this.populator.GetPetTypes();
            var viewModel = new AllAdvertisementsPetViewModel
            {
                 Advertisements= advertisements,
                 SearchProperties = new SearchFormProperties
                 {
                      Categories = listItems
                 }
            };
            return View(viewModel);
        }

        public ActionResult Details(int id, string date)
        {
            try
            {
                //var creationDate = DateTime.ParseExact(date, PetAdopt.Common.DateTimeExtensions.UrlDateTimeFormat, null);
                var model = this.pets.Find(id);

                if (model == null)
                {
                    TempData["error"] = "Invalid Pet Url!";
                    return Redirect("/");
                }

                if (model.CreatedOn.ToString(PetAdopt.Common.DateTimeExtensions.UrlDateTimeFormat) != date)
                {
                    TempData["error"] = "Invalid Pet Url!";
                    return Redirect("/");
                }

                if (model.IsApproved)
                {
                    TempData["error"] = "Pet's no longer available for adoption!";
                    return Redirect("/");
                }

                var viewModel = Mapper.Map<PetAdvertisementDetailsViewModel>(model);

                viewModel.Candidatures = model.Candidatures.AsQueryable().OrderByDescending(c=> c.CreatedOn).Project().To<CandidatureViewModel>().ToList();

                viewModel.IsMine = model.AnnouncerId == User.Identity.GetUserId();
                //viewModel.OwnerName = model.Announcer.FirstName + " " + model.Announcer.LastName;
                return View(viewModel);
            }
            catch(Exception)
            {
                TempData["error"] = "Invalid Pet Url!";
                return Redirect("/");
            }
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
                TempData["error"] = "Invalid model!";
                model.Categories = this.populator.GetPetTypes();
                return View(model);
            }

            var dbModel = Mapper.Map<CreatePetViewModel, Pet>(model);
            dbModel.AnnouncerId = User.Identity.GetUserId();

            this.pets.Add(dbModel);
            this.pets.SaveChanges();

            if (model.UploadedImage != null)
            {
                var splittedName = model.UploadedImage.FileName.Split('.');
                if (splittedName.Last().ToLower()=="jpg" || splittedName.Last().ToLower() == "png")
	            {

                    var fileName = string.Format("{0}_{1}.{2}",
                                   dbModel.CreatedOn.ToString(DateTimeExtensions.DirectoryDateTimeFormat),
                                   dbModel.Id, splittedName.Last().ToLower());
                    //var path = string.Format("~/Content/Images/Pets/{0}_{1}.{2}", 
                    //    dbModel.CreatedOn.ToString(DateTimeExtensions.UrlDateTimeFormat), dbModel.Id, splittedName.Last());

                    var path = System.IO.Path.Combine(
                                   Server.MapPath("~/Content/Images/Pets/"), 
                                   fileName);
                    model.UploadedImage.SaveAs(path);

                    dbModel.PictureUrl = "/Content/Images/Pets/" + fileName;

                    this.pets.SaveChanges();
	            }
            }

            TempData["success"] = "Pet Successfully Created!";
            return Redirect("/");
        }
    }
}