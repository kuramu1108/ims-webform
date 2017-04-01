using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMSLogic;

namespace InterventionManagementSystem.Tests
{
    [TestClass]
    public class IMSLogicClientTest
    {

        private Client client;
        [TestInitialize]
        public void SetUp()
        {
            client = new Client();
            client.District = Common.Districts.UrbanIndonesia;
            client.Name = "john Smith";
            client.Location = "123 Joke St";
            
        }
        [TestMethod]
        public void IMSLogicClient_Constructor_ValueCorrect()
        {
            Client client2 = new Client("john Smith", "123 Joke St", Common.Districts.UrbanIndonesia);
            Assert.AreEqual(client2.Name, "john Smith");
            Assert.AreEqual(client2.District, Common.Districts.UrbanIndonesia);
            Assert.AreEqual(client2.Location, "123 Joke St");

        }
        [TestMethod]
        public void IMSLogicClient_PropertyDistricts_ValueCorrect()
        {
            Assert.AreEqual(client.District, Common.Districts.UrbanIndonesia);
        }
        [TestMethod]
        public void IMSLogicClient_PropertyName_ValueCorrect()
        {
            Assert.AreEqual(client.Name, "john Smith");
        }
        [TestMethod]
        public void IMSLogicClient_PropertyLocation_ValueCorrect()
        {
            Assert.AreEqual(client.Location, "123 Joke St");
        }
    }
}
