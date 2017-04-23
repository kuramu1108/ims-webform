using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMSLogicLayer.ServiceInterfaces;

namespace InterventionManagementSystem.Tests
{
    [TestClass]
    public class IMSLogicManagerServiceTest
    {
        private IManagerService managerService;

        [TestInitialize]
        public void setUp()
        {
            //manager = new Manager(2, "Luke", "luke1234", Support.convertToSS("12345678"), Common.UserType.Manager, Common.Districts.Sydney, 10, 500);
        }

        [TestMethod]
        public void IMSLogicManager_ChangePassword_Success()
        {

        }

        [TestMethod]
        public void IMSLogicManager_ChangePassword_SamePassword_Failed()
        {

        }

        [TestMethod]
        public void IMSLogicManager_ViewListofInterventionCanApprove()
        {

        }

        [TestMethod]
        public void IMSLogicManager_ApproveIntervention_Success()
        {

        }

        [TestMethod]
        public void IMSLogicManager_ApproveIntervention_Failed()
        {
            
        }
    }
}
