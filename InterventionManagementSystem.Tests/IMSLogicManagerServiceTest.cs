using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMSLogicLayer.ServiceInterfaces;
using IMSLogicLayer.Models;
using IMSDBLayer.DataAccessInterfaces;
using Moq;
using IMSLogicLayer.Services;
using System.Collections.Generic;
using IMSLogicLayer.Enums;

namespace InterventionManagementSystem.Tests
{
    [TestClass]
    public class IMSLogicManagerServiceTest
    {
        private ManagerService managerService;
        private InterventionService interventionService;
        [TestInitialize]
        public void setUp()
        {
            //manager = new Manager(2, "Luke", "luke1234", Support.convertToSS("12345678"), Common.UserType.Manager, Common.Districts.Sydney, 10, 500);
            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            Mock<IDistrictDataAccess> districts = new Mock<IDistrictDataAccess>();
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            Mock<IInterventionTypeDataAccess> interventionTypes = new Mock<IInterventionTypeDataAccess>();

            managerService = new ManagerService("");
            interventionService = new InterventionService("");
            interventionService.Clients = clients.Object;
            interventionService.Users = users.Object;
            interventionService.Districts = districts.Object;
            interventionService.Interventions = interventions.Object;
            interventionService.InterventionTypes = interventionTypes.Object;


            managerService.Clients = clients.Object;
            managerService.Users = users.Object;
            managerService.Districts = districts.Object;
            managerService.Interventions = interventions.Object;
            managerService.InterventionTypes = interventionTypes.Object;

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
            Guid districtID = new Guid();
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            List<Intervention> interventionList = new List<Intervention>();
            interventionList.Add(new Intervention(5, 2, 70, "", IMSLogicLayer.Enums.InterventionState.Proposed, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid()));
            interventionList.Add(new Intervention(3, 5, 50, "", IMSLogicLayer.Enums.InterventionState.Approved, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid()));
            interventionList.Add(new Intervention(6, 9, 80, "", IMSLogicLayer.Enums.InterventionState.Proposed, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid()));

            interventions.Setup(c => c.fetchInterventionsByApprovedUser(It.IsAny<Guid>())).Returns(interventionList);

            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            User manager = new User("Jason", 2, 10, 1000, Guid.NewGuid().ToString(), districtID);
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(manager);
            managerService.Users = users.Object;
            Assert.AreEqual(managerService.getListOfProposedIntervention(), interventionList);


        }

        [TestMethod]
        public void IMSLogicManager_ApproveIntervention_Success()
        {
            Guid districtID = new Guid();
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();

            Intervention new_intervention = new Intervention(5, 2, 70, "", InterventionState.Proposed, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid());
            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            User manager = new User("Huey", 2, 15, 800, Guid.NewGuid().ToString(), districtID);
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(manager);
            managerService.Users = users.Object;
            managerService.approveAnIntervention(new_intervention.Id);
            Assert.IsTrue(interventionService.interventionApproved(new_intervention.Id));
        }

        [TestMethod]
        public void IMSLogicManager_ApproveIntervention_Failed()
        {
            Guid districtID = new Guid();
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();

            Intervention new_intervention = new Intervention(20, 2, 70, "", InterventionState.Proposed, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid());
            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            User manager = new User("Huey", 2, 15, 800, Guid.NewGuid().ToString(), districtID);
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(manager);
            managerService.Users = users.Object;
            Assert.IsFalse(managerService.approveAnIntervention(new_intervention.Id));
        }
    }
}
