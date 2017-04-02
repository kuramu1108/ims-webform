using System;
using IMSLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterventionManagementSystem.Tests
{
    [TestClass]
    public class IMSLogicAccountantTest
    {
        private Accountant accountant;

        [TestInitialize]
        public void setUp()
        {
            accountant = new Accountant(1, "po-hao chen", "pohao1108", Support.convertToSS("12345678"), Common.UserType.Accountant);
        }

        //[TestMethod]
        //public 
    }
}
