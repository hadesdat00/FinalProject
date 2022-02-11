﻿using System.Web.Mvc;
using FinalProject.Areas.Admin.Controllers;

namespace FinalProject.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
        "Admin_default",
        "Admin/{controller}/{action}/{id}",
        new { action = "Index", controller = "Login", id = UrlParameter.Optional },
        namespaces: new[] { "FinalProject.Areas.Admin.Controllers" }
    );


        }
    }
}