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

        public ComposantBase Composant { get; set; } = new ComposantBase();

        public string Environnement { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy H:mm}")]
        public DateTime DateDeploiement { get; set; }

        public bool DernierDeploiementAffiche { get; set; } = false;
    }
}