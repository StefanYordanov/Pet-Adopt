using PetAdopt.Data;
using PetAdopt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAdopt.Web.Controllers
{
    public class BaseDbContextController : Controller
    {
        public BaseDbContextController(IDeleteablePetAdoptData data)
        {
            this.Data = data;
        }

        protected IDeleteablePetAdoptData Data { get; set; }

        protected User CurrentUser { get; set; }
    }
}