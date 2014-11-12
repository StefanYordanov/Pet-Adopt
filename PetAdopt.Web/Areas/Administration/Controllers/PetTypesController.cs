using Kendo.Mvc.UI;
using PetAdopt.Data;
using PetAdopt.Data.Repositories;
using PetAdopt.Models;
using PetAdopt.Web.Areas.Administration.ViewModels.PetTypes;
using System;
using System.Collections;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAdopt.Web.Areas.Administration.Controllers
{
    public class PetTypesController : KendoGridAdministrationController
    {
        public PetTypesController(IDeleteablePetAdoptData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            var data = this.Data.PetTypes.All().ToList();
            return data;
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.PetTypes.Find(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, PetTypeViewModel model)
        {
            var dbModel = base.Create<PetType>(model);
            if (dbModel != null) model.Id = dbModel.Id;
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, PetTypeViewModel model)
        {
            base.Update<PetType, PetTypeViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, PetTypeViewModel model)
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