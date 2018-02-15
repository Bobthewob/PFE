﻿using STM.GDA.Web.BL;
using STM.GDA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STM.GDA.Web.Controllers
{
    public class DeploiementController : Controller
    {
        // GET: Deploiement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDeploiements(string filtre, int take, int offset = 0)
        {
            IEnumerable<DeploiementListeModel> deploiements = DeploiementBL.GetList(take, offset, filtre);

            //System.Threading.Thread.Sleep(1000); //use to test loading spinner on new filter

            if (!deploiements.Any())
            {
                return Json(new { status = "All_Loaded", message = "no element left to load" });
            }

            if (deploiements.Count() <= take)
            {
                deploiements.Last().DernierDeploiementAffiche = true;
            }

            return PartialView("_Liste", deploiements.Take(take).ToList());
        }
    }
}