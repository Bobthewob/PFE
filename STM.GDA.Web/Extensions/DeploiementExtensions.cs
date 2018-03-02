using STM.GDA.DataAccess;
using STM.GDA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.Extensions
{
    public static class DeploiementExtensions 
    {
        public static DeploiementListeModel ToDeploiementListeModel(this Deploiement deploiement)
        {
            return new DeploiementListeModel
            {
                Id = deploiement.Id,
                Composant = new ComposantBase
                {
                    Nom = deploiement.Composant.Nom,
                    Abreviation = deploiement.Composant.Abreviation
                },
                DateDeploiement = deploiement.Date,
                Environnement = deploiement.Environnement.Nom   
            };
        }

        public static DeploiementListeModel ToDeploiementListeModel(this GetSortableDeploiementsResult deploiement)
        {
            return new DeploiementListeModel
            {
                Id = deploiement.Id ?? 0,
                Composant = new ComposantBase
                {
                    Nom = deploiement.ComposantNom,
                    Abreviation = deploiement.ComposantAbreviation
                },
                DateDeploiement = deploiement.Date ?? DateTime.MinValue,
                Environnement = deploiement.EnvironnementNom
            };
        }

        public static DeploiementModel ToDeploiementModel(this Deploiement deploiement)
        {
            return new DeploiementModel
            {
                Id = deploiement.Id,
                Composant = new ComposantBase
                {
                    Id = deploiement.Composant.Id,
                    Nom = deploiement.Composant.Nom,
                    Abreviation = deploiement.Composant.Abreviation
                },
                Environnement = new EtiquetteModel { Id = deploiement.Environnement.Id, Nom = deploiement.Environnement.Nom },
                PremierDeploiement = deploiement.PremierDeploiement,
                DateDeploiement = deploiement.Date,
                BrancheTag = deploiement.BrancheTag,
                UrlDestination = deploiement.URLDestination,
                PortailGroupe = deploiement.PortailGroupe,
                PortailDescription = deploiement.PortailDescription,
                Details = deploiement.Details,
                DernierMAJ = deploiement.DerniereMAJ,
                Web = deploiement.Web,
                BD = deploiement.BD,
                Rapport = deploiement.Rapport,
                Interface = deploiement.Interface,
                Job = deploiement.Job
            };
        }
    }
}