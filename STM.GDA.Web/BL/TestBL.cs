using STM.GDA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.BL
{
    public static class TestBL
    {
        public static void Test()
        {
            using (GDA_Context context = new GDA_Context())
            {
                var test = context.Apps.ToList();
            }
        }
    }
}