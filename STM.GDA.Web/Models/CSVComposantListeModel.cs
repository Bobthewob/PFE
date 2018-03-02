using STM.GDA.DataAccess;
using System.Collections.Generic;

namespace STM.GDA.Web.Models
{
    public class CSVComposantListeModel : ComposantBase
    {
        public string Description;

        public string NomBD { get; set; }

        public string SourceControlPath { get; set; }

        public string DerniereMAJ { get; set; }

        public string Type { get; set; }

        public string Clients { get; set; }

        public string Dependances { get; set; }

        public string EnvironnementsProductionWeb { get; set; }

        public string EnvironnementsProductionBDs { get; set; }

        public string EnvironnementsProductionRapports { get; set; }

        public string EnvironnementsProductionInterfaces { get; set; }

        public string EnvironnementsProductionJobs { get; set; }

        public string EnvironnementsProductionExtermes { get; set; }

        public string EnvironnementsDeveloppementWeb { get; set; }

        public string EnvironnementsDeveloppementBDs { get; set; }

        public string EnvironnementsDeveloppementRapports { get; set; }

        public string EnvironnementsDeveloppementInterfaces { get; set; }

        public string EnvironnementsDeveloppementJobs { get; set; }

        public string EnvironnementsDeveloppementExtermes { get; set; }

        public string EnvironnementsQAWeb { get; set; }

        public string EnvironnementsQABDs { get; set; }

        public string EnvironnementsQARapports { get; set; }

        public string EnvironnementsQAInterfaces { get; set; }

        public string EnvironnementsQAJobs { get; set; }

        public string EnvironnementsQAExtermes { get; set; }

        public string EnvironnementsPreProductiontWeb { get; set; }

        public string EnvironnementsPreProductiontBDs { get; set; }

        public string EnvironnementsPreProductiontRapports { get; set; }

        public string EnvironnementsPreProductiontInterfaces { get; set; }

        public string EnvironnementsPreProductiontJobs { get; set; }

        public string EnvironnementsPreProductiontExtermes { get; set; }

        public string Responsables { get; set; }

        public string Technologies { get; set; }
    }
}