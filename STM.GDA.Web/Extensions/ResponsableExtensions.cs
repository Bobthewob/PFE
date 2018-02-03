using STM.GDA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STM.GDA.Web.Extensions
{
    public static class ResponsableExtensions
    {
        public static SelectListItem ToSelectListItem(this Responsable responsable)
        {
            return new SelectListItem { Value = responsable.Id.ToString(), Text = responsable.Nom };
        }
    }
}