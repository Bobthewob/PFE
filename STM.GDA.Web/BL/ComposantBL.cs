using STM.GDA.DataAccess;
using STM.GDA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.BL
{
   public static class ComposantBL
   {
      public static List<ComposantListeModel> GetList()
      {
         using (GDA_Context context = new GDA_Context())
         {
            return context.Composants.Select(x => new ComposantListeModel
            {
               Id = x.Id,
               Nom = x.Nom,
               Abrevriation = x.Abreviation,
               Description = x.Description,
               Version = x.Version,
               Technologies = x.ComposantTechnologies.Select(comp => new TechnologieModel {
                  Id = comp.Technologie.Id,
                  Nom = comp.Technologie.Nom
               }).ToList(),
               Dependances = x.ComposantDependances.Select(comp => new DependanceModel {
                  Id = comp.Dependance.Id,
                  Nom = comp.Dependance.Nom
               }).ToList()
            }).ToList();
         }
      }
   }
}