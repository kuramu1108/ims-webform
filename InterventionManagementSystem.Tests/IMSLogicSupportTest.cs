using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using IMSLogic;

namespace InterventionManagementSystem.Tests
{
    [TestClass]
    class IMSLogicSupportTest
    {
        [TestMethod]
        public void IMSLogicSupport_ConvertStringToSecurityString()
        {
            string str = "abcdefg";
            SecureString ss = Support.convertToSS(str);
            Assert.AreEqual(str, ss.ToString());
        }
    }
}
