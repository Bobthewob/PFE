using STM.GDA.DataAccess;
using STM.GDA.Web.Models;
using STM.GDA.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using System.Web;

namespace STM.GDA.Web.BL
{
    public class ComposantBL : IComposantBL
    {
        public List<T> GetCSVList<T>(string filtre = null)
        {
            using (GDA_Context context = new GDA_Context())
            {
                var query = context.Composants.Select(x => x);

                if (!String.IsNullOrEmpty(filtre))
                {
                    query = FilterQuery(query, filtre.ToLowerInvariant());
                }

				if (typeof(T) == typeof(CSVComposantListeModelLong))
				{
					return query.Select(x => (T)Convert.ChangeType(x.ToCSVComposantListeModelLong(), typeof(T))).ToList();
				}
				else if (typeof(T) == typeof(CSVComposantListeModelCourt))
				{
					return query.Select(x => (T)Convert.ChangeType(x.ToCSVComposantListeModelCourt(), typeof(T))).ToList();
				}

				throw new NotSupportedException($"Type : {typeof(T).Name} is not supported.");
			}
        }

        public List<ComposantListeModel> GetList(int take = int.MaxValue -1, int offset = 0, string filtre = null)
        {
            using (GDA_Context context = new GDA_Context())
            {
                var query = context.Composants.Select(x => x);

                if (!String.IsNullOrEmpty(filtre))
                {
                    query = FilterQuery(query, filtre);
                }

                return query.Skip(offset).Take(take + 1).Select(x => x.ToComposantListeModel()).ToList();
            }
        }

        private IQueryable<Composant> FilterQuery(IQueryable<Composant> query, string filtre)
        {
            return query.Where(x => x.Nom.ToLower().Contains(filtre) ||
                            x.Abreviation.ToLower().Contains(filtre) ||
                            x.Description.ToLower().Contains(filtre) ||
                            x.SourceControlPath.ToLower().Contains(filtre) ||
                            x.BC.ToLower().Contains(filtre) ||
                            x.BW.ToLower().Contains(filtre) ||
                            x.Nom.ToLower().Contains(filtre) ||
                            x.Version.ToLower().Contains(filtre) ||
                            x.ComposantType.Nom.Contains(filtre) ||
                            x.ComposantClients.Any(c => c.Client.Nom.ToLower().Contains(filtre)) ||
                            x.ComposantResponsables.Any(r => r.Responsable.Nom.ToLower().Contains(filtre)) ||
                            x.ComposantTechnologies.Any(t => t.Technologie.Nom.ToLower().Contains(filtre)) ||
                            x.ComposantDependances.Any(d => d.Dependance.Nom.ToLower().Contains(filtre)));
        }

        public ComposantModel GetComposant(int id)
        {
            using (GDA_Context context = new GDA_Context())
            {
                return context.Composants.FirstOrDefault(x => x.Id == id)?.ToComposantModel();
            }
        }

        public List<ComposantBase> GetListComposantBase()
        {
            using (GDA_Context context = new GDA_Context())
            {
                return context.Composants.Select(x => x.ToComposantBaseModel()).ToList();
            }
        }

        public void CreerComposant(ComposantModel nouveauComposant)
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
                    DerniereMAJ = DateTime.Now
                };

                context.Composants.InsertOnSubmit(composant);

                context.SubmitChanges();

                nouveauComposant.Id = composant.Id; //Set the newly inserted id

