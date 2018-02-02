using STM.GDA.DataAccess;
using STM.GDA.Web.Models;
using STM.GDA.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.BL
{
    public static class ComposantBL
    {
        public static List<ComposantListeModel> GetList()
        {
            using (GDA_Context context = new GDA_Context())
            {
                return context.Composants.Select(x => x.ToComposantListeModel()).ToList();
            }
        }

        public static ComposantModel GetComposant(int id)
        {
            using (GDA_Context context = new GDA_Context())
            {
                return context.Composants.FirstOrDefault(x => x.Id == id)?.ToComposantModel();
            }
        }
    }
}