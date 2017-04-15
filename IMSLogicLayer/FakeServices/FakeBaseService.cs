using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataAccessObjects;
using IMSLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.FakeServices
{
    public class FakeBaseService
    {
        private IClientDataAccess clientDataAccess;
        private IDistrictDataAccess districtDataAccess;
        private IInterventionDataAccess interventionDataAccess;
        private IInterventionTypeDataAccess interventionTypeDataAccess;
        private IUserDataAccess userDataAccess;

        internal FakeBaseService(string connstring)
        {
        }

        internal IClientDataAccess Clients
        {
            get { return clientDataAccess; }
        }

        internal IDistrictDataAccess Districts
        {
            get { return districtDataAccess; }
        }

        internal IInterventionDataAccess Interventions
        {
            get { return interventionDataAccess; }
        }

        internal IInterventionTypeDataAccess InterventionTypes
        {
            get { return interventionTypeDataAccess; }
        }

        internal IUserDataAccess Users
        {
            get { return userDataAccess; }
        }

        internal Intervention getInterventionDetail()
        {
            return null;
        }

    }
}
