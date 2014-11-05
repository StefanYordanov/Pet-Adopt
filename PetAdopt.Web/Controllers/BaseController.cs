using PetAdopt.Data;
using PetAdopt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
namespace PetAdopt.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IPetAdoptData Data;
        protected User LoggedUser;

        public BaseController(IPetAdoptData data)
        {
            this.Data = data;
        }
    }
}