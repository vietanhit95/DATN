﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADS.APP.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Home()
        {
            return View();
        }
    }
}