using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataModels;

namespace IMSDBLayer.DataAccessObjects
{
    public class InterventionTypeDataAccess : IInterventionTypeDataAccess
    {
        private string connstring = "";

        public InterventionTypeDataAccess(string connstring)
        {
            this.connstring = connstring;
        }

        public IEnumerable<InterventionType> InterventionTypes => throw new NotImplementedException();

        public InterventionType create(InterventionType interventionType)
        {
            throw new NotImplementedException();
        }

        public InterventionType fetchInterventionTypesById(Guid interventionTypeId)
        {
            throw new NotImplementedException();
        }

        public bool update(InterventionType interventionType)
        {
            throw new NotImplementedException();
        }
    }
}
