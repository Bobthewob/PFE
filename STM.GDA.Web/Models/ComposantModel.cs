using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STM.GDA.Web.Models
{
    public class ComposantModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Un nom est requis")]
        [StringLength(100)]
        public string Nom { get; set; }

        [StringLength(25)]
        public string Abreviation { get; set; }

        public string Description { get; set; }

        [StringLength(25)]
        public string Version { get; set; }

        public EtiquetteModel Type { get; set; }

        public List<EtiquetteModel> Responsables { get; set; } = new List<EtiquetteModel>();

        [DisplayName("Responsables")]
        public string ResonsablesText => string.Join(", ", Responsables.Select(x => x.Nom));

        public List<EtiquetteModel> Clients { get; set; } = new List<EtiquetteModel>();

        [DisplayName("Clients")]
        public string ClientsText => string.Join(", ", Clients.Select(x => x.Nom));

        public string NomBD { get; set; }

        [DisplayName("Source control path")]
        [StringLength(25)]
        public string SourceControlPath { get; set; }

        public string BC { get; set; }

        public string BW { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
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

        public DependanceModelListe Dependances { get; set; } = new DependanceModelListe();

        private List<DependanceModelListe> _DependancesByEnvironnement { get; set; }

        public List<DependanceModelListe> DependancesByEnvironnement
        {
            get
            {
                if (_DependancesByEnvironnement == null)
                { 
                    _DependancesByEnvironnement = new List<DependanceModelListe>();

                    foreach (var environnement in EnvironnementsItems)
                    {
                        var environnementId = Int32.Parse(environnement.Value);

                        _DependancesByEnvironnement.Add(new DependanceModelListe
                        {
                            Web = Dependances.Web.Where(x => x.EnvironnementId == environnementId).ToList(),
                            BDs = Dependances.BDs.Where(x => x.EnvironnementId == environnementId).ToList(),
                            Rapports = Dependances.Rapports.Where(x => x.EnvironnementId == environnementId).ToList(),
                            Interfaces = Dependances.Interfaces.Where(x => x.EnvironnementId == environnementId).ToList(),
                            Jobs = Dependances.Jobs.Where(x => x.EnvironnementId == environnementId).ToList(),
                            Externes = Dependances.Externes.Where(x => x.EnvironnementId == environnementId).ToList()
                        });
                    }                    
                }
                return _DependancesByEnvironnement;                
            }            
        }
    }
}