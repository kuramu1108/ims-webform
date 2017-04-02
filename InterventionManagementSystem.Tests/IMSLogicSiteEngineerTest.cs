using IMSLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterventionManagementSystem.Tests
{
    [TestClass]
    class IMSLogicSiteEngineerTest
    {
        private SiteEngineer siteEngineer;

        [TestInitialize]
        public void setUp()
        {
            siteEngineer = new SiteEngineer(3, "Ben", "Benjamin", Support.convertToSS("55555555"), Common.UserType.SiteEngineer, Common.Districts.RuralNewSouthWales, 7, 200);
        }
    }


}
