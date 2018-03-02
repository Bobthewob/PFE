using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace STM.GDA.Web.Models
{
    public class ComposantBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Un nom est requis")]
        [StringLength(100)]
        public string Nom { get; set; }

        [StringLength(25)]
        public string Abreviation { get; set; }

        [StringLength(25)]
        public string Version { get; set; }

        public string NomAbreviation
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (!String.IsNullOrWhiteSpace(Abreviation))
                {
                    sb.Append(Abreviation);
                    sb.Append(" - ");
                }
                sb.Append(Nom);

                return sb.ToString();
            }
        }
    }
}