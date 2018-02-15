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
}
}