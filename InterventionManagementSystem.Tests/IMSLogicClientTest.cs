using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMSLogic;
using IMSDBLayer;
using IMSDBLayer.DataModels;

namespace InterventionManagementSystem2.Tests
{
    [TestClass]
    public class IMSLogicClientTest
    {

        private Client client;
        [TestInitialize]
        public void SetUp()
        {
            //client = new Client();
            //client.clientDM.District = Common.Districts.UrbanIndonesia;
            //client.clientDM.Name = "john Smith";
            //client.clientDM.Location = "123 Joke St";
            
        }
        [TestMethod]
        public void IMSLogicClient_Constructor_ValueCorrect()
        {
            //Client client2 = new Client(1,"john Smith", "123 Joke St", Common.Districts.UrbanIndonesia);
            //Assert.AreEqual(client2.clientDM.Name, "john Smith");
            //Assert.AreEqual(client2.clientDM.District, Common.Districts.UrbanIndonesia);
            //Assert.AreEqual(client2.clientDM.Location, "123 Joke St");

        }
        [TestMethod]
        public void IMSLogicClient_PropertyDistricts_ValueCorrect()
        {
            //Assert.AreEqual(client.clientDM.District, Common.Districts.UrbanIndonesia);
        }
        [TestMethod]
        public void IMSLogicClient_PropertyName_ValueCorrect()
        {
            //Assert.AreEqual(client.clientDM.Name, "john Smith");
        }
        [TestMethod]
        public void IMSLogicClient_PropertyLocation_ValueCorrect()
        {
            //Assert.AreEqual(client.clientDM.Location, "123 Joke St");
        }
    }
}
