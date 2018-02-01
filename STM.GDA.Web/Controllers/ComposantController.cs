using STM.GDA.Web.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STM.GDA.Web.Controllers
{
   public class ComposantController : BaseController
   {
      public ActionResult Index()
      {
         return View(ComposantBL.GetList());
      }
   }
}