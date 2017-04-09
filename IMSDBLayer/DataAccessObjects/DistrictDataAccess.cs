using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataAccessInterfaces;

namespace IMSDBLayer.DataAccessObjects
{
    public class DistrictDataAccess : IDistrictDataAccess
    {
        private string connstring = "";

        public DistrictDataAccess(string connstring)
        {
            this.connstring = connstring;
        }
    }
}