                CreerEnvironnements(context, nouveauComposant); //This call has to be made before adding dependencies
                ModifierClients(context, nouveauComposant);
                ModifierResponsables(context, nouveauComposant);
                ModifierTechnologies(context, nouveauComposant);
                ModifierDependances(context, nouveauComposant);
            }
        }

        public void ModifierComposant(ComposantModel composantModif)
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
                ModifierTechnologies(context, composantModif);
                ModifierDependances(context, composantModif);
            }
        }

        public void SupprimerComposant(int id)
        {
            using (GDA_Context context = new GDA_Context())
            {
                var composant = context.Composants.FirstOrDefault(x => x.Id == id);

                context.ComposantClients.DeleteAllOnSubmit(context.ComposantClients.Where(x => x.ComposantId == id));
                context.ComposantDependances.DeleteAllOnSubmit(context.ComposantDependances.Where(x => x.ComposantId == id));
                context.ComposantEnvironnements.DeleteAllOnSubmit(context.ComposantEnvironnements.Where(x => x.ComposantId == id));
                context.ComposantResponsables.DeleteAllOnSubmit(context.ComposantResponsables.Where(x => x.ComposantId == id));
                context.ComposantTechnologies.DeleteAllOnSubmit(context.ComposantTechnologies.Where(x => x.ComposantId == id));
                context.Deploiements.DeleteAllOnSubmit(context.Deploiements.Where(x => x.ComposantId == id));

                context.Composants.DeleteOnSubmit(composant);

                context.SubmitChanges();
            }
        }

        private static void ModifierClients(GDA_Context context, ComposantModel composantModif)
        {
            var clients = context.ComposantClients.Where(x => x.ComposantId == composantModif.Id);

            context.ComposantClients.DeleteAllOnSubmit(clients);

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

        private static void ModifierTechnologies(GDA_Context context, ComposantModel composantModif)
        {
            var technologies = context.ComposantTechnologies.Where(x => x.ComposantId == composantModif.Id);

            context.ComposantTechnologies.DeleteAllOnSubmit(technologies);

            //New technologies
            if (composantModif.Technologies.Any(x => x.Id == 0))
            {
                var nouvellesTechnologies = composantModif.Technologies.Where(x => x.Id == 0).Select(x => new Technologie
                {
                    Nom = x.Nom
                }).ToList();
                
                TechnologieBL.CreerTechnologies(nouvellesTechnologies);

                context.ComposantTechnologies.InsertAllOnSubmit(nouvellesTechnologies.Select(x => new ComposantTechnologie
                {
                    TechnologieId = x.Id,
                    ComposantId = composantModif.Id
                }));
            }

            //Existing technologies
            context.ComposantTechnologies.InsertAllOnSubmit(composantModif.Technologies.Where(x => x.Id != 0).Select(x => new ComposantTechnologie
            {
                TechnologieId = x.Id,
                ComposantId = composantModif.Id
            }));

            context.SubmitChanges();
        }

        private static void ModifierDependances(GDA_Context context, ComposantModel composantModif)
        {
            var dependances = context.ComposantDependances.Where(x => x.ComposantId == composantModif.Id);

            context.ComposantDependances.DeleteAllOnSubmit(dependances);

            //New dependencies
            if (composantModif.RawDependances.Any(x => x.Etiquette.Id == 0))
            {
                var nouvellesDependances = composantModif.RawDependances.Where(x => x.Etiquette.Id == 0).DistinctBy(x => x.Etiquette.Nom).Select(x => new Dependance
                {
                    Nom = x.Etiquette.Nom
                }).ToList();

                DependanceBL.CreerDependances(nouvellesDependances);

                context.ComposantDependances.InsertAllOnSubmit(composantModif.RawDependances.Where(x => x.Etiquette.Id == 0).Select(x => new ComposantDependance
                {
                    DependanceId = nouvellesDependances.SingleOrDefault(nd => nd.Nom == x.Etiquette.Nom).Id,
                    ComposantId = composantModif.Id,
                    EnvironnementId = x.EnvironnementId,
                    DependanceTypeId = x.Type.Id
                }));
            }

            //Existing dependencies
            context.ComposantDependances.InsertAllOnSubmit(composantModif.RawDependances.Where(x => x.Etiquette.Id != 0).Select(x => new ComposantDependance
            {
                DependanceId = x.Etiquette.Id,
                ComposantId = composantModif.Id,
                EnvironnementId = x.EnvironnementId,
                DependanceTypeId = x.Type.Id
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