using STM.GDA.DataAccess;
using STM.GDA.Web.Extensions;
using STM.GDA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.BL
{
    public static class DeploiementBL
    {
        public static List<DeploiementListeModel> GetList(int take, int offset, string filtre)
        {
            using (GDA_Context context = new GDA_Context())
            {
                var query = context.Deploiements.Select(x => x);

                if (!String.IsNullOrEmpty(filtre))
                {
                    query = query.Where(x => x.Composant.Nom.ToLower().Contains(filtre) ||
                            x.Environnement.Nom.ToLower().Contains(filtre));
                }

                return query.Skip(offset).Take(take + 1).Select(x => x.ToDeploiementListeModel()).ToList();
            }
        }

    }
}