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
        private Manager manager;
        private SiteEngineer siteEngineer;

        [TestInitialize]
        public void setUp()
        {
            accountant = new Accountant(1, "po-hao chen", "pohao1108", Support.convertToSS("12345678"), Common.UserType.Accountant);
            manager = new Manager(2, "Luke", "luke1234", Support.convertToSS("12345678"), Common.UserType.Manager, Common.Districts.Sydney, 10, 500);
            siteEngineer = new SiteEngineer(3, "Ben", "Benjamin", Support.convertToSS("55555555"), Common.UserType.SiteEngineer, Common.Districts.RuralNewSouthWales, 7, 200);
        }

        [TestMethod]
        public void IMSLogicUser_Constructor_ValueCorrect()
        {

        }

        [TestMethod]
        public void IMSLogicUser_Accountant_GenerateReport()
        {

        }

        [TestMethod]
        public void IMSLogicUser_ChangePassword_Success()
        {

        }

        [TestMethod]
        public void IMSLogicUser_ChangePassword_SamePassword()
        {

        }

        [TestMethod]
        public void 
    }


}
