using STM.GDA.Web.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STM.GDA.Web.Controllers
{
    public class ComposantController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetComposants(string filtre)
        {
            var composants = ComposantBL.GetList();

            if (!String.IsNullOrEmpty(filtre))
            {
                composants = composants.Where(x => x.Nom.Contains(filtre)).ToList();
            }

            return PartialView("_Liste", composants);
        }

        public ActionResult Details(int id)
        {
            var composant = ComposantBL.GetComposant(id);

            if (composant == null)
            {
                return View("Error");
            }
            else
            {
                return View("Details", composant);
            }
        }
    }
}   