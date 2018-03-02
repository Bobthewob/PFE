using STM.GDA.DataAccess;
using STM.GDA.Web.Extensions;
using STM.GDA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Office.Interop.Outlook;

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

        public static string GetTexteDescriptif(DeploiementModel deploiement)
        {
            var composantInfo = ComposantBL.GetComposant(deploiement.Composant.Id);
            var dependancesWeb = composantInfo.Dependances.Web.Where(x => x.EnvironnementId == deploiement.Environnement.Id).Select(x => x.Etiquette.Nom);
            var dependancesBDs = composantInfo.Dependances.BDs.Where(x => x.EnvironnementId == deploiement.Environnement.Id).Select(x => x.Etiquette.Nom);
            var dependancesRapports = composantInfo.Dependances.Rapports.Where(x => x.EnvironnementId == deploiement.Environnement.Id).Select(x => x.Etiquette.Nom);
            var dependancesInterfaces = composantInfo.Dependances.Interfaces.Where(x => x.EnvironnementId == deploiement.Environnement.Id).Select(x => x.Etiquette.Nom);
            var dependancesJobs = composantInfo.Dependances.Jobs.Where(x => x.EnvironnementId == deploiement.Environnement.Id).Select(x => x.Etiquette.Nom);

            string text = "Nom de l'application ou du service : " + composantInfo.Nom + "\r\n";
            text += "Environnement : " + deploiement.Environnement.Nom + "\r\n";
            text += "Date du déploiement : " + deploiement.DateDeploiement.ToString() + "\r\n";
            text += "Premier déploiement : " + (deploiement.PremierDeploiement ? "Oui" : "Non") + "\r\n";
            text += "Source control path : " + composantInfo.SourceControlPath+ "\r\n";
            text += "Branche/Tag : " + deploiement.BrancheTag + "\r\n";
            text += "Url de destination : " + deploiement.UrlDestination + "\r\n";
            text += "Portail groupe : " + deploiement.PortailGroupe + "\r\n";
            text += "Portail description : " + deploiement.PortailDescription + "\r\n";
            text += "Détails supplémentaires : " + deploiement.Details + "\r\n\r\n";

            text += "Déploiements nécessaires\r\n";

            if (deploiement.Web)
            {
                text += "\r\nDéploiement web\r\n";

                if (dependancesWeb.Any())
                {
                    text += "Dépendances : " + string.Join(",", dependancesWeb) + "\r\n";
                }
                else
                {
                    text += "Il n'y a pas de dépendances web associées à cette application ou à ce service\r\n";
                }
            }

            if (deploiement.BD)
            {
                text += "\r\nDéploiement de base de données\r\n";

                if (dependancesBDs.Any())
                {
                    text += "Nom de la base de données : " + composantInfo.NomBD + "\r\n";
                    text += "Dépendances : " + string.Join(",", dependancesBDs) + "\r\n";
                }
                else
                {
                    text += "Il n'y a pas de base de données associées à cette application ou à ce service\r\n";
                }
            }

            if (deploiement.Rapport)
            {
                text += "\r\nDéploiement de rapports\r\n";

                if (dependancesRapports.Any())
                {
                    text += "Dépendances : " + string.Join(",", dependancesRapports) + "\r\n";
                }
                else
                {
                    text += "Il n'y a pas de rapports associés à cette application ou à ce service\r\n";
                }
            }

            if (deploiement.Interface)
            {
                text += "\r\nDéploiement d'interfaces\r\n";

                if (dependancesInterfaces.Any())
                {
                    text += "Dépendances : " + string.Join(",", dependancesInterfaces) + "\r\n";
                }
                else
                {
                    text += "Il n'y a pas d'interfaces associées à cette application ou à ce service\r\n";
                }
            }

            if (deploiement.Job)
            {
                text += "\r\nDéploiement de jobs\r\n";

                if (dependancesJobs.Any())
                {
                    text += "Dépendances : " + string.Join(",", dependancesJobs) + "\r\n";
                }
                else
                {
                    text += "Il n'y a pas de jobs associés à cette application ou à ce service\r\n";
                }
            }

            return text;
        }

        //https://www.codeproject.com/Tips/84321/Setting-up-an-MS-Outlook-Appointment-C
        public static void AjouterCalendrier(DeploiementModel deploiement, DateTime date)
        {
            Application outlookApp = new Application(); // creates new outlook app
            AppointmentItem oAppointment = (AppointmentItem)outlookApp.CreateItem(OlItemType.olAppointmentItem); // creates a new
            oAppointment.Subject = "Déploiement " + deploiement.Composant.Nom + ""; // set the subject
            oAppointment.Start = Convert.ToDateTime(date); // Set the start date 
            oAppointment.End = Convert.ToDateTime(date.AddHours(1) ); // End date 
            oAppointment.ReminderSet = true; // Set the reminder
            oAppointment.ReminderMinutesBeforeStart = 15; // reminder time
            oAppointment.BusyStatus = OlBusyStatus.olBusy;
            oAppointment.Save();
        }

    }
}