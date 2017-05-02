using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataAccessObjects;
using IMSLogicLayer.Models;
using IMSLogicLayer.ServiceInterfaces;
using IMSLogicLayer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterventionManagementSystem.Tests
{
    /// <summary>
    /// Unit testing class for EngineerService
    /// </summary>
    [TestClass]
    public class IMSLogicEngineerServiceTest
    {
        private EngineerService engineerService;
        private Guid engineer_a_ID = new Guid("9D2B0228-4444-4C23-8B49-01A698857709");
        private Guid engineer_b_ID = new Guid("11111111-4D0D-4C23-8B49-01A698857709");

        /// <summary>
        /// initlizing the required setup for testing
        /// initlize the engineerService with empty connection string
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            engineerService = new EngineerService("");
        }

        /// <summary>
        /// test target: createClient(clientname, clientlocation)
        /// create a client in the engineer's district
        /// the function should return a new created client object which is assigned to the same district as the engineer
        /// </summary>
        [TestMethod]
        public void IMSLogicSiteEngineer_CreateClientinDistrict()
        {
            //Mock ClientDataAccess create client return the same client
            District dis = new District("Bankstown");
            Guid district_id = dis.Id;
            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            Client new_client = new Client("Sam","Hornsby", district_id);
            clients.Setup(c => c.createClient(It.IsAny<Client>())).Returns(new_client);
            engineerService.Clients = clients.Object;

            //Mock Create Enegineer Detail DataAccess fetchUserByIdentityId will return that user
            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            User engineerDetail = new User("Ben", 3, 7, 200, Guid.NewGuid().ToString(), district_id);
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(engineerDetail);
            engineerService.Users = users.Object;

            //Mock DistrictDataAccess fetch the same district by any id
            Mock<IDistrictDataAccess> districts = new Mock<IDistrictDataAccess>();
            districts.Setup(u => u.fetchDistrictById(It.IsAny<Guid>())).Returns(dis);
            engineerService.Districts = districts.Object;


            //create new client;
            Client client = engineerService.createClient(new_client.Name,new_client.Location);

            //check client creation success
            Assert.IsNotNull(client);
            //check client district is the same as the engineer district
            Assert.AreEqual(client.DistrictId,district_id);
        }

        /// <summary>
        /// test target: getClients()
        /// the function should return a list of clients reside in the same district as the engineer
        /// </summary>
        [TestMethod]
        public void IMSLogicSiteEngineer_GetListofClientsinDistrict()
        {
            Guid districtID = new Guid();
            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            List<Client> clientList = new List<Client>();
            clientList.Add(new Client("Richard", "Sydney", districtID));
            clientList.Add(new Client("Po", "Sydney", districtID));
            clientList.Add(new Client("Welly", "Sydney", districtID));
            clients.Setup(c => c.fetchClientsByDistrictId(It.IsAny<Guid>())).Returns(clientList);

            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            User engineerDetail = new User("Ben", 3, 7, 200, Guid.NewGuid().ToString(), districtID);
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(engineerDetail);
            engineerService.Users = users.Object;

            Mock<IDistrictDataAccess> districts = new Mock<IDistrictDataAccess>();
            District district = new District("")
            {
                Id = districtID
            };
            districts.Setup(d => d.fetchDistrictById(It.IsAny<Guid>())).Returns(district);

            engineerService.Clients = clients.Object;
            engineerService.Users = users.Object;
            engineerService.Districts = districts.Object;

            List<Client> resultList = engineerService.getClients().ToList<Client>();

            foreach (Client c in resultList)
            {
                Assert.AreEqual(c.DistrictId, districtID);
            }
        }

        /// <summary>
        /// test target: getClientById(clientid)
        /// this function should return a client object fetch from database with the matching guid
        /// </summary>
        [TestMethod]
        public void IMSLogicSiteEngineer_GetClientDetail()
        {
            Guid guid = new Guid();
            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            Client clientDetail = new Client("PO", "Hornsby", new Guid());
            clientDetail.Id = guid;
            clients.Setup(c => c.fetchClientById(It.IsAny<Guid>())).Returns(clientDetail);
            engineerService.Clients = clients.Object;

            IMSDBLayer.DataModels.Client client = engineerService.getClientById(guid);

            Assert.IsNotNull(client);
            Assert.AreEqual(guid, client.Id);
        }

        /// <summary>
        /// test target: approveAnIntervention(interventionID)
        /// this function should approve an interevention only when the requirements are met
        ///  - sufficient authorised cost for engineer
        ///  - sufficient authorised hour for engineer
        ///  - intervention and enginner are in the same district
        ///  - intervention is created by the engineer
        ///  
        /// this test case test the success scenario and the intervention is approved
        /// </summary>
        [TestMethod]
        public void IMSLogicSiteEngineer_ApproveIntervention_Success()
        {
            Intervention intervention = new Intervention(5, 20, 5, "", IMSLogicLayer.Enums.InterventionState.Proposed, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(),createdBy: engineer_a_ID, approvedBy: new Guid());
            InterventionType interventionType = new InterventionType("toilet", 5, 20);
            District district = new District("Asquith")
            {
                Id = new Guid()
            };
            Client client = new Client("", "", new Guid())
            {
                DistrictId = district.Id,
            };
            User engineer = new User("me", 1, 500,  20000, "", new Guid())
            {
                DistrictId = district.Id,
                Id = engineer_a_ID
            };

            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            interventions.Setup(i => i.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);

            Mock<IInterventionTypeDataAccess> interventionTypes = new Mock<IInterventionTypeDataAccess>();
            interventionTypes.Setup(its => its.fetchInterventionTypesById(It.IsAny<Guid>())).Returns(interventionType);

            Mock<IDistrictDataAccess> districts = new Mock<IDistrictDataAccess>();
            districts.Setup(d => d.fetchDistrictById(It.IsAny<Guid>())).Returns(district);

            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            clients.Setup(c => c.fetchClientById(It.IsAny<Guid>())).Returns(client);

            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(engineer);
            users.Setup(u => u.fetchUserById(It.IsAny<Guid>())).Returns(engineer);

            Mock<IInterventionService> interventionService = new Mock<IInterventionService>();
            interventionService.Setup(i => i.updateInterventionState(It.IsAny<Guid>(), IMSLogicLayer.Enums.InterventionState.Approved, engineer.Id)).Returns(true);
            interventionService.Setup(i => i.updateIntervetionApprovedBy(It.IsAny<Guid>(), It.IsAny<User>())).Returns(true);

            engineerService.Interventions = interventions.Object;
            engineerService.InterventionTypes = interventionTypes.Object;
            engineerService.Districts = districts.Object;
            engineerService.Clients = clients.Object;
            engineerService.Users = users.Object;
            engineerService.InterventionService = interventionService.Object;

            Assert.IsTrue(engineerService.approveAnIntervention(intervention.Id));
        }

        /// <summary>
        /// test target: getInterventionListByCreator(engineerid)
        /// the function should return a list of interventions with the creator id match with the engineer's id
        /// </summary>
        [TestMethod]
        public void IMSLogicSiteEngineer_GetListofInterventionCreated()
        {
            //Mock InterventionDataAccess fetch the same interventions list by any creator 
            Guid districtID = new Guid();
            Guid identityID = engineer_a_ID;
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            List<Intervention> interventionList = new List<Intervention>
            {
                new Intervention(5, 2, 70, "", IMSLogicLayer.Enums.InterventionState.Proposed, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), identityID, new Guid()),
                new Intervention(3, 5, 50, "", IMSLogicLayer.Enums.InterventionState.Approved, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), identityID, new Guid()),
                new Intervention(6, 9, 80, "", IMSLogicLayer.Enums.InterventionState.Proposed, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), identityID, new Guid())
            };
            interventions.Setup(c => c.fetchInterventionsByCreator(It.IsAny<Guid>())).Returns(interventionList);
            engineerService.Interventions = interventions.Object;

            //Mock UserDataAccess fetch the same engineer by any id 
            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            User engineerDetail = new User("Roy", 3, 10,1000, identityID.ToString(), districtID);
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(engineerDetail);
            engineerService.Users = users.Object;
            //Test if every intervention which created by the engineer has the same creator id as the engineer's  
            foreach (var intervention in engineerService.getInterventionListByCreator(identityID).ToList()) {
                Assert.AreEqual(identityID, intervention.CreatedBy);
            }
        }

        /// <summary>
        /// test target: updateInterventionState(interventionId, interventionstate)
        /// this function should update the state of the given intervention and return the result
        /// the creator of the intervention should be the engineer otherwise the operation would be rejected
        /// 
        /// this test case tests the failed scenario where the intervention is not created by the engineer
        /// </summary>
        [TestMethod]
        public void IMSLogicSiteEngineer_UpdateStateofIntervention_ByDifferentUser()
        {
            Guid user_id = engineer_a_ID;
            District dis = new District("Bankstown");
            //Mock InterventionDataAccess fetch the same intervention by any id 
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            Intervention intervention = new Intervention(5, 2, 70, "", IMSLogicLayer.Enums.InterventionState.Proposed, 
                new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), user_id, new Guid());
            intervention.District = dis;
            interventions.Setup(c => c.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);
            engineerService.Interventions = interventions.Object;
    
            //Mock UserDataAccess fetch the same engineer by any id
            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();       
            User engineerDetail = new User("Roy", 3, 10, 1000, new Guid().ToString(), new Guid());
            engineerDetail.Id = engineer_b_ID;
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(engineerDetail);
            engineerService.Users = users.Object;

            //Mock DistrictDataAccess fetch the same district by any id
            Mock<IDistrictDataAccess> districts= new Mock<IDistrictDataAccess>();
            districts.Setup(u => u.fetchDistrictById(It.IsAny<Guid>())).Returns(dis);
            engineerService.Districts = districts.Object;
            Mock<IInterventionService> interventionService = new Mock<IInterventionService>();
            interventionService.Setup(i => i.updateInterventionState(It.IsAny<Guid>(), It.IsAny<IMSLogicLayer.Enums.InterventionState>())).Returns(false);
            engineerService.InterventionService = interventionService.Object;

            Assert.IsFalse(engineerService.updateInterventionState(intervention.Id, IMSLogicLayer.Enums.InterventionState.Completed));
        }

        /// <summary>
        /// test target: updateInterventionState(interventionId, interventionstate)
        /// this function should update the state of the given intervention and return the result
        /// the creator of the intervention should be the engineer otherwise the operation would be rejected
        /// 
        /// this test case tests the success scenario where the intervention is created by the engineer
        /// </summary>
        [TestMethod]
        public void IMSLogicSiteEngineer_UpdateStateofIntervention_CreatedByUser()
        {
            Guid interventionId = new Guid();
            Guid districtId = new Guid();
            Guid creatorId = new Guid();
            //Mock InterventionDataAccess fetch the same intervention by any id 
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            Intervention intervention=new Intervention(5, 2, 70, "", IMSLogicLayer.Enums.InterventionState.Proposed, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), creatorId, new Guid());
            intervention.Id = interventionId;
            interventions.Setup(c => c.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);          
            engineerService.Interventions = interventions.Object;

            //Mock UserDataAccess fetch the same engineer by any id
            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            User engineerDetail = new User("Roy", 3, 10, 1000, new Guid().ToString(), districtId);
            engineerDetail.Id = creatorId;
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(engineerDetail);
            engineerService.Users = users.Object;

            Mock<IDistrictDataAccess> districts = new Mock<IDistrictDataAccess>();
            District dic = new District("Rockdale");
            dic.Id = districtId;
            districts.Setup(u => u.fetchDistrictById(It.IsAny<Guid>())).Returns(dic);
            engineerService.Districts = districts.Object;

            Mock<IInterventionService> interventionService = new Mock<IInterventionService>();
            interventionService.Setup(i => i.updateInterventionState(It.IsAny<Guid>(), IMSLogicLayer.Enums.InterventionState.Completed)).Returns(true);
            engineerService.InterventionService = interventionService.Object;

            Assert.IsTrue(engineerService.updateInterventionState(interventionId, IMSLogicLayer.Enums.InterventionState.Completed));          
        }
    }
}
