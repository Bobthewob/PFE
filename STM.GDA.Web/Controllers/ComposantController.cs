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
            IEnumerable<Models.ComposantListeModel> composants = ComposantBL.GetList();
      
            if (!String.IsNullOrEmpty(filtre))
            {
                filtre = filtre.ToLowerInvariant();

                composants = composants.Where(x => x.Nom.ToLowerInvariant().Contains(filtre) ||
                x.Description.ToLowerInvariant().Contains(filtre) ||
                x.Technologies.Any(t => t.Nom.ToLowerInvariant().Contains(filtre)) ||
                x.Dependances.Any(d => d.Nom.ToLowerInvariant().Contains(filtre)));
            }

            composants = composants.Skip(offset);
            offset += take;

            System.Threading.Thread.Sleep(1000); //use for testing, if not it is a pretty much instant loading

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

        public ActionResult Modifier(int id)
        {
            var composant = ComposantBL.GetComposant(id);

            ViewBag.TypesComposant = TypeBL.GetAllTypes().Select(x => x.ToSelectListItem(x.Id == composant.Type.Id));
            ViewBag.Clients = ClientBL.GetAllClients().Select(x => x.ToSelectListItem(composant.Clients.Any(c => c.Id == x.Id)));

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
        [ValidateAntiForgeryToken]
        public ActionResult Modifier(ComposantModel composant)
        {
            if (ModelState.IsValid)
            {

            }
            return RedirectToAction("Details", new {  id = composant.Id }); ;
        }

        public ActionResult GetDependances(ComposantModel composant, int? environnementId)
        {
            return PartialView("_DetailsDependances", composant.FiltrerDependances(environnementId ?? Constantes.PRODUCTION));
        }
    }
}   