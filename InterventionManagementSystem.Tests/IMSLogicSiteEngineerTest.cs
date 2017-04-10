using IMSDBLayer;
using IMSLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterventionManagementSystem2.Tests
{
    [TestClass]
    class IMSLogicSiteEngineerTest
    {
        private SiteEngineer siteEngineer;

        [TestInitialize]
        public void setUp()
        {
            siteEngineer = new SiteEngineer(3, "Ben", "Benjamin", Support.convertToSS("55555555"),Common.UserType.SiteEngineer, Common.Districts.RuralNewSouthWales, 7, 200);
        }

        [TestMethod]
        public void IMSLogicSiteEngineer_ChangePassword_Success()
        {

        }

        [TestMethod]
        public void IMSLogicSiteEngineer_ChangePassword_SamePassword_Failed()
        {

        }

        [TestMethod]
        public void IMSLogicSiteEngineer_CreateClientinDistrict()
        {

        }

        [TestMethod]
        public void IMSLogicSiteEngineer_GetListofClientsinDistrict()
        {

        }

        [TestMethod]
        public void IMSLogicSiteEngineer_GetClientDetail()
        {

        }

        [TestMethod]
        public void IMSLogicSiteEngineer_CreateInterventionforClient()
        {

        }

        [TestMethod]
        public void IMSLogicSiteEngineer_GetListofInterventionCreated()
        {

        }

        [TestMethod]
        public void IMSLogicSiteEngineer_ChangeStateofInterventionCreated()
        {

        }
    }


}
