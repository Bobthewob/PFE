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
        public static SelectListItem ToSelectListItem(this ComposantType etiquette, bool selectionne)
        {
            return new SelectListItem { Value = etiquette.Id.ToString(), Text = etiquette.Nom, Selected = selectionne};
        }
    }
}