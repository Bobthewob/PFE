using STM.GDA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using System.Web;

namespace STM.GDA.Web.BL
{
    public static class DependanceBL
    {
        public static List<Dependance> GetDependances(int[] typesDependance)
        {
            using (GDA_Context context = new GDA_Context())
            {
                return context.ComposantDependances.Where(x => typesDependance.Contains(x.DependanceTypeId)).DistinctBy(x => x.DependanceId).Select(x => x.Dependance).ToList();
            }
        }

        public static void CreerDependances(List<Dependance> dependances)
        {
            using (GDA_Context context = new GDA_Context())
            {
                context.Dependances.InsertAllOnSubmit(dependances);

                context.SubmitChanges();
            }
        }
    }
}