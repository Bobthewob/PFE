using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.Models
{
    public class DependanceModel
    {
        public EtiquetteModel Etiquette { get; set; }

        public EtiquetteModel Type { get; set; } = new EtiquetteModel();

        public int EnvironnementId { get; set; }
    }
}