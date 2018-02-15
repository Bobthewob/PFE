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
                NomComposant = deploiement.Composant.Nom,
                AbrevriationComposant = deploiement.Composant.Abreviation,
                DateDeploiement = deploiement.Date,
                Environnement = deploiement.Environnement.Nom   
            };
        }

        public static DeploiementModel ToDeploiementModel(this Deploiement deploiement)
        {
            return new DeploiementModel
            {
                Id = deploiement.Id,
                NomComposant = new EtiquetteModel { Id = deploiement.Composant.Id, Nom = deploiement.Composant.Nom },
                Environnement = new EtiquetteModel { Id = deploiement.Environnement.Id, Nom = deploiement.Environnement.Nom },
                AbreviationComposant = deploiement.Composant.Abreviation,
                PremierDeploiement = deploiement.PremierDeploiement,
                DateDeploiement = deploiement.Date,
                BranchTag = deploiement.BrancheTag,
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