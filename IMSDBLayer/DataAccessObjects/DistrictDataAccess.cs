using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataModels;

namespace IMSDBLayer.DataAccessObjects
{
    public class DistrictDataAccess : IDistrictDataAccess
    {
        private string connstring = "";

        public DistrictDataAccess(string connstring)
        {
            this.connstring = connstring;
        }

        public IEnumerable<District> Districts => throw new NotImplementedException();

        public District create(District district)
        {
            throw new NotImplementedException();
        }

        public bool update(District district)
        {
            throw new NotImplementedException();
        }
    }
}
