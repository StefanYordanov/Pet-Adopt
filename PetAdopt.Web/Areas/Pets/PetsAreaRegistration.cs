﻿using System.Web.Mvc;

namespace PetAdopt.Web.Areas.Pets
{
    public class PetsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Pets";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Pets_default",
                "Pets/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            //context.MapRoute(
            //    "Pets_details",
            //    "Pets/Advertisement/Details/{id}/{date}"
            //);
        }
    }
}