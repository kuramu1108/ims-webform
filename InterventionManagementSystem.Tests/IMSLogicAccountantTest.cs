using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMSLogicLayer.ServiceInterfaces;

namespace InterventionManagementSystem.Tests
{
    [TestClass]
    public class IMSLogicAccountantTest
    {
        private IAccountantService accountantService;
        private const string OLDPWD = "12345678";
        private const string NEWPWD = "87654321";

        [TestInitialize]
        public void setUp()
        {
            //accountant = new Accountant(1, "po-hao chen", "pohao1108", Support.convertToSS(OLDPWD), Common.UserType.Accountant);
        }

        [TestMethod]
        public void IMSLogicAccountant_ChangePassword_Success()
        {
            //Assert.IsTrue(accountant.changePassword(accountant.Password, Support.convertToSS(NEWPWD)));
        }

        [TestMethod]
        public void IMSLogicAccountant_ChangePassword_SamePassword_Fail()
        {
            //Assert.IsFalse(accountant.changePassword(Support.convertToSS(OLDPWD + "1"), Support.convertToSS(NEWPWD)));

        }

        [TestMethod]
        public void IMSLogicAccountant_ChangePassword_PasswordChanged()
        {
            //accountant.changePassword(Support.convertToSS(OLDPWD), Support.convertToSS(NEWPWD));
            //Assert.AreEqual(accountant.Password, Support.convertToSS(NEWPWD));
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
