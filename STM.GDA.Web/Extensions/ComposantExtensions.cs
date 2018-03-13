using STM.GDA.DataAccess;
using STM.GDA.Web.Configuration;
using STM.GDA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using System.Web;
using System.Web.Mvc;
using System.Text;

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
                Abreviation = composant.Abreviation,
                Description = composant.Description,
                Version = composant.Version,
                Technologies = composant.ComposantTechnologies.Select(comp => new EtiquetteModel
                {
                    Id = comp.Technologie.Id,
                    Nom = comp.Technologie.Nom
                }).ToList(),
                Dependances = composant.ComposantDependances.DistinctBy(x => x.DependanceId).Select(comp => new EtiquetteModel
                {
                    Id = comp.Dependance.Id,
                    Nom = comp.Dependance.Nom
                }).ToList()
            };
        }

		public static CSVComposantListeModelCourt ToCSVComposantListeModelCourt(this Composant composant)
		{
			return new CSVComposantListeModelCourt
			{
				Nom = composant.Nom,
				Abreviation = composant.Abreviation,
				Version = composant.Version,
				Description = composant.Description,
				DerniereMAJ = composant.DerniereMAJ.ToString()
			};
		}

		public static CSVComposantListeModelLong ToCSVComposantListeModelLong(this Composant composant)
		{
			return new CSVComposantListeModelLong
			{
				Nom = composant.Nom,
				Abreviation = composant.Abreviation,
				Version = composant.Version,
				Description = composant.Description,
				NomBD = composant.NomBD,
				SourceControlPath = composant.SourceControlPath,
				DerniereMAJ = composant.DerniereMAJ.ToString(),
				Type = composant.ComposantType.Nom,
				BC = composant.BC,
				BW = composant.BW,
				Clients = string.Join(", ", composant.ComposantClients.Select(x => x.Client.Nom).ToArray()),
				EnvironnementsProductionWeb = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_WEB, Constantes.ENVIRONNEMENT_PRODUCTION),
				EnvironnementsProductionBDs = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_BD, Constantes.ENVIRONNEMENT_PRODUCTION),
				EnvironnementsProductionRapports = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_RAPPORT, Constantes.ENVIRONNEMENT_PRODUCTION),
				EnvironnementsProductionInterfaces = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_INTERFACE, Constantes.ENVIRONNEMENT_PRODUCTION),
				EnvironnementsProductionJobs = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_JOB, Constantes.ENVIRONNEMENT_PRODUCTION),
				EnvironnementsProductionExternes = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_EXTERNE, Constantes.ENVIRONNEMENT_PRODUCTION),
				EnvironnementsDeveloppementWeb = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_WEB, Constantes.ENVIRONNEMENT_DEVELOPPEMENT),
				EnvironnementsDeveloppementBDs = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_BD, Constantes.ENVIRONNEMENT_DEVELOPPEMENT),
				EnvironnementsDeveloppementRapports = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_RAPPORT, Constantes.ENVIRONNEMENT_DEVELOPPEMENT),
				EnvironnementsDeveloppementInterfaces = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_INTERFACE, Constantes.ENVIRONNEMENT_DEVELOPPEMENT),
				EnvironnementsDeveloppementJobs = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_JOB, Constantes.ENVIRONNEMENT_DEVELOPPEMENT),
				EnvironnementsDeveloppementExternes = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_EXTERNE, Constantes.ENVIRONNEMENT_DEVELOPPEMENT),
				EnvironnementsQAWeb = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_WEB, Constantes.ENVIRONNEMENT_QA),
				EnvironnementsQABDs = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_BD, Constantes.ENVIRONNEMENT_QA),
				EnvironnementsQARapports = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_RAPPORT, Constantes.ENVIRONNEMENT_QA),
				EnvironnementsQAInterfaces = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_INTERFACE, Constantes.ENVIRONNEMENT_QA),
				EnvironnementsQAJobs = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_JOB, Constantes.ENVIRONNEMENT_QA),
				EnvironnementsQAExternes = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_EXTERNE, Constantes.ENVIRONNEMENT_QA),
				EnvironnementsPreProductiontWeb = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_WEB, Constantes.ENVIRONNEMENT_PREPRODUCTION),
				EnvironnementsPreProductiontBDs = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_BD, Constantes.ENVIRONNEMENT_PREPRODUCTION),
				EnvironnementsPreProductiontRapports = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_RAPPORT, Constantes.ENVIRONNEMENT_PREPRODUCTION),
				EnvironnementsPreProductiontInterfaces = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_INTERFACE, Constantes.ENVIRONNEMENT_PREPRODUCTION),
				EnvironnementsPreProductiontJobs = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_JOB, Constantes.ENVIRONNEMENT_PREPRODUCTION),
				EnvironnementsPreProductiontExternes = GetDependanceEnvironnementComposant(composant, Constantes.DEPENDANCE_EXTERNE, Constantes.ENVIRONNEMENT_PREPRODUCTION),
				Responsables = string.Join(", ", composant.ComposantResponsables.Select(x => x.Responsable.Nom).ToArray()),
				Technologies = string.Join(", ", composant.ComposantTechnologies.Select(x => x.Technologie.Nom).ToArray()),
			};
		}
        public static ComposantModel ToComposantModel(this Composant composant)
        {
            return new ComposantModel
            {
                Id = composant.Id,
                Nom = composant.Nom,
                Abreviation = composant.Abreviation,
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
                    Web = GetDependanceComposant(composant, Constantes.DEPENDANCE_WEB),
                    BDs = GetDependanceComposant(composant, Constantes.DEPENDANCE_BD),
                    Interfaces = GetDependanceComposant(composant, Constantes.DEPENDANCE_INTERFACE),
                    Rapports = GetDependanceComposant(composant, Constantes.DEPENDANCE_RAPPORT),
                    Externes = GetDependanceComposant(composant, Constantes.DEPENDANCE_EXTERNE),
                    Jobs = GetDependanceComposant(composant, Constantes.DEPENDANCE_JOB)
                }
            };
        }

        public static ComposantBase ToComposantBaseModel(this Composant composant)
        {
            return new ComposantBase
            {
                Id = composant.Id,
                Nom = composant.Nom,
                Abreviation = composant.Abreviation,
                Version = composant.Version
            };
        }

        public static SelectListItem ToSelectListItem(this ComposantBase composant)
        {
            return new SelectListItem { Value = composant.Id.ToString(), Text = composant.NomAbreviation };
        }

        private static List<DependanceModel> GetDependanceComposant(Composant composant, int typeDependance)
        {
            return composant.ComposantDependances.Where(x => x.DependanceTypeId == typeDependance).Select(x => new DependanceModel
            {
                Etiquette = new EtiquetteModel { Id = x.Dependance.Id, Nom = x.Dependance.Nom },
                Type = new EtiquetteModel { Id = typeDependance, Nom = x.DependanceType.Nom },
                EnvironnementId = x.EnvironnementId
            }).ToList();
        }

		private static string GetDependanceEnvironnementComposant(Composant composant, int typeDependance, int environnementID)
		{
			return string.Join(", ", composant.ComposantDependances
				.Where(x => x.DependanceTypeId == typeDependance && x.EnvironnementId == environnementID)
				.Select(x => x.Dependance.Nom).ToArray());
		}
	}
}