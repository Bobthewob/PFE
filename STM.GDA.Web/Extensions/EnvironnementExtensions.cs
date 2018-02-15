using STM.GDA.DataAccess;
using STM.GDA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STM.GDA.Web.Extensions
{
    public static class EnvironnementExtensions
    {
        public static EnvironnementModel ToEnvironnementModel(this Environnement environnement)
        {
            return new EnvironnementModel {
                Etiquette = new EtiquetteModel { Id = environnement.Id, Nom = environnement.Nom },
                Ordre = environnement.Ordre
            };
        }

        public static SelectListItem ToSelectListItem(this Environnement environnement)
        {
            return new SelectListItem { Value = environnement.Id.ToString(), Text = environnement.Nom };
        }
    }
}