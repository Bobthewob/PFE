using STM.GDA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace STM.GDA.Service.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public List<App> Apps()
        {
            using (GDA_Context context = new GDA_Context())
            {
                return context.Apps.ToList();
            }
        }
    }
}
