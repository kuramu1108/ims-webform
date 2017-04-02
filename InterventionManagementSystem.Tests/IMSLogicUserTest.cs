using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMSLogic;
using System.Security;

namespace InterventionManagementSystem.Tests
{
    [TestClass]
    public class IMSLogicUserTest
    {
        private Accountant accountant;

        [TestInitialize]
        public void setUp()
        {
            accountant = new Accountant(1, "po-hao chen", "pohao1108", new SecureString(), Common.UserType.Accountant);

        }

        [TestMethod]
        public void IMSLogicUser_()
        {

        }
    }


}
