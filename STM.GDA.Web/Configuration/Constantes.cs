using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STM.GDA.Web.Configuration
{
    public static class Constantes
    {
        public const int ENVIRONNEMENT_PRODUCTION = 4;

        public const int DEPENDANCE_WEB = 1;

        public const int DEPENDANCE_BD = 2;

        public const int DEPENDANCE_INTERFACE = 3;

        public const int DEPENDANCE_JOB = 4;

        public const int DEPENDANCE_EXTERNE = 5;

        public const int DEPENDANCE_RAPPORT = 6;

        public static readonly int[] DEPENDANCE_SERVEURS = { DEPENDANCE_WEB, DEPENDANCE_BD, DEPENDANCE_RAPPORT };

        public static readonly int[] DEPENDANCE_AUTRES = { DEPENDANCE_INTERFACE, DEPENDANCE_JOB, DEPENDANCE_EXTERNE };

   }
}