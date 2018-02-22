using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace STM.GDA.Web.Models
{
    public class DeploiementModel
    {
        public int Id { get; set; }

        [DisplayName("Nom du composant déployé")]
        public ComposantBase Composant { get; set; } = new ComposantBase();

        [Required(ErrorMessage = "Un environnement est requis")]
        public EtiquetteModel Environnement { get; set; }

        [Required(ErrorMessage = "Une date est requise")]
        [DisplayName("Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy H:mm}", ApplyFormatInEditMode = false)]
        public DateTime DateDeploiement { get; set; }

        [DisplayName("Branche/Tag")]
        public string BrancheTag { get; set; }

        [DisplayName("URL/Destination")]
        [StringLength(100)]
        public string UrlDestination { get; set; }

        [DisplayName("Portail groupe")]
        [StringLength(100)]
        public string PortailGroupe { get; set; }

        [DisplayName("Portail description")]
        public string PortailDescription { get; set; }

        [DisplayName("Détails supplémentaires")]
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DernierMAJ { get; set; }

        [DisplayName("Premier déploiement")]
        public bool PremierDeploiement { get; set; }

        [DisplayName("Web")]
        public bool Web { get; set; } = true;

        [DisplayName("BD")]
        public bool BD { get; set; } = true;

        [DisplayName("Rapport")]
        public bool Rapport { get; set; } = true;

        [DisplayName("Interface")]
        public bool Interface { get; set; } = true;

        [DisplayName("Job")]
        public bool Job { get; set; } = true;

        public string getStandardAppDate()
        {
            var pattern = "";

            switch (this.DateDeploiement.ToString()) {
                case var strDate when new Regex(@"[0-9]{4}-[0-9]{2}-[0-9]{2} [0-9]{1,2}:[0-9]{2}:[0-9]{2} (AM|PM)").IsMatch(strDate):
                    pattern = "yyyy-MM-dd h:mm:ss tt";
                    break;
                case var strDate when new Regex(@"[0-9]{1,2}\/[0-9]{2}\/[0-9]{4} [0-9]{1,2}:[0-9]{2}:[0-9]{2} (AM|PM)").IsMatch(strDate):
                    pattern = "M/dd/yyyy hh:mm:ss tt";
                    break;
            }
            

            return DateTime.ParseExact(this.DateDeploiement.ToString(), pattern,
                System.Globalization.CultureInfo.InvariantCulture
                ).ToString("yyyy-MM-dd H:mm");
        } 
    }
}