using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.Models
{
    public class DeploiementListeModel
    {
        public int Id { get; set; }

        public string NomComposant { get; set; }

        public string AbrevriationComposant { get; set; }

        public string Environnement { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateDeploiement { get; set; }

        public bool DernierDeploiementAffiche { get; set; } = false;

        public string AbreviationNomComposant => AbrevriationComposant + " - " + NomComposant;
    }
}