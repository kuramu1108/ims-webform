using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMSLogic;

namespace InterventionManagementSystem.Tests
{
    [TestClass]
    public class IMSLogicCommonTest
    {
        [TestMethod]
        public void IMSLogicCommon_EnumDistricts_ValueCorrect()
        {
            int x = (int)IMSLogic.Common.Districts.UrbanIndonesia;
            Assert.AreEqual(x, 1);
        }
        [TestMethod]
        public void IMSLogicCommon_EnumUserType_ValueCorrect()
        {
            int x = (int)IMSLogic.Common.UserType.Manager;
            Assert.AreEqual(x, 2);
        }
        [TestMethod]
        public void IMSLogicCommon_EnumInterventionState_ValueCorrect()
        {
            int x = (int)IMSLogic.Common.InterventionState.Cancelled;
            Assert.AreEqual(x, 4);
        }
    }
}
