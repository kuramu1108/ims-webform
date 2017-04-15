using IMSDBLayer.DataAccessInterfaces;
using IMSLogicLayer.Models;
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
            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            Mock<IDistrictDataAccess> districts = new Mock<IDistrictDataAccess>();
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            Mock<IInterventionTypeDataAccess> interventionTypes = new Mock<IInterventionTypeDataAccess>();

            engineerService = new EngineerService("");
            
            engineerService.Clients = clients.Object;
            engineerService.Users = users.Object;
            engineerService.Districts = districts.Object;
            engineerService.Interventions = interventions.Object;
            engineerService.InterventionTypes = interventionTypes.Object;
        }
        
        [TestMethod]
        public void IMSLogicSiteEngineer_CreateClientinDistrict()
        {
            //Mock ClientDataAccess create client return the same client
            Mock<IClientDataAccess> clients = new Mock<IClientDataAccess>();
            clients.Setup(c => c.createClient(It.IsAny<Client>())).Returns<IMSDBLayer.DataModels.Client>(c => c);
            engineerService.Clients = clients.Object;

            //Mock Create Enegineer Detail DataAccess fetchUserByIdentityId will return that user
            Mock<IUserDataAccess> users = new Mock<IUserDataAccess>();
            User engineerDetail = new User("Ben", 3, 7, 200, Guid.NewGuid(), Guid.NewGuid());
            users.Setup(u => u.fetchUserByIdentityId(It.IsAny<Guid>())).Returns(engineerDetail);
            engineerService.Users = users.Object;

            //create new client;
            Client client = engineerService.createClient("Ben", "Titan");

            //check client creation success
            Assert.IsNotNull(client);
            //check client district is the same as the engineer district
            Assert.AreEqual(engineerDetail.DistrictId, client.DistrictId);
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
