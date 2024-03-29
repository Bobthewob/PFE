﻿using STM.GDA.Web.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace STM.GDA.Web.Models
{
	public class ComposantModel : ComposantBase
    {        
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public EtiquetteModel Type { get; set; }

        [DisplayName("Responsables")]
        public List<EtiquetteModel> Responsables { get; set; } = new List<EtiquetteModel>();

        [DisplayName("Clients")]
        public List<EtiquetteModel> Clients { get; set; } = new List<EtiquetteModel>();

        public string NomBD { get; set; }

        [DisplayName("Source control path")]
        [StringLength(25)]
        public string SourceControlPath { get; set; }

        public string BC { get; set; }

        public string BW { get; set; }

		public int EnvironnementSelectionne { get; set; } = 0;

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
					Selected = (EnvironnementSelectionne == 0) ? x.Ordre == 1 : EnvironnementSelectionne == x.Etiquette.Id
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

        private List<DependanceModel> _RawDependances { get; set; }

        //Returns all the dependencies in only one list
        public List<DependanceModel> RawDependances
        {
            get
            {
                if (_RawDependances == null)
                {
                    _RawDependances = new List<DependanceModel>();

                    _RawDependances.AddRange(Dependances.Web.Select(x => { x.Type.Id = Constantes.DEPENDANCE_WEB; return x; }));
                    _RawDependances.AddRange(Dependances.BDs.Select(x => { x.Type.Id = Constantes.DEPENDANCE_BD; return x; }));
                    _RawDependances.AddRange(Dependances.Rapports.Select(x => { x.Type.Id = Constantes.DEPENDANCE_RAPPORT; return x; }));
                    _RawDependances.AddRange(Dependances.Interfaces.Select(x => { x.Type.Id = Constantes.DEPENDANCE_INTERFACE; return x; }));
                    _RawDependances.AddRange(Dependances.Jobs.Select(x => { x.Type.Id = Constantes.DEPENDANCE_JOB; return x; }));
                    _RawDependances.AddRange(Dependances.Externes.Select(x => { x.Type.Id = Constantes.DEPENDANCE_EXTERNE; return x; }));
                }      

                return _RawDependances;
            }
        }
    }
}