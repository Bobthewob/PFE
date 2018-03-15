using STM.GDA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace STM.GDA.Web.BL
{
	public class MockComposantBL : IComposantBL
	{
		public List<ComposantListeModel> composants { get; set; }

		public MockComposantBL(int _nbOfElements)
		{
			composants = new List<ComposantListeModel>();

			for (int i = 0; i < _nbOfElements; i++)
			{
				composants.Add(MockGetSingleComposantListeModel(i));
			}
		}

		private ComposantListeModel MockSingleComposantListeModel
		{
			get
			{
				return new ComposantListeModel()
				{
					Id = 0,
					Nom = "MockItem1",
					Description = "Lorem ipsum",
					Dependances = new List<EtiquetteModel>()
					{
						new EtiquetteModel(){
							Id = 1,
							Nom = "MockDependance1"
						},
						new EtiquetteModel(){
							Id = 2,
							Nom = "MockDependance2"
						},
						new EtiquetteModel(){
							Id = 3,
							Nom = "MockDependance3"
						}
					},
					Technologies = new List<EtiquetteModel>()
					{
						new EtiquetteModel(){
							Id = 1,
							Nom = "MockTechnologie1"
						},
						new EtiquetteModel(){
							Id = 2,
							Nom = "MockTechnologie2"
						},
						new EtiquetteModel(){
							Id = 3,
							Nom = "MockTechnologie3"
						}
					},
					DernierComposantAffiche = false
				};
			}
		}

		private ComposantListeModel MockGetSingleComposantListeModel(int id)
		{
			var currentComp = MockSingleComposantListeModel;
			currentComp.Id = id;

			return currentComp;
		}

		public List<ComposantListeModel> MockEmptyComposantListeModel()
		{
			var composants = new List<ComposantListeModel>();
			composants.Add(MockGetSingleComposantListeModel(1));

			return composants;
		}

		public List<T> GetCSVList<T>(string filtre = null)
		{
			throw new NotImplementedException();
		}

		public List<ComposantListeModel> GetList(int take = 2147483646, int offset = 0, string filtre = null)
		{
			return composants.Skip(offset).Take(take + 1).ToList();
		}

		public ComposantModel GetComposant(int id)
		{
			throw new NotImplementedException();
		}

		public List<ComposantBase> GetListComposantBase()
		{
			throw new NotImplementedException();
		}

		public void CreerComposant(ComposantModel nouveauComposant)
		{
			throw new NotImplementedException();
		}

		public void ModifierComposant(ComposantModel composantModif)
		{
			throw new NotImplementedException();
		}

		public void SupprimerComposant(int id)
		{
			throw new NotImplementedException();
		}
	}
}