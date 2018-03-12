using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using STM.GDA.Web.Controllers;
using STM.GDA.Web.BL;
using STM.GDA.Web.Models;
using System.Web.Mvc;

namespace STM.GDA.Web.Test
{
	[TestFixture]
	public class ComposantTest
	{
		private ComposantController controller;

		[OneTimeSetUp]
		public void Initialization() {
			controller = new ComposantController();
		}

		[Test]
		public void TestGetComposantsEmpty()
		{
			//arrange
			controller.Composantbl = new MockBLComposants(0);

			//act
			var view = controller.GetComposants("", 5, 0);
			var json = ((JsonResult)view).Data.ToString();

			//assert
			Assert.That(json, Is.EqualTo("{ status = All_Loaded, message = no element left to load }"));
		}

		[TestCase(6, 0)]
		[TestCase(6, 1)]
		[TestCase(6, 2)]
		[TestCase(6, 3)]
		[TestCase(6, 4)]
		[TestCase(6, 5)]
		public void TestGetComposantsNotEnd(int nbOfElement, int take)
		{
			//arrange
			controller.Composantbl = new MockBLComposants(nbOfElement);

			//act
			var view = controller.GetComposants("", take, 0);
			var model = (List<ComposantListeModel>)((PartialViewResult)view).Model;

			//assert
			Assert.That(model.Where(x => x.DernierComposantAffiche).Any(), Is.False);		
		}

		[TestCase(1, 1)]
		[TestCase(2, 2)]
		[TestCase(3, 3)]
		[TestCase(4, 4)]
		[TestCase(5, 6)]
		[TestCase(1, 100)]
		public void TestGetComposantsEnd(int nbOfElement, int take)
		{
			//arrange
			controller.Composantbl = new MockBLComposants(nbOfElement);

			//act
			var view = controller.GetComposants("", take, 0);
			var model = (List<ComposantListeModel>)((PartialViewResult)view).Model;

			//assert
			Assert.That(model.Where(x => x.DernierComposantAffiche).Any(), Is.True);
		}
	}
}