using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.GDA.DataAccess
{
    public partial class GDA_Context
    {
        public GDA_Context() : base(Settings.ConnectionString)
        {
            OnCreated();
        }
    }
}
