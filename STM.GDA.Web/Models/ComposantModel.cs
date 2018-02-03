using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STM.GDA.Web.Models
{
    public class ComposantModel
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Abrevriation { get; set; }

        public string Description { get; set; }

        public string Version { get; set; }

        public EtiquetteModel Type { get; set; }

        public List<EtiquetteModel> Responsables { get; set; } = new List<EtiquetteModel>();

        [DisplayName("Responsables")]
        public string ResonsablesText => string.Join(", ", Responsables.Select(x => x.Nom));

        public List<EtiquetteModel> Clients { get; set; } = new List<EtiquetteModel>();

        [DisplayName("Clients")]
        public string ClientsText =>  string.Join(", ", Clients.Select(x => x.Nom));

        public string NomBD { get; set; }

        [DisplayName("Source control path")]
        public string SourceControlPath { get; set; }

        public string BC { get; set; }

        public string BW { get; set; }

        public DateTime DerniereMAJ { get; set; }

        public List<EtiquetteModel> Technologies { get; set; } = new List<EtiquetteModel>();

        public List<EnvironnementModel> Environnements { get; set; } = new List<EnvironnementModel>();

        public List<SelectListItem> EnvironnementsItems
        {
            get
            {
                return Environnements.Select(x => new SelectListItem
                {
                    Value = x.Etiquette.Id.ToString(),
                    Text = x.Etiquette.Nom,
                    Selected = x.Ordre == 1
                }).ToList();
            }             
        }

        public DependanceModelListe Dependances { get; set; } 

        public DependanceModelListe FiltrerDependances(int environnementId)
        {
            return new DependanceModelListe
            {
                Web = Dependances.Web.Where(x => x.EnvironnementId == environnementId).ToList(),
                BDs = Dependances.BDs.Where(x => x.EnvironnementId == environnementId).ToList(),
                Rapports = Dependances.Rapports.Where(x => x.EnvironnementId == environnementId).ToList(),
                Interfaces = Dependances.Interfaces.Where(x => x.EnvironnementId == environnementId).ToList(),
                Jobs = Dependances.Jobs.Where(x => x.EnvironnementId == environnementId).ToList(),
                Externes = Dependances.Externes.Where(x => x.EnvironnementId == environnementId).ToList()
            };
        }
    }
}