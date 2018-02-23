using STM.GDA.DataAccess;
using STM.GDA.Web.Extensions;
using STM.GDA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.BL
{
    public static class DeploiementBL
    {
        public static List<DeploiementListeModel> GetList(int take = int.MaxValue -1, int offset = 0, string filtre = null)
        {
            using (GDA_Context context = new GDA_Context())
            {
                DateTime now = DateTime.Now;
                var query = context.GetSortableDeploiements(now);

                if (!String.IsNullOrEmpty(filtre))
                {
                    query = query.Where(
                        d => d.ComposantNom.ToLower().Contains(filtre) ||
                             d.ComposantAbreviation.ToLower().Contains(filtre) ||
                             d.EnvironnementNom.ToLower().Contains(filtre));
                }
                
                return query
                    .OrderBy(d => d.EstPasse)
                    .ThenBy(d => d.EcartMinutes)
                    .Skip(offset)
                    .Take(take + 1)
                    .Select(d => d.ToDeploiementListeModel())
                    .ToList();
            }
        }

        public static DeploiementModel GetDeploiement(int id)
        {
            using (GDA_Context context = new GDA_Context())
            {
                return context.Deploiements.FirstOrDefault(x => x.Id == id)?.ToDeploiementModel();
            }
        }

        public static void CreerDeploiement(DeploiementModel nouveauDeploiement)
        {
            using (GDA_Context context = new GDA_Context())
            {
                var deploiement = new Deploiement
                {
                    ComposantId = nouveauDeploiement.Composant.Id,
                    PremierDeploiement = nouveauDeploiement.PremierDeploiement,
                    Date = nouveauDeploiement.DateDeploiement,
                    BrancheTag = nouveauDeploiement.BrancheTag,
                    URLDestination = nouveauDeploiement.UrlDestination,
                    PortailGroupe = nouveauDeploiement.PortailGroupe,
                    PortailDescription = nouveauDeploiement.PortailDescription,
                    Details = nouveauDeploiement.Details,
                    EnvironnementId = nouveauDeploiement.Environnement.Id,
                    DerniereMAJ = DateTime.Now,
                    Web = nouveauDeploiement.Web,
                    BD = nouveauDeploiement.BD,
                    Rapport = nouveauDeploiement.Rapport,
                    Interface = nouveauDeploiement.Interface,
                    Job = nouveauDeploiement.Job               
                };

                context.Deploiements.InsertOnSubmit(deploiement);

                context.SubmitChanges();

                nouveauDeploiement.Id = deploiement.Id; //Set the newly inserted id
            }
        }


        public static void ModifierDeploiement(DeploiementModel deploiementModif)
        {
            using (GDA_Context context = new GDA_Context())
            {
                var deploiement = context.Deploiements.FirstOrDefault(x => x.Id == deploiementModif.Id);
                deploiement.ComposantId = deploiementModif.Composant.Id;
                deploiement.PremierDeploiement = deploiementModif.PremierDeploiement;
                deploiement.Date = deploiementModif.DateDeploiement;
                deploiement.BrancheTag = deploiementModif.BrancheTag;
                deploiement.URLDestination = deploiementModif.UrlDestination;
                deploiement.PortailGroupe = deploiementModif.PortailGroupe;
                deploiement.PortailDescription = deploiementModif.PortailDescription;
                deploiement.Details = deploiementModif.Details;
                deploiement.EnvironnementId = deploiementModif.Environnement.Id;
                deploiement.DerniereMAJ = DateTime.Now;
                deploiement.Web = deploiementModif.Web;
                deploiement.BD = deploiementModif.BD;
                deploiement.Rapport = deploiementModif.Rapport;
                deploiement.Interface = deploiementModif.Interface;
                deploiement.Job = deploiementModif.Job;

                context.SubmitChanges();

            }
        }

        public static void SupprimerDeploiement(int id)
        {
            using (GDA_Context context = new GDA_Context())
            {
                var deploiement = context.Deploiements.FirstOrDefault(x => x.Id == id);

                context.Deploiements.DeleteOnSubmit(deploiement);

                context.SubmitChanges();
            }
        }

    }
}