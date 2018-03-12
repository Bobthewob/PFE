using STM.GDA.Web.BL;
using STM.GDA.Web.Configuration;
using STM.GDA.Web.CustomFilters;
using STM.GDA.Web.Extensions;
using STM.GDA.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace STM.GDA.Web.Controllers
{
    public class DeploiementController : BaseController
    {
		private IComposantBL _ComposantBL;

		public IComposantBL ComposantBL
		{
			get
			{
				if (_ComposantBL == null)
					return new ComposantBL();

				return _ComposantBL;
			}
			set { _ComposantBL = value; }
		}

		// GET: Deploiement
		public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDeploiements(string filtre, int take, int offset = 0)
        {
            IEnumerable<DeploiementListeModel> deploiements = DeploiementBL.GetList(take, offset, filtre);

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

        public ActionResult Details(int id)
        {
            var deploiement = DeploiementBL.GetDeploiement(id);

            if (deploiement == null)
            {
                return View("Error");
            }
            else
            {
                return View("Details", deploiement);
            }
        }

        public ActionResult Creer()
        {
            var deploiement = new DeploiementModel();
            ViewBag.ListeComposants = ComposantBL.GetListComposantBase().Select(x => x.ToSelectListItem());
            ViewBag.ListeEnvironnements = EnvironnementBL.GetDefaultEnvironnements().Select(x => x.ToSelectListItem()); ;

            return View("Creer", deploiement);
        }

        [HttpPost]
        public ActionResult Creer(DeploiementModel deploiement)
        {
            DeploiementBL.CreerDeploiement(deploiement);
            return Redirect("Details", "Deploiement", new { id = deploiement.Id });
        }

         public ActionResult Supprimer(int id)
         {
             DeploiementBL.SupprimerDeploiement(id);
             return Redirect("Index", "Deploiement", null);
         }

        public ActionResult Modifier(int id)
        {
            var deploiement = DeploiementBL.GetDeploiement(id);

            ViewBag.DateDeploiement = deploiement.getStandardAppDate();
            ViewBag.ListeComposants = new ComposantBL().GetList().Select(x => x.ToSelectListItem());
            ViewBag.ListeEnvrionnements = EnvironnementBL.GetDefaultEnvironnements().Select(x => x.ToSelectListItem()); ;

            if (deploiement == null)
            {
                return View("Error");
            }
            else
            {
                return View("Modifier", deploiement);
            }
        }

        [HttpPost]
        public ActionResult Modifier(DeploiementModel deploiement)
        {
            DeploiementBL.ModifierDeploiement(deploiement);
            return Redirect("Details", "Deploiement", new { id = deploiement.Id });
        }

        public JsonResult GenererTexteDescriptif(DeploiementModel deploiement, DateTime date)
        {
            deploiement.DateDeploiement = date;
			var nomFichier = "Deploiement_" + deploiement.Composant.Nom.Replace(" ", string.Empty);

			string fullPath = Path.Combine(Server.MapPath("~"), nomFichier);

			using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(DeploiementBL.GetTexteDescriptif(deploiement))))
			{
				FileStream fichier = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
				stream.WriteTo(fichier);
				fichier.Close();
			}

			return Json(new { nomFichier = nomFichier });
		}

        public JsonResult AjouterCalendrier(DeploiementModel deploiement, DateTime date)
        {
            DeploiementBL.AjouterCalendrier(deploiement, date);
            return Json(new { status = "Created"});
        }

        [DeleteFile]
		public ActionResult TelechargerTexteDescriptif(string fichier)
		{
			string fullPath = Path.Combine(Server.MapPath("~"), fichier);

			return File(fullPath, "text/plain", fichier+".txt");
		}
	}
}