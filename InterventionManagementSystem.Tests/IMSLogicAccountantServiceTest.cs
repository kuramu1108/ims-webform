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
        public void SetUp()
        {
            accountantService = new AccountantService("");
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
