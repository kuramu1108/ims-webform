using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMSLogic;

namespace InterventionManagementSystem.Tests
{
    [TestClass]
    public class IMSLogicManagerTest
    {
        private Manager manager;

        [TestInitialize]
        public void setUp()
        {
            manager = new Manager(2, "Luke", "luke1234", Support.convertToSS("12345678"), Common.UserType.Manager, Common.Districts.Sydney, 10, 500);
        }
    }
}
