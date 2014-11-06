using PetAdopt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AutoMapper.QueryableExtensions;

using Microsoft.AspNet.Identity;
using PetAdopt.Models;
using PetAdopt.Data.Repositories;
using PetAdopt.Web.Models.ViewModels.Home;
namespace PetAdopt.Web.Controllers
{
    public class HomeController : Controller
    {
        private const int TopPetsCount = 5;

        private IRepository<PetAdvertisement> advertisements;
        public HomeController(IRepository<PetAdvertisement> advertisements)
        {
            this.advertisements = advertisements;
        }
        

        public ActionResult Index()
        {
            var homeView = new HomeViewModel();

            homeView.TopAdvertisements = this.advertisements.All().OrderByDescending(a => a.Candidatures.Count)
                .Take(TopPetsCount)
                .Project().To<PetAdvertisementHomeViewModel>()
                .ToList();

            homeView.LatestAdvertisements = this.advertisements.All().OrderByDescending(a => a.DatePosted)
                .Take(TopPetsCount)
                .Project().To<PetAdvertisementHomeViewModel>()
                .ToList();

            return View(homeView);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}