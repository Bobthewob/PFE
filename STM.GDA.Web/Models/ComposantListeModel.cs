using STM.GDA.DataAccess;
using System.Collections.Generic;

namespace STM.GDA.Web.Models
{
    public class ComposantListeModel
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Abreviation { get; set; }

        public string DisplayString { get; set; }

        public string Description { get; set; }

        public string Version { get; set; }

        public List<EtiquetteModel> Dependances { get; set; } = new List<EtiquetteModel>();

        public List<EtiquetteModel> Technologies { get; set; } = new List<EtiquetteModel>();

        public bool DernierComposantAffiche { get; set; } = false;

    }
}