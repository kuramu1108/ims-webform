using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataAccessInterfaces;

namespace IMSDBLayer.DataAccessObjects
{
    public class InterventionTypeDataAccess : IInterventionTypeDataAccess
    {
        private string connstring = "";

        public InterventionTypeDataAccess(string connstring)
        {
            this.connstring = connstring;
        }
    }
}
