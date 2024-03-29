﻿using STM.GDA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.BL
{
    public static class ClientBL
    {
        public static List<Client> GetAllClients()
        {
            using (GDA_Context context = new GDA_Context())
            {
                return context.Clients.ToList();
            }
        }

        public static void CreerClients(List<Client> clients)
        {
            using (GDA_Context context = new GDA_Context())
            {
                context.Clients.InsertAllOnSubmit(clients);

                context.SubmitChanges();
            }
        }
    }
}