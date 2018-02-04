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

        public static void CreerComposant(ComposantModel nouveauComposant)
        {
            using (GDA_Context context = new GDA_Context())
            {
                var composant = new Composant
                {
                    Nom = nouveauComposant.Nom,
                    Abreviation = nouveauComposant.Abreviation,
                    Version = nouveauComposant.Version,
                    Description = nouveauComposant.Description,
                    ComposantTypeId = nouveauComposant.Type.Id,
                    NomBD = nouveauComposant.NomBD,
                    SourceControlPath = nouveauComposant.SourceControlPath,
                    BC = nouveauComposant.BC,
                    BW = nouveauComposant.BW,
                    DerniereMAJ = DateTime.Now,
                    DateCreation = DateTime.Now
                };

                context.Composants.InsertOnSubmit(composant);

                context.SubmitChanges();

                nouveauComposant.Id = composant.Id; //Set the newly inserted id

                CreerEnvironnements(context, nouveauComposant);
                ModifierClients(context, nouveauComposant);
                ModifierResponsables(context, nouveauComposant);
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
                composant.DerniereMAJ = DateTime.Now;

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

            //New clients
            if (composantModif.Clients.Any(x => x.Id == 0))
            {
                var nouveauxClients = composantModif.Clients.Where(x => x.Id == 0).Select(x => new Client
                {
                    Nom = x.Nom
                }).ToList();

                ClientBL.CreerClients(nouveauxClients);

                context.ComposantClients.InsertAllOnSubmit(nouveauxClients.Select(x => new ComposantClient
                {
                    ClientId = x.Id,
                    ComposantId = composantModif.Id
                }));
            }

            //Existing clients
            context.ComposantClients.InsertAllOnSubmit(composantModif.Clients.Where(x => x.Id != 0).Select(x => new ComposantClient
            {
                ClientId = x.Id,
                ComposantId = composantModif.Id
            }));

            context.SubmitChanges();
        }

        private static void ModifierResponsables(GDA_Context context, ComposantModel composantModif)
        {
            var responsables = context.ComposantResponsables.Where(x => x.ComposantId == composantModif.Id);

            context.ComposantResponsables.DeleteAllOnSubmit(responsables);

            context.SubmitChanges();

            //New responsables
            if (composantModif.Responsables.Any(x => x.Id == 0))
            {
                var nouveauxResponsables = composantModif.Responsables.Where(x => x.Id == 0).Select(x => new Responsable
                {
                    Nom = x.Nom
                }).ToList();

                ResponsableBL.CreerResponsables(nouveauxResponsables);

                context.ComposantResponsables.InsertAllOnSubmit(nouveauxResponsables.Select(x => new ComposantResponsable
                {
                    ResponsableId = x.Id,
                    ComposantId = composantModif.Id
                }));
            }

            //Existing responsables
            context.ComposantResponsables.InsertAllOnSubmit(composantModif.Responsables.Where(x => x.Id != 0).Select(x => new ComposantResponsable
            {
                ResponsableId = x.Id,
                ComposantId = composantModif.Id
            }));

            context.SubmitChanges();
        }

        private static void CreerEnvironnements(GDA_Context context, ComposantModel composant)
        {
            var environnements = context.Environnements.ToList();

            context.ComposantEnvironnements.InsertAllOnSubmit(environnements.Select(x => new ComposantEnvironnement
            {
                ComposantId = composant.Id,
                EnvironnementId = x.Id,
                Ordre = x.Ordre
            }));

            context.SubmitChanges();
        }
    }
}