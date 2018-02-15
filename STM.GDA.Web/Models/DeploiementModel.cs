using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.Models
{
    public class DeploiementModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Un composant est requis")]
        [StringLength(100)]
        [DisplayName("Nom du composant déployé")]
        public EtiquetteModel NomComposant { get; set; }

        [Required(ErrorMessage = "Un environnement est requis")]
        public EtiquetteModel Environnement { get; set; }

        [Required(ErrorMessage = "Une date est requise")]
        [DisplayName("Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateDeploiement { get; set; }

        [StringLength(25)]
        public string AbreviationComposant { get; set; }

        [DisplayName("Branche/Tag")]
        [StringLength(25)]
        public string BranchTag { get; set; }

        [DisplayName("URL/Destination")]
        [StringLength(255)]
        public string UrlDestination { get; set; }

        [DisplayName("Portail groupe")]
        [StringLength(100)]
        public string PortailGroupe { get; set; }

        [DisplayName("Portail description")]
        public string PortailDescription { get; set; }

        [DisplayName("Détails supplémentaires")]
        public string Details { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DernierMAJ { get; set; }

        [DisplayName("Premier déploiement")]
        public bool PremierDeploiement { get; set; }

        [DisplayName("Web")]
        public bool Web { get; set; }

        [DisplayName("BD")]
        public bool BD { get; set; }

        [DisplayName("Rapport")]
        public bool Rapport { get; set; }

        [DisplayName("Interface")]
        public bool Interface { get; set; }

        [DisplayName("Job")]
        public bool Job { get; set; }

    }
}