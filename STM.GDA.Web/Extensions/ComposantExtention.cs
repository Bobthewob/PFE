using STM.GDA.DataAccess;
using STM.GDA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.Extensions
{
    public static class ComposantExtention
    {
        public static ComposantListeModel ToComposantListeModel(this Composant composant)
        {
            return new ComposantListeModel
            {
                Id = composant.Id,
                Nom = composant.Nom,
                Abrevriation = composant.Abreviation,
                Description = composant.Description,
                Version = composant.Version,
                Technologies = composant.ComposantTechnologies.Select(comp => new TechnologieModel
                {
                    Id = comp.Technologie.Id,
                    Nom = comp.Technologie.Nom
                }).ToList(),
                Dependances = composant.ComposantDependances.Select(comp => new DependanceModel
                {
                    Id = comp.Dependance.Id,
                    Nom = comp.Dependance.Nom
                }).ToList()
            };
        }

        public static ComposantModel ToComposantModel(this Composant composant)
        {
            return new ComposantModel
            {
                Id = composant.Id,
                Nom = composant.Nom,
                Abrevriation = composant.Abreviation,
                Description = composant.Description,
                Version = composant.Version
            };
        }
    }
}