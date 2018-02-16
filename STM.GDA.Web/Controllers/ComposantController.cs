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
            IEnumerable<ComposantListeModel> composants = ComposantBL.GetList(take, offset, filtre);

            //System.Threading.Thread.Sleep(1000); //use to test loading spinner on new filter

            if (!composants.Any())
            {
                return Json(new { status = "All_Loaded", message = "no element left to load" });
            }

            if (composants.Count() <= take)
            {
                composants.Last().DernierComposantAffiche = true;
            }

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
            ViewBag.ListeTechnologies = TechnologieBL.GetAllTechnologies().Select(x => x.ToSelectListItem());

            //Creating the default environnements
            var composant = new ComposantModel();
            composant.Environnements = EnvironnementBL.GetDefaultEnvironnements().Select(x => x.ToEnvironnementModel()).ToList();

            return View("Creer", composant);
        }

        [HttpPost]
        public ActionResult Creer(ComposantModel composant)
        {
            ComposantBL.CreerComposant(composant);
            return Redirect("Details", "Composant", new { id = composant.Id });
        }

        public ActionResult Supprimer(int id)
        {
            ComposantBL.SupprimerComposant(id);
            return Redirect("Index", "Composant", null);
        }

        public ActionResult Modifier(int id)
        {
            var composant = ComposantBL.GetComposant(id);

            ViewBag.ListeTypes = TypeBL.GetAllTypes().Select(x => x.ToSelectListItem());
            ViewBag.ListeClients = ClientBL.GetAllClients().Select(x => x.ToSelectListItem());
            ViewBag.ListeResponsables = ResponsableBL.GetAllResponsables().Select(x => x.ToSelectListItem());
            ViewBag.ListeTechnologies = TechnologieBL.GetAllTechnologies().Select(x => x.ToSelectListItem());

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

        public ActionResult GetDetailsDependances(ComposantModel composant)
        {
            return PartialView("_DetailsDependances", composant.DependancesByEnvironnement);
        }

        public ActionResult GetModifierDependances(ComposantModel composant)
        {
            ViewBag.ListeDependancesServeurs = DependanceBL.GetDependances(Constantes.DEPENDANCE_SERVEURS).Select(x => x.ToSelectListItem());
            ViewBag.ListeDependancesAutres = DependanceBL.GetDependances(Constantes.DEPENDANCE_AUTRES).Select(x => x.ToSelectListItem());

            return PartialView("_ModifierDependances", composant);
        }
    }
}   