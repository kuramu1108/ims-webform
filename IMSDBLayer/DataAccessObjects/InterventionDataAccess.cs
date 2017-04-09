using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataModels;
using IMSDBLayer.Enums;

namespace IMSDBLayer.DataAccessObjects
{
    public class InterventionDataAccess : IInterventionDataAccess
    {
        private string connstring = "";

        public InterventionDataAccess(string connstring)
        {
            this.connstring = connstring;
        }

        public IEnumerable<Intervention> Interventions => throw new NotImplementedException();

        public Intervention create(Intervention intervention)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Intervention> fetchInterventionsByState(InterventionState state)
        {
            throw new NotImplementedException();
        }

        public bool update(Intervention intervention)
        {
            throw new NotImplementedException();
        }
    }
}
