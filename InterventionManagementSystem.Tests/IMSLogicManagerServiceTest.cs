using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMSLogicLayer.Services;
using IMSDBLayer.DataAccessInterfaces;
using IMSLogicLayer.Models;
using Moq;
using IMSLogicLayer.ServiceInterfaces;

namespace InterventionManagementSystem.Tests
{
    [TestClass]
    public class IMSLogicManagerServiceTest
    {
        private ManagerService managerService;

        [TestInitialize]
        public void SetUp()
        {
            Mock<IInterventionTypeDataAccess> interventionTypes = new Mock<IInterventionTypeDataAccess>();
            interventionTypes.Setup(it => it.fetchInterventionTypesById(It.IsAny<Guid>())).Returns(new InterventionType("", 1, 2));

            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            clients.Setup(c => c.fetchClientById(It.IsAny<Guid>())).Returns(new Client("", "", new Guid()));

            Mock<IDistrictDataAccess> districts = new Mock<IDistrictDataAccess>();
            districts.Setup(d => d.fetchDistrictById(It.IsAny<Guid>())).Returns(new District(""));
            managerService = new ManagerService("");
        }

        [TestMethod]
        public void IMSLogicManager_ViewListofInterventionCanApprove()
        {
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            List<Intervention> interventionList = new List<Intervention>();
            new Intervention(new IMSDBLayer.DataModels.Intervention());
            Intervention intervention1 = new Intervention(new IMSDBLayer.DataModels.Intervention());
            Intervention intervention2 = new Intervention(new IMSDBLayer.DataModels.Intervention());
            Intervention intervention3 = new Intervention(new IMSDBLayer.DataModels.Intervention());
            Intervention intervention4 = new Intervention(new IMSDBLayer.DataModels.Intervention());
            Intervention intervention5 = new Intervention(new IMSDBLayer.DataModels.Intervention());
            interventionList.Add(intervention1);
            interventionList.Add(intervention2);
            interventionList.Add(intervention3);
            interventionList.Add(intervention4);
            interventionList.Add(intervention5);
            
            interventions.Setup(i => i.fetchInterventionsByState(It.IsAny<int>())).Returns(interventionList);

            Mock<IInterventionTypeDataAccess> interventionTypes = new Mock<IInterventionTypeDataAccess>();
            interventionTypes.Setup(it => it.fetchInterventionTypesById(It.IsAny<Guid>())).Returns(new InterventionType("", 1, 2));

            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            clients.Setup(c => c.fetchClientById(It.IsAny<Guid>())).Returns(new Client("", "", new Guid()));

            Mock<IDistrictDataAccess> districts = new Mock<IDistrictDataAccess>();
            districts.Setup(d => d.fetchDistrictById(It.IsAny<Guid>())).Returns(new District(""));

            managerService.Interventions = interventions.Object;
            managerService.InterventionTypes = interventionTypes.Object;
            managerService.Clients = clients.Object;
            managerService.Districts = districts.Object;

            List<Intervention> results = managerService.getInterventionsByState(IMSLogicLayer.Enums.InterventionState.Proposed).ToList();

            foreach (Intervention i in results)
            {
                Assert.AreEqual(IMSLogicLayer.Enums.InterventionState.Proposed, i.InterventionState);
            }
        }

