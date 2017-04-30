using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMSDBLayer.DataAccessInterfaces;
using IMSLogicLayer.Models;
using IMSLogicLayer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InterventionManagementSystem.Tests
{
    [TestClass]
    public class IMSLogicAccountantServiceTest
    {
        private AccountantService accountantService;

        [TestInitialize]
        public void setUp()
        {
            
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
