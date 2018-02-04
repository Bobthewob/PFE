using STM.GDA.Web.BL;
using STM.GDA.Web.Configuration;
using STM.GDA.Web.Extensions;
using STM.GDA.Web.Models;
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

        public ActionResult GetComposants(string filtre, int take, int offset = 0)
        {
            IEnumerable<ComposantListeModel> composants = ComposantBL.GetList();
      
            if (!String.IsNullOrEmpty(filtre))
            {
                filtre = filtre.ToLowerInvariant();

                composants = composants.Where(x => x.Nom.ToLowerInvariant().Contains(filtre) ||
                x.Description.ToLowerInvariant().Contains(filtre) ||
                x.Technologies.Any(t => t.Nom.ToLowerInvariant().Contains(filtre)) ||
                x.Dependances.Any(d => d.Nom.ToLowerInvariant().Contains(filtre)));
            }

            //System.Threading.Thread.Sleep(2000); //use to test loading spinner on new filter

            composants = composants.Skip(offset);

            if (!composants.Take(take).Any())
               return Json(new { status = "All_Loaded", message = "no element left to load" });

            return PartialView("_Liste", composants.Take(take).ToList());
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

        public ActionResult Creer()
        {
            ViewBag.ListeTypes = TypeBL.GetAllTypes().Select(x => x.ToSelectListItem());
            ViewBag.ListeClients = ClientBL.GetAllClients().Select(x => x.ToSelectListItem());
            ViewBag.ListeResponsables = ResponsableBL.GetAllResponsables().Select(x => x.ToSelectListItem());

            return View("Creer", new ComposantModel());
        }

        [HttpPost]
        public ActionResult Creer(ComposantModel composant)
        {
            ComposantBL.CreerComposant(composant);
            return Redirect("Details", "Composant", new { id = composant.Id });
        }

        public ActionResult Modifier(int id)
        {
            var composant = ComposantBL.GetComposant(id);

            ViewBag.ListeTypes = TypeBL.GetAllTypes().Select(x => x.ToSelectListItem());
            ViewBag.ListeClients = ClientBL.GetAllClients().Select(x => x.ToSelectListItem());
            ViewBag.ListeResponsables = ResponsableBL.GetAllResponsables().Select(x => x.ToSelectListItem());

            if (composant == null)
            {
                return View("Error");
            }
            else
            {
                return View("Modifier", composant);
            }
        }

        [HttpPost]
        public ActionResult Modifier(ComposantModel composant)
        {
            ComposantBL.ModifierComposant(composant);
            return Redirect("Details", "Composant", new { id = composant.Id });
        }

        public ActionResult GetDependances(ComposantModel composant, int? environnementId)
        {
            return PartialView("_DetailsDependances", composant.FiltrerDependances(environnementId ?? Constantes.PRODUCTION));
        }
    }
}   