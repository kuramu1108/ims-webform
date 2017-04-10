using System;
using IMSLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMSDBLayer;

namespace InterventionManagementSystem2.Tests
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

        [TestMethod]
        public void IMSLogicAccountant_ChangePassword_Success()
        {

        }

        [TestMethod]
        public void IMSLogicAccountant_ChangePassword_SamePassword_Fail()
        {

        }

        [TestMethod]
        public void IMSLogicAccountant_GenerateReport_Success()
        {

        }

        [TestMethod]
        public void IMSLogicAccountant_ChangeDistrict_SiteEngineer()
        {

        }

        [TestMethod]
        public void IMSLogicAccountant_ChangeDistrict_Manager()
        {

        }

        [TestMethod]
        public void IMSLogicAccountant_ViewListofSiteEngineerManager()
        {

        }
    }
}
