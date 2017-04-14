using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.Services
{
    public class BaseService
    {
        private IClientDataAccess clientDataAccess;
        private IDistrictDataAccess districtDataAccess;
        private IInterventionDataAccess interventionDataAccess;
        private IInterventionTypeDataAccess interventionTypeDataAccess;
        private IUserDataAccess userDataAccess;

        public BaseService(string connstring)
        {
            this.clientDataAccess = new ClientDataAccess(connstring);
            this.districtDataAccess = new DistrictDataAccess(connstring);
            this.interventionDataAccess = new InterventionDataAccess(connstring);
            this.interventionTypeDataAccess = new InterventionTypeDataAccess(connstring);
            this.userDataAccess = new UserDataAccess(connstring);
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
    }
}
