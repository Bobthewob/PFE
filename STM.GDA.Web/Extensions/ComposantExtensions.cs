using STM.GDA.DataAccess;
using STM.GDA.Web.Configuration;
using STM.GDA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.Extensions
{
    public static class ComposantExtensions
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
                DerniereMAJ = composant.DerniereMAJ,
                Technologies = composant.ComposantTechnologies.Select(x => new EtiquetteModel
                {
                    Id = x.Technologie.Id,
                    Nom = x.Technologie.Nom
                }).ToList(),
                Environnements = composant.ComposantEnvironnements.OrderBy(x => x.Ordre).Select(x => new EnvironnementModel
                {
                    Etiquette = new EtiquetteModel { Id = x.Environnement.Id, Nom = x.Environnement.Nom },
                    Ordre = x.Environnement.Ordre
                }).ToList(),
                Dependances = new DependanceModelListe
                {
                    Web = GetDependaceComposant(composant, Constantes.WEB),
                    BDs = GetDependaceComposant(composant, Constantes.BD),
                    Interfaces = GetDependaceComposant(composant, Constantes.INTERFACE),
                    Rapports = GetDependaceComposant(composant, Constantes.RAPPORT),
                    Externes = GetDependaceComposant(composant, Constantes.EXTERNE),
                    Jobs = GetDependaceComposant(composant, Constantes.JOB)
                }
            };
        }

        private static List<DependanceModel> GetDependaceComposant(Composant composant, int typeDependance)
        {
            return composant.ComposantDependances.Where(x => x.Dependance.DependanceType.Id == typeDependance).Select(x => new DependanceModel
            {
                Etiquette = new EtiquetteModel { Id = x.Dependance.Id, Nom = x.Dependance.Nom },
                Type = new EtiquetteModel { Id = x.Dependance.DependanceType.Id, Nom = x.Dependance.DependanceType.Nom },
                EnvironnementId = x.EnvironnementId
            }).ToList();
        }
    }
}