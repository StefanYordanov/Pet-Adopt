﻿using System.Web;
using System.Web.Optimization;

namespace PetAdopt.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /* bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/KendoUI/kendo.web.min.js",
                        "~/Scripts/KendoUI/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendoedit").Include(
                        "~/Scripts/KendoUI/kendo.editable.min.js",
                        "~/Scripts/KendoUI/kendo.editor.min.js",
                        "~/Scripts/KendoUI/kendo.datepicker.min.js"));
            

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/KendoUI/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/kendoall").Include(
                        "~/Scripts/KendoUI/kendo.all.min.js",
                        "~/Scripts/KendoUI/kendo.aspnetmvc.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));




            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));


            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                      "~/Content/KendoUI/kendo.common.min.css",
                      "~/Content/KendoUI/kendo.common-bootstrap.min.css",
                      "~/Content/KendoUI/kendo.moonlight.min.css"));

            bundles.Add(new StyleBundle("~/Content/custom").Include(
                      "~/Content/Site.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
             * 
             * */

            bundles.IgnoreList.Clear();

            //jqueryajax

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/KendoUI/kendo.all.min.js",
                        "~/Scripts/KendoUI/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/KendoUI/jquery.min.js"));
            //"~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                      "~/Content/KendoUI/kendo.common.min.css",
                      "~/Content/KendoUI/kendo.common-bootstrap.min.css",
                      "~/Content/KendoUI/kendo.moonlight.min.css"));

            bundles.Add(new StyleBundle("~/Content/custom").Include(
                      "~/Content/Site.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
