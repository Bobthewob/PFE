using STM.GDA.DataAccess;
using STM.GDA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.BL
{
    public static class TechnologieBL
    {
        public static List<Technologie> GetAllTechnologies()
        {
            using (GDA_Context context = new GDA_Context())
            {
                return context.Technologies.ToList();
            }
        }

        public static void CreerTechnologies(List<Technologie> technologies)
        {
            using (GDA_Context context = new GDA_Context())
            {
                context.Technologies.InsertAllOnSubmit(technologies);

                context.SubmitChanges();
            }
        }
    }
}