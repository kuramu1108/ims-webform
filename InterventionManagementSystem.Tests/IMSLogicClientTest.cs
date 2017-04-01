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
            client.district = Common.Districts.UrbanIndonesia;
            client.name = "john Smith";
            client.location = "123 Joke St";
            
        }
        [TestMethod]
        public void IMSLogicClient_Constructor_ValueCorrect()
        {
            Client client2 = new Client("john Smith", "123 Joke St", Common.Districts.UrbanIndonesia);
            Assert.AreEqual(client2.name, "john Smith");
            Assert.AreEqual(client2.district, Common.Districts.UrbanIndonesia);
            Assert.AreEqual(client2.location, "123 Joke St");

        }
        [TestMethod]
        public void IMSLogicClient_PropertyDistricts_ValueCorrect()
        {
            Assert.AreEqual(client.district, Common.Districts.UrbanIndonesia);
        }
        [TestMethod]
        public void IMSLogicClient_PropertyName_ValueCorrect()
        {
            Assert.AreEqual(client.name, "john Smith");
        }
        [TestMethod]
        public void IMSLogicClient_PropertyLocation_ValueCorrect()
        {
            Assert.AreEqual(client.location, "123 Joke St");
        }
    }
}
