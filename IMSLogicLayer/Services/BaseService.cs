﻿using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataAccessInterfaces.Helpers;
using IMSDBLayer.DataAccessObjects;
using IMSDBLayer.DataAccessObjects.Helpers;
using IMSLogicLayer.Models;
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
        private IReportDataAccess reportDataAccess;

        public BaseService(string connstring)
        {
            this.clientDataAccess = new ClientDataAccess(new SqlExecuter<IMSDBLayer.DataModels.Client>(connstring));
            this.districtDataAccess = new DistrictDataAccess(new SqlExecuter<IMSDBLayer.DataModels.District>(connstring));
            this.interventionDataAccess = new InterventionDataAccess(new SqlExecuter<IMSDBLayer.DataModels.Intervention>(connstring));
            this.interventionTypeDataAccess = new InterventionTypeDataAccess(new SqlExecuter<IMSDBLayer.DataModels.InterventionType>(connstring));
            this.userDataAccess = new UserDataAccess(new SqlExecuter<IMSDBLayer.DataModels.User>(connstring));
            this.reportDataAccess = new ReportDataAccess(new SqlExecuter<IMSDBLayer.DataModels.ReportRow>(connstring));
        }

        public IReportDataAccess ReportDataAccess { get => reportDataAccess; set => reportDataAccess = value; }

        internal IClientDataAccess Clients
        {
            get { return clientDataAccess; }
            set { clientDataAccess = value; }
        }

        internal IDistrictDataAccess Districts
        {
            get { return districtDataAccess; }
            set { districtDataAccess = value; }
        }

        internal IInterventionDataAccess Interventions
        {
            get { return interventionDataAccess; }
            set { interventionDataAccess = value; }
        }

        internal IInterventionTypeDataAccess InterventionTypes
        {
            get { return interventionTypeDataAccess; }
            set { interventionTypeDataAccess = value; }
        }

        internal IUserDataAccess Users
        {
            get { return userDataAccess; }
            set { userDataAccess = value; }
        }

        internal Intervention getInterventionDetail()
        {
            return null;
        }

        internal User getDetail(Guid userId)
        {
            User user = new User(Users.fetchUserByIdentityId(userId));
            user.District = new District(Districts.fetchDistrictById(user.DistrictId));
            return user;
        }
    }
}
