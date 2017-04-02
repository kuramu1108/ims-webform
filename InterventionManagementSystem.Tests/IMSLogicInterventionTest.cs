using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMSLogic;

namespace InterventionManagementSystem.Tests {
    [TestClass]
    public class IMSLogicInterventionTest
    {
  
        public void IMSLogicIntervention_Constructor_ValueCorrect()
        {
            Intervention intervention = new Intervention(1, HepatitisAvoidanceTraining,
               2, 5, 500,5,"2017/1/5", Common.InterventionType.Approved,"Emergency");  
            Assert.AreEqual(intervention.Comment, "Emergency");
            Assert.AreEqual(intervention.intervention_id,1);
            Assert.AreEqual(intervention.labour_hours, 5);
        }


    }
}

