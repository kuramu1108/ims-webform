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
    /// <summary>
    /// Unit testing class for ManagerService
    /// </summary>
    [TestClass]
    public class IMSLogicManagerServiceTest
    {
        private ManagerService managerService;
        private Guid District_SydId = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709");
        private Guid District_NswId = new Guid("ABCD0228-4D0D-4C23-8B49-01A698857709");

        /// <summary>
        /// initlizing the required setup for testing
        /// initlize the managerService with empty connection string
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            managerService = new ManagerService("");
        }

        /// <summary>
        /// test target: GetInterventionsByState(InterventionState.Approved)
        /// the function should return a list of interventions
        /// success of the testmethod required all interventions in the return list to have an approved state
        /// </summary>
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

        /// <summary>
        /// test target: ApproveAnIntervention(interventionId)
        /// the function would approve an intervetion with given interventionid
        /// the district of the manager and the intervention should match in order to process the approval
        /// the Authorisedcost of the manager should be more than intervention cost in order to process the approval
        /// the Authorisedhour of the manager should be more than intervention hour in order to process the approval
        /// 
        /// the test method test the scenario where all requirements are match thus successfully approved
        /// </summary>
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

        /// <summary>
        /// test target: ApproveAnIntervention(interventionId)
        /// the function would approve an intervetion with given interventionid
        /// the district of the manager and the intervention should match in order to process the approval
        /// 
        /// the test method test the scenario where district of the manager and intervention are different thus failed approval
        /// </summary>
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

        /// <summary>
        /// test target: ApproveAnIntervention(interventionId)
        /// the function would approve an intervetion with given interventionid
        /// the Authorisedcost of the manager should be more than intervention cost in order to process the approval
        /// 
        /// the test method test the scenario where the Authorisedcost of the manager should be less than intervention cost
        /// thus failed approval
        /// </summary>
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

        /// <summary>
        /// test target: ApproveAnIntervention(interventionId)
        /// the function would approve an intervetion with given interventionid
        /// the Authorisedhour of the manager should be more than intervention hour in order to process the approval
        /// 
        /// the test method test the scenario where the Authorisedhour of the manager should be less than intervention hour
        /// thus failed approval
        /// </summary>
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

        /// <summary>
        /// test target: UpdateInterventionState(interventionId, InterventionState)
        /// the function would update the state of the given intervention
        /// the district of the manager should match with the intervention district in order to process the approval
        /// 
        /// this test method test the scenario where manager and intervetion are in the same district
        /// </summary>
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

        /// <summary>
        /// test target: UpdateInterventionState(interventionId, InterventionState)
        /// the function would update the state of the given intervention
        /// the district of the manager should match with the intervention district in order to process the approval
        /// 
        /// this test method test the scenario where manager and intervetion are in the different districts, thus failed the approval
        /// </summary>
        [TestMethod]
        public void IMSLogicManager_UpdateInterventionState_Failed_DifferentDistricts()
        {
            Guid clientDistrictId = District_SydId;
            Guid userDistrictId = District_NswId;

            Guid interventionId = IMSLogicManager_UpdateInterventionTests_Setup(clientDistrictId, userDistrictId);

            Assert.IsFalse(managerService.UpdateInterventionState(interventionId, IMSLogicLayer.Enums.InterventionState.Approved));
        }

        /// <summary>
        /// test target: UpdateInterventionApprovedBy(interventionid, userid)
        /// the function would update the approvedby of the given intervention
        /// the district of the manager should match with the intervention district in order to process the approval
        /// 
        /// this test method test the scenario where manager and intervetion are in the same district
        /// </summary>
        [TestMethod]
        public void IMSLogicManager_UpdateInterventionApprovedBy_Success()
        {
            Guid clientDistrictId = District_SydId;
            Guid userDistrictId = clientDistrictId;

            Guid interventionId = IMSLogicManager_UpdateInterventionTests_Setup(clientDistrictId, userDistrictId);

            Mock<IInterventionService> interventionService = new Mock<IInterventionService>();
            interventionService.Setup(x => x.updateIntervetionApprovedBy(It.IsAny<Guid>(), It.IsAny<User>())).Returns(true);

            managerService.InterventionService = interventionService.Object;

            Assert.IsTrue(managerService.UpdateInterventionApproveBy(interventionId, new Guid()));
        }

        /// <summary>
        /// test target: UpdateInterventionApprovedBy(interventionid, userid)
        /// the function would update the approvedby of the given intervention
        /// the district of the manager should match with the intervention district in order to process the approval
        /// 
        /// this test method test the scenario where manager and intervetion are in the different districts, thus failed the approval
        /// </summary>
        [TestMethod]
        public void IMSLogicManager_UpdateInterventionApprovedBy_Failed_DifferentDistricts()
        {
            Guid clientDistrictId = District_SydId;
            Guid userDistrictId = District_NswId;

            Guid interventionId = IMSLogicManager_UpdateInterventionTests_Setup(clientDistrictId, userDistrictId);

            Assert.IsFalse(managerService.UpdateInterventionApproveBy(interventionId, new Guid()));
        }

        /// <summary>
        /// the supporting function that setup the requirements for ApproveIntervention related tests
        /// </summary>
        /// <returns>the guid of the generated intervention</returns>
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

        /// <summary>
        /// the supporting function that setup the requirements for UPdateIntervention related tests
        /// </summary>
        /// <param name="clientDistrictId">the guid of the client's district</param>
        /// <param name="userDistrictId">the guid of the manager's district</param>
        /// <returns>the guid of the generated intervention</returns>
        private Guid IMSLogicManager_UpdateInterventionTests_Setup(Guid clientDistrictId, Guid userDistrictId)
        {
            Guid clientId = new Guid();

            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            IMSDBLayer.DataModels.Intervention intervention = new IMSDBLayer.DataModels.Intervention()
            {
                ClientId = clientId
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
            users.Setup(u => u.fetchUserById(It.IsAny<Guid>())).Returns(user);

            managerService.Interventions = interventions.Object;
            managerService.Clients = clients.Object;
            managerService.Users = users.Object;
            managerService.Districts = districts.Object;

            return intervention.Id;
        }
    }
}
