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

        public static void ModifierComposant(ComposantModel composantModif)
        {
            using (GDA_Context context = new GDA_Context())
            {
                var composant = context.Composants.FirstOrDefault(x => x.Id == composantModif.Id);

                composant.Nom = composantModif.Nom;
                composant.Abreviation = composantModif.Abreviation;
                composant.Version = composantModif.Version;
                composant.Description = composantModif.Description;
                composant.ComposantTypeId = composantModif.Type.Id;
                composant.NomBD = composantModif.NomBD;
                composant.SourceControlPath = composantModif.SourceControlPath;
                composant.BC = composantModif.BC;
                composant.BW = composantModif.BW;

                context.SubmitChanges();

                ModifierClients(context, composantModif);
                ModifierResponsables(context, composantModif);

            }
        }

        private static void ModifierClients(GDA_Context context, ComposantModel composantModif)
        {
            var clients = context.ComposantClients.Where(x => x.ComposantId == composantModif.Id);

            context.ComposantClients.DeleteAllOnSubmit(clients);

            context.SubmitChanges();

            context.ComposantClients.InsertAllOnSubmit(composantModif.ClientsSelectionnes.Select(x => new ComposantClient
            {
                ClientId = Convert.ToInt32(x),
                ComposantId = composantModif.Id
            }));

            context.SubmitChanges();
        }

        private static void ModifierResponsables(GDA_Context context, ComposantModel composantModif)
        {
            var responsables = context.ComposantResponsables.Where(x => x.ComposantId == composantModif.Id);

            context.ComposantResponsables.DeleteAllOnSubmit(responsables);

            context.SubmitChanges();

            context.ComposantResponsables.InsertAllOnSubmit(composantModif.ResponsablesSelectionnes.Select(x => new ComposantResponsable
            {
                ResponsableId = Convert.ToInt32(x),
                ComposantId = composantModif.Id
            }));

            context.SubmitChanges();
        }
    }
}