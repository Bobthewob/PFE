using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.Models
{
    public class DependanceModelListe
    {
        public List<DependanceModel> Web { get; set; } = new List<DependanceModel>();

        public List<DependanceModel> BDs { get; set; } = new List<DependanceModel>();

        public List<DependanceModel> Rapports { get; set; } = new List<DependanceModel>();

        public List<DependanceModel> Interfaces { get; set; } = new List<DependanceModel>();

        public List<DependanceModel> Jobs { get; set; } = new List<DependanceModel>();

        public List<DependanceModel> Externes { get; set; } = new List<DependanceModel>();
    }
}