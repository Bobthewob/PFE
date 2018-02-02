using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

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
        public string ResonsablesText => string.Join(", ", Responsables);

        public List<EtiquetteModel> Clients { get; set; } = new List<EtiquetteModel>();

        [DisplayName("Clients")]
        public string ClientsText =>  string.Join(", ", Clients);

        public string NomBD { get; set; }

        [DisplayName("Source control path")]
        public string SourceControlPath { get; set; }

        public string BC { get; set; }

        public string BW { get; set; }

        public DateTime DerniereMAJ { get; set; }

        public List<EtiquetteModel> Technologies { get; set; } = new List<EtiquetteModel>();

        public string TechnologiesText => string.Join(", ", Technologies);

        public List<EtiquetteModel> Environnements { get; set; } = new List<EtiquetteModel>();

        public string EnvironnementsText => string.Join(", ", Environnements);

        public List<EtiquetteModel> Dependances { get; set; } = new List<EtiquetteModel>();

        public string DependancesText => string.Join(", ", Dependances);
    }
}