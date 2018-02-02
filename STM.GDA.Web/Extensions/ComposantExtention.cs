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
                Technologies = composant.ComposantTechnologies.Select(comp => new EtiquetteModel
                {
                    Id = comp.Technologie.Id,
                    Nom = comp.Technologie.Nom
                }).ToList(),
                Dependances = composant.ComposantDependances.Select(comp => new EtiquetteModel
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
                Version = composant.Version,
                Type = new EtiquetteModel { Id = composant.ComposantType.Id, Nom = composant.ComposantType.Nom },
                Clients = composant.ComposantClients.Select(x => new EtiquetteModel {
                    Id = x.Client.Id,
                    Nom = x.Client.Nom
                }).ToList(),
                Responsables = composant.ComposantResponsables.Select(x => new EtiquetteModel
                {
                    Id = x.Responsable.Id,
                    Nom = x.Responsable.Nom
                }).ToList(),
                NomBD = composant.NomBD,
                SourceControlPath = composant.SourceControlPath,
                BC = composant.BC,
                BW = composant.BW,
                DerniereMAJ = composant.DerniereMAJ
            };
        }
    }
}