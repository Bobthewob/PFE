using STM.GDA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.GDA.Web
{
	public interface IComposantBL
	{
		List<T> GetCSVList<T>(string filtre = null);
		List<ComposantListeModel> GetList(int take = int.MaxValue - 1, int offset = 0, string filtre = null);
		ComposantModel GetComposant(int id);
		List<ComposantBase> GetListComposantBase();
		void CreerComposant(ComposantModel nouveauComposant);
		void ModifierComposant(ComposantModel composantModif);
		void SupprimerComposant(int id);
	}
}
