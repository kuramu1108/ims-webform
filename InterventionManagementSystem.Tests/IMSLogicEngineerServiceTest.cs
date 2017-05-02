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
    [TestClass]
    public class IMSLogicEngineerServiceTest
    {
        private EngineerService engineerService;
  
        [TestInitialize]
        public void setUp()
        {
            
            engineerService = new EngineerService("");
          

        }



        [TestMethod]
        public void IMSLogicSiteEngineer_CreateClientinDistrict()
        {
            //Mock ClientDataAccess create client return the same client
            District dis = new District("Bankstown");
            Guid distric_id = dis.Id;
            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            Client new_client = new Client("Sam","Hornsby", distric_id);
            clients.Setup(c => c.createClient(It.IsAny<Client>())).Returns(new_client);
            engineerService.Clients = clients.Object;

            //Mock Create Enegineer Detail DataAccess fetchUserByIdentityId will return that user
            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            User engineerDetail = new User("Ben", 3, 7, 200, Guid.NewGuid().ToString(), distric_id);
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
            Assert.AreEqual(client.Id,new_client.Id );
        }

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


        }

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

        [TestMethod]
        public void IMSLogicSiteEngineer_CreateInterventionforClient()
        {

            //Mock ClientDataAccess create client return the same client
            District dis = new District("Bankstown");
            Guid guid = new Guid();
            Client client = new Client("Jimmy", "Bondi", new Guid());
            client.Id = guid;
            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            clients.Setup(c => c.fetchClientById(It.IsAny<Guid>())).Returns(client);
            engineerService.Clients = clients.Object;

            //Mock InterventionDataAccess fetch the same intervention by any id 
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            Intervention intervention = new Intervention(5, 2, 70, "", IMSLogicLayer.Enums.InterventionState.Proposed,
            new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), guid, new Guid());
            interventions.Setup(u => u.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);
            interventions.Setup(c => c.create(It.IsAny<Intervention>())).Returns(intervention);
            engineerService.Interventions = interventions.Object;
          

            //Mock UserDataAccess fetch the same engineer by any id 
            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            User engineerDetail = new User("Roy", 3, 10, 1000,new Guid().ToString(),new Guid());
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(engineerDetail);
            engineerService.Users = users.Object;


            //Mock DistrictDataAccess fetch the same district by any id
            Mock<IDistrictDataAccess> districts = new Mock<IDistrictDataAccess>();
            districts.Setup(u => u.fetchDistrictById(It.IsAny<Guid>())).Returns(dis);
            engineerService.Districts = districts.Object;

            //Mock InterventionTypeDataAccess fetch the same interventiontype by any id
            Mock<IInterventionTypeDataAccess> interventiontype = new Mock<IInterventionTypeDataAccess>();
            InterventionType intervention_type = new InterventionType("“Hepatitis Avoidance Training", 2, 100);
            interventiontype.Setup(c => c.fetchInterventionTypesById(It.IsAny<Guid>())).Returns(intervention_type);
            engineerService.InterventionTypes = interventiontype.Object;

            Assert.IsNotNull(engineerService.createIntervention(intervention));
         
        }

        [TestMethod]
        public void IMSLogicSiteEngineer_GetListofInterventionCreated()
        {
            //Mock InterventionDataAccess fetch the same interventions list by any creator 
            Guid districtID = new Guid();
            Guid identityID = new Guid();
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            List<Intervention> interventionList = new List<Intervention>();
            interventionList.Add(new Intervention(5, 2, 70, "", IMSLogicLayer.Enums.InterventionState.Proposed, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), identityID, new Guid()));
            interventionList.Add(new Intervention(3, 5, 50, "", IMSLogicLayer.Enums.InterventionState.Approved, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), identityID, new Guid()));
            interventionList.Add(new Intervention(6, 9, 80, "", IMSLogicLayer.Enums.InterventionState.Proposed, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), identityID, new Guid()));
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
        [TestMethod]
        public void IMSLogicSiteEngineer_UpdateStateofIntervention_ByDifferentUser()
        {
            Guid user_id = new Guid();
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
            engineerDetail.Id = user_id;
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

            //engineerService.updateInterventionState(interventionId, IMSLogicLayer.Enums.InterventionState.Completed);

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
            interventionService.Setup(i => i.updateInterventionState(It.IsAny<Guid>(), IMSLogicLayer.Enums.InterventionState.Completed)).Returns(false);
            engineerService.InterventionService = interventionService.Object;


            Assert.IsFalse(engineerService.updateInterventionState(interventionId, IMSLogicLayer.Enums.InterventionState.Completed));
          
        }
    }


}
