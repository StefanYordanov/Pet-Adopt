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
using PetAdopt.Web.Models.ViewModels;
namespace PetAdopt.Web.Controllers
{
    public class HomeController : Controller
    {
        private const int TopPetsCount = 5;

        private IRepository<PetAdvertisement> advertisements;
        private IRepository<Notification> notifications;
        private IRepository<Message> messages;
        //private IRepository<User> users;

        public HomeController(IRepository<PetAdvertisement> advertisements, 
            IRepository<Notification> notifications, 
            IRepository<Message> messages)
        {
            this.advertisements = advertisements;
            this.notifications = notifications;
            this.messages = messages;;
        }
        
        [ChildActionOnly]
        [OutputCache(Duration=3*60)]
        public ActionResult GetTopPetsPartial()
        {
            var homeView = new HomeViewModel();

            homeView.TopAdvertisements = this.advertisements.All().OrderByDescending(a => a.Candidatures.Count)
                .Take(TopPetsCount)
                .Project().To<PetAdvertisementHomeViewModel>()
                .ToList();

            homeView.LatestAdvertisements = this.advertisements.All().OrderByDescending(a => a.CreatedOn)
                .Take(TopPetsCount)
                .Project().To<PetAdvertisementHomeViewModel>()
                .ToList();

            return PartialView("_TopPetAdvertisements", homeView);

        }

        [Authorize]
        public ActionResult GetNotificationsAndMessagesPartial()
        {
            var userId = this.User.Identity.GetUserId();

            var messagesAndNotifications = new NotificationsAndMessagesViewModel();
            messagesAndNotifications.MessagesCount = this.messages.All()
                .Where(m => m.RecieverId == userId && !m.IsRead)
                .Count();

            messagesAndNotifications.NotificationsCount = this.notifications.All()
                .Where(n => n.RecieverId == userId && !n.IsRead).Count();

            return PartialView("_NotificationsAndMessages", messagesAndNotifications);
        }

        public ActionResult Index()
        {
            return View();
            //var homeView = new HomeViewModel();
            //
            //homeView.TopAdvertisements = this.advertisements.All().OrderByDescending(a => a.Candidatures.Count)
            //    .Take(TopPetsCount)
            //    .Project().To<PetAdvertisementHomeViewModel>()
            //    .ToList();
            //
            //homeView.LatestAdvertisements = this.advertisements.All().OrderByDescending(a => a.CreatedOn)
            //    .Take(TopPetsCount)
            //    .Project().To<PetAdvertisementHomeViewModel>()
            //    .ToList();
            //
            //return View(homeView);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}