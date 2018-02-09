using STM.GDA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STM.GDA.Web.Extensions
{
   public static class DependanceExtensions
   {
      public static SelectListItem ToSelectListItem(this Dependance dependance)
      {
         return new SelectListItem { Value = dependance.Id.ToString(), Text = dependance.Nom };
      }
   }
}