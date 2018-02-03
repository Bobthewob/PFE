using STM.GDA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STM.GDA.Web.Extensions
{
    public static class ClientExtentions
    {
        public static SelectListItem ToSelectListItem(this Client client, bool selectionne)
        {
            return new SelectListItem { Value = client.Id.ToString(), Text = client.Nom, Selected = selectionne};
        }
    }
}