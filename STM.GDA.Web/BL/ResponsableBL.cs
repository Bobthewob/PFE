using STM.GDA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.BL
{
    public static class ResponsableBL
    {
        public static List<Responsable> GetAllResponsables()
        {
            using (GDA_Context context = new GDA_Context())
            {
                return context.Responsables.ToList();
            }
        }

        public static void CreerResponsables(List<Responsable> responsables)
        {
            using (GDA_Context context = new GDA_Context())
            {
                context.Responsables.InsertAllOnSubmit(responsables);

                context.SubmitChanges();
            }
        }
    }
}