        [TestMethod]
        public void IMSLogicManager_ApproveIntervention_Success()
        {
            Guid interventionId = IMSLogicManager_ApproveInterventionTests_Setup();

            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            Guid clientDistrict = new Guid();
            Client client = new Client("Po", "Asquith", clientDistrict);
            clients.Setup(c => c.fetchClientById(It.IsAny<Guid>())).Returns(client);

            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            User user = new User("AccountantX", 1, 20, 200, "", clientDistrict);
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(user);

            Mock<IInterventionService> interventionService = new Mock<IInterventionService>();
            interventionService.Setup(x => x.updateInterventionState(It.IsAny<Guid>(), IMSLogicLayer.Enums.InterventionState.Approved, user.Id)).Returns(true);

            managerService.Clients = clients.Object;
            managerService.Users = users.Object;
            managerService.InterventionService = interventionService.Object;

            bool result = managerService.approveAnIntervention(interventionId);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IMSLogicManager_ApproveIntervention_Failed_DifferentDistrict()
        {
            Guid interventionId = IMSLogicManager_ApproveInterventionTests_Setup();

            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            Guid clientDistrict = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709");
            Client client = new Client("Po", "Asquith", clientDistrict);
            clients.Setup(c => c.fetchClientById(It.IsAny<Guid>())).Returns(client);

            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            Guid userDistrict = new Guid("AD2B0228-4D0D-4C23-8B49-01A698857709");
            User user = new User("AccountantX", 1, 20, 200, "", userDistrict);
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(user);

            managerService.Clients = clients.Object;
            managerService.Users = users.Object;

            bool result = managerService.approveAnIntervention(interventionId);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IMSLogicManager_ApproveIntervention_Failed_InsufficientAuthorisedCost()
        {
            Guid interventionId = IMSLogicManager_ApproveInterventionTests_Setup();

            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            Guid clientDistrict = new Guid();
            Client client = new Client("Po", "Asquith", clientDistrict);
            clients.Setup(c => c.fetchClientById(It.IsAny<Guid>())).Returns(client);

            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            User user = new User("AccountantX", 1, 20, 0, "", clientDistrict);
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(user);

            managerService.Clients = clients.Object;
            managerService.Users = users.Object;

            bool result = managerService.approveAnIntervention(interventionId);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IMSLogicManager_ApproveIntervention_Failed_InsufficientAuthorisedHours()
        {
            Guid interventionId = IMSLogicManager_ApproveInterventionTests_Setup();

            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            Guid clientDistrict = new Guid();
            Client client = new Client("Po", "Asquith", clientDistrict);
            clients.Setup(c => c.fetchClientById(It.IsAny<Guid>())).Returns(client);

            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            User user = new User("AccountantX", 1, 0, 200, "", clientDistrict);
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(user);

            managerService.Clients = clients.Object;
            managerService.Users = users.Object;

            bool result = managerService.approveAnIntervention(interventionId);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IMSLogicManager_UpdateInterventionState_Success()
        {
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            IMSDBLayer.DataModels.Intervention intervention = new IMSDBLayer.DataModels.Intervention();

            interventions.Setup(i => i.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);

            Guid clientDistrict = new Guid();
            Mock<IDistrictDataAccess> districts = new Mock<IDistrictDataAccess>();
            District district = new District("Sydney")
            {
                Id = clientDistrict
            };
            districts.Setup(d => d.fetchDistrictById(It.IsAny<Guid>())).Returns(district);

            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            User user = new User("AccountantX", 1, 0, 200, "", clientDistrict);
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(user);
        }

        [TestMethod]
        public void IMSLogicManager_UpdateInterventionState_Failed_DifferentDistricts()
        {

        }

        [TestMethod]
        public void IMSLogicManager_UpdateInterventionApprovedBy_Success()
        {

        }

        [TestMethod]
        public void IMSLogicManager_UpdateInterventionApprovedBy_Failed_DifferentDistricts()
        {

        }

        private Guid IMSLogicManager_ApproveInterventionTests_Setup()
        {
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            Intervention intervention = new Intervention(5, 50, 1, "", IMSLogicLayer.Enums.InterventionState.Proposed, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), null);
            interventions.Setup(i => i.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);

            Mock<IInterventionTypeDataAccess> interventionTypes = new Mock<IInterventionTypeDataAccess>();
            InterventionType interventionType = new InterventionType("toilet", 5, 50);
            interventionTypes.Setup(it => it.fetchInterventionTypesById(It.IsAny<Guid>())).Returns(interventionType);

            managerService.Interventions = interventions.Object;
            managerService.InterventionTypes = interventionTypes.Object;

            return intervention.Id;
        }
    }
}
