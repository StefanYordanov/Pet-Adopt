using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAdopt.Web.Areas.User.Controllers
{
    public class NotificationsController : Controller
    {
        // GET: User/Notifications
        public ActionResult Index()
        {
            return View();
        }
    }
}