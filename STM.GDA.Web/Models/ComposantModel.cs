using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.Models
{
    public class ComposantModel
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Abrevriation { get; set; }

        public string Description { get; set; }

        public string Version { get; set; }
    }
}