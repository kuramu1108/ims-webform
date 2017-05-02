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
        private Guid District_SydId = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709");
        private Guid District_NswId = new Guid("ABCD0228-4D0D-4C23-8B49-01A698857709");

        [TestInitialize]
        public void SetUp()
        {
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

            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(new User("", 1, 1, 1, "", new Guid()));

            managerService.Interventions = interventions.Object;
            managerService.InterventionTypes = interventionTypes.Object;
            managerService.Clients = clients.Object;
            managerService.Districts = districts.Object;
            managerService.Users = users.Object;

            List<Intervention> results = managerService.GetInterventionsByState(IMSLogicLayer.Enums.InterventionState.Proposed).ToList();

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

            Mock<IDistrictDataAccess> districts = new Mock<IDistrictDataAccess>();
            District district = new District("Sydney");
            districts.Setup(d => d.fetchDistrictById(It.IsAny<Guid>())).Returns(district);

            managerService.Clients = clients.Object;
            managerService.Users = users.Object;
            managerService.InterventionService = interventionService.Object;
            managerService.Districts = districts.Object;

            bool result = managerService.ApproveAnIntervention(interventionId);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IMSLogicManager_ApproveIntervention_Failed_DifferentDistrict()
        {
            Guid interventionId = IMSLogicManager_ApproveInterventionTests_Setup();

            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            Guid clientDistrict = District_SydId;
            Client client = new Client("Po", "Asquith", clientDistrict);
            clients.Setup(c => c.fetchClientById(It.IsAny<Guid>())).Returns(client);

            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            Guid userDistrict = District_NswId;
            User user = new User("AccountantX", 1, 20, 200, "", userDistrict);
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(user);

            Mock<IDistrictDataAccess> districts = new Mock<IDistrictDataAccess>();
            District district = new District("NSW");
            districts.Setup(d => d.fetchDistrictById(It.IsAny<Guid>())).Returns(district);

            managerService.Clients = clients.Object;
            managerService.Users = users.Object;
            managerService.Districts = districts.Object;

            bool result = managerService.ApproveAnIntervention(interventionId);

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

            Mock<IDistrictDataAccess> districts = new Mock<IDistrictDataAccess>();
            District district = new District("NSW");
            districts.Setup(d => d.fetchDistrictById(It.IsAny<Guid>())).Returns(district);

            managerService.Clients = clients.Object;
            managerService.Users = users.Object;
            managerService.Districts = districts.Object;

            bool result = managerService.ApproveAnIntervention(interventionId);

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

            Mock<IDistrictDataAccess> districts = new Mock<IDistrictDataAccess>();
            District district = new District("NSW");
            districts.Setup(d => d.fetchDistrictById(It.IsAny<Guid>())).Returns(district);

            managerService.Clients = clients.Object;
            managerService.Users = users.Object;
            managerService.Districts = districts.Object;

            bool result = managerService.ApproveAnIntervention(interventionId);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IMSLogicManager_UpdateInterventionState_Success()
        {
            Guid clientDistrictId = District_SydId;
            Guid userDistrictId = clientDistrictId;

            Guid interventionId = IMSLogicManager_UpdateInterventionTests_Setup(clientDistrictId, userDistrictId);

            Mock<IInterventionService> interventionService = new Mock<IInterventionService>();
            interventionService.Setup(x => x.updateInterventionState(It.IsAny<Guid>(), IMSLogicLayer.Enums.InterventionState.Approved)).Returns(true);

            managerService.InterventionService = interventionService.Object;

            Assert.IsTrue(managerService.UpdateInterventionState(interventionId, IMSLogicLayer.Enums.InterventionState.Approved));
        }

        [TestMethod]
        public void IMSLogicManager_UpdateInterventionState_Failed_DifferentDistricts()
        {
            Guid clientDistrictId = District_SydId;
            Guid userDistrictId = District_NswId;

            Guid interventionId = IMSLogicManager_UpdateInterventionTests_Setup(clientDistrictId, userDistrictId);

            Assert.IsFalse(managerService.UpdateInterventionState(interventionId, IMSLogicLayer.Enums.InterventionState.Approved));
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

        private Guid IMSLogicManager_UpdateInterventionTests_Setup(Guid clientDistrictId, Guid userDistrictId)
        {
            Guid clientId = new Guid();

            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            IMSDBLayer.DataModels.Intervention intervention = new IMSDBLayer.DataModels.Intervention()
            {
                ClientId = clientId,
            };
            interventions.Setup(i => i.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);

            Mock<IDistrictDataAccess> districts = new Mock<IDistrictDataAccess>();
            District District_Syd = new District("Sydney")
            {
                Id = District_SydId,
            };
            District District_Nsw = new District("NSW")
            {
                Id = District_NswId,
            };
            districts.Setup(d => d.fetchDistrictById(It.Is<Guid>(id => id == District_SydId))).Returns(District_Syd);
            districts.Setup(d => d.fetchDistrictById(It.Is<Guid>(id => id == District_NswId))).Returns(District_Nsw);
            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            Client client = new Client("", "", clientDistrictId)
            {
                Id = clientId
            };
            clients.Setup(c => c.fetchClientById(It.IsAny<Guid>())).Returns(client);

            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            User user = new User("AccountantX", 1, 0, 200, "", userDistrictId);
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(user);

            managerService.Interventions = interventions.Object;
            managerService.Clients = clients.Object;
            managerService.Users = users.Object;
            managerService.Districts = districts.Object;

            return intervention.Id;
        }
    }
}
