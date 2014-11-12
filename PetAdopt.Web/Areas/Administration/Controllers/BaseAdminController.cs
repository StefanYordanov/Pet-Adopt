using PetAdopt.Data;
using PetAdopt.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAdopt.Web.Areas.Administration.Controllers
{
    [Authorize(Roles="admin")]
    public class BaseAdminController : BaseDbContextController
    {
        public BaseAdminController(IDeleteablePetAdoptData data) 
            : base(data)
        {

        }
    }
}