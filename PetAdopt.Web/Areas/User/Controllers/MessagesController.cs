using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAdopt.Web.Areas.User.Controllers
{
    public class MessagesController : Controller
    {
        // GET: User/Messages
        public ActionResult Index()
        {
            return View();
        }
    }
}