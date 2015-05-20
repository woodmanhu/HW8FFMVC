﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QiwenFFMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Models.FFUser ffu = new Models.FFUser();
            ffu.Name = "Joe Schmoe";
            ViewBag.FFUser = ffu;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}