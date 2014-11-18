using PetAdopt.Data.Repositories;
using PetAdopt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AutoMapper.QueryableExtensions;
using PetAdopt.Web.Areas.User.ViewModels;

namespace PetAdopt.Web.Areas.User.Controllers
{
    public class NotificationsController : Controller
    {
        private IRepository<PetAdopt.Models.User> users;
        private IRepository<Notification> notifications;

        public NotificationsController(IRepository<PetAdopt.Models.User> users, IRepository<Notification> notifications)
        {
            this.users = users;
            this.notifications = notifications;
        }
        // GET: User/Notifications
        [Authorize]
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();

            var viewModel = this.notifications.All()
                .Where(n => n.RecieverId == currentUserId)
                .OrderByDescending(n=> n.CreatedOn).Project()
                .To<NotificationViewModel>().ToList();

            foreach (var notification in viewModel)
            {
                var dbNotification = this.notifications.Find(notification.Id);

                dbNotification.IsRead = true;
                this.notifications.Update(dbNotification);
            }

            this.notifications.SaveChanges();

            return View(viewModel);
        }

        
    }
}