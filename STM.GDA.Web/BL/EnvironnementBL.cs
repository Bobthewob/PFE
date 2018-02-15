using STM.GDA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.BL
{
    public static class EnvironnementBL
    {
        public static List<Environnement> GetDefaultEnvironnements()
        {
            using (GDA_Context context = new GDA_Context())
            {
                return context.Environnements.Where(x => x.EstDefault).OrderBy(x => x.Ordre).ToList();
            }
        }

        public static List<Environnement> GetAllEnvironnements()
        {
            using (GDA_Context context = new GDA_Context())
            {
                return context.Environnements.ToList();
            }
        }
    }
}