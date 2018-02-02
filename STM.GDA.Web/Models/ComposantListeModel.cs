using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.Models
{
    public class ComposantListeModel
    {
      public int Id { get; set; }

      public string Nom { get; set; }

      public string Abrevriation { get; set; }

      public string Description { get; set; }

      public string Version { get; set; }

      public List<DependanceModel> Dependances { get; set; } = new List<DependanceModel>();

      public List<TechnologieModel> Technologies { get; set; } = new List<TechnologieModel>();

      public string TechnologiesNom => System.String.Join(", ", Technologies.Select(x => x.Nom));

      public string DependancesNom => System.String.Join(", ", Dependances.Select(x => x.Nom));
   }
}