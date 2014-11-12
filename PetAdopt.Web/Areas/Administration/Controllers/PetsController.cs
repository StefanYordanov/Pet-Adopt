using Kendo.Mvc.UI;
using PetAdopt.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PetAdopt.Web.Areas.Administration.ViewModels.Pets;
using PetAdopt.Models;

namespace PetAdopt.Web.Areas.Administration.Controllers
{
    public class PetsController : KendoGridAdministrationController
    {
        // GET: Administration/Pets
        public PetsController(IDeleteablePetAdoptData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            var data = this.Data.Pets.All().ToList();
            return data;
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Pets.Find(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, PetViewModel model)
        {
            var dbModel = base.Create<Pet>(model);
            if (dbModel != null) model.Id = dbModel.PetAdvertisementId;
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, PetViewModel model)
        {
            base.Update<Pet, PetViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, PetViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var name = this.Data.PetTypes.GetType().Name;
                this.Data.PetTypes.Delete(model.Id.Value);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}