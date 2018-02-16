using STM.GDA.DataAccess;
using System.Collections.Generic;

namespace STM.GDA.Web.Models
{
    public class ComposantListeModel : ComposantBase
    {
        public string Description { get; set; }

        public List<EtiquetteModel> Dependances { get; set; } = new List<EtiquetteModel>();

        public List<EtiquetteModel> Technologies { get; set; } = new List<EtiquetteModel>();

        public bool DernierComposantAffiche { get; set; } = false;

    }
}