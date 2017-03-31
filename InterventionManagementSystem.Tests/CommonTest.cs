using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMSLogic;

namespace InterventionManagementSystem.Tests
{
    [TestClass]
    public class CommonTest
    {
        [TestMethod]
        public void Common_EnumDistricts_ValueCorrect()
        {
            int x = (int)IMSLogic.Common.Districts.UrbanIndonesia;
            Assert.AreEqual(x, 1);
        }
    }
}
