using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.Models
{
    public class DependanceModelListe
    {
        public List<DependanceModel> Web { get; set; } = new List<DependanceModel>();

        public string WebText => string.Join(", ", Web.Select(x => x.Etiquette.Nom));

        public List<DependanceModel> BDs { get; set; } = new List<DependanceModel>();

        public string BDsText => string.Join(", ", BDs.Select(x => x.Etiquette.Nom));

        public List<DependanceModel> Rapports { get; set; } = new List<DependanceModel>();

        public string RapportsText => string.Join(", ", Rapports.Select(x => x.Etiquette.Nom));

        public List<DependanceModel> Interfaces { get; set; } = new List<DependanceModel>();

        public string InterfacesText => string.Join(", ", Interfaces.Select(x => x.Etiquette.Nom));

        public List<DependanceModel> Jobs { get; set; } = new List<DependanceModel>();

        public string JobsText => string.Join(", ", Jobs.Select(x => x.Etiquette.Nom));

        public List<DependanceModel> Externes { get; set; } = new List<DependanceModel>();

        public string ExternesText => string.Join(", ", Externes.Select(x => x.Etiquette.Nom)); 
    }
}