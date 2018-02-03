using STM.GDA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STM.GDA.Web.Extensions
{
    public static class ComposantTypeExtensions
    {
        public static SelectListItem ToSelectListItem(this ComposantType type, bool selectionne)
        {
            return new SelectListItem { Value = type.Id.ToString(), Text = type.Nom, Selected = selectionne};
        }
    }
}