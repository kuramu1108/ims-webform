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
    /// <summary>
    /// Unit testing class for InterventionService
    /// </summary>
    [TestClass]
    public class IMSLogicInterventionServiceTest
    {
        private InterventionService interventionService;
        private Intervention intervention;

        /// <summary>
        /// initlizing the required setup for testing
        /// initlize the interventionService with empty connection string
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            interventionService = new InterventionService("");
        }

        /// <summary>
        /// test target: updateInterventionState(interventionid, interventionstate)
        /// the function should update the given intervention to the given interventionstate
        /// this test case test the failed scenario where trying to update a Completed intervention
        /// </summary>
        [TestMethod]
        public void IMSLogicIntervention_UpdateInterventionState_CompletedIntervention()
        {
            intervention = new Intervention(10, 4, 4, "", IMSLogicLayer.Enums.InterventionState.Completed, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid());
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            interventions.Setup(i => i.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);
            interventionService.Interventions = interventions.Object;

            bool result = interventionService.updateInterventionState(intervention.Id, IMSLogicLayer.Enums.InterventionState.Approved);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// test target: updateInterventionState(interventionid, interventionstate)
        /// the function should update the given intervention to the given interventionstate
        /// this test case test the failed scenario where trying to update a Cancelled intervention
        /// </summary>
        [TestMethod]
        public void IMSLogicIntervention_UpdateInterventionState_CancelledIntervention()
        {
            intervention = new Intervention(10, 4, 4, "", IMSLogicLayer.Enums.InterventionState.Cancelled, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid());
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            interventions.Setup(i => i.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);
            interventionService.Interventions = interventions.Object;

            bool result = interventionService.updateInterventionState(intervention.Id, IMSLogicLayer.Enums.InterventionState.Approved);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// test target: updateInterventionState(interventionid, interventionstate)
        /// the function should update the given intervention to the given interventionstate
        /// this test case test the failed scenario where trying to update a Approved intervention to Proposed or Approved
        /// </summary>
        [TestMethod]
        public void IMSLogicIntervention_UpdateInterventionState_ApprovedIntervention_To_ProposedOrApproved()
        {
            intervention = new Intervention(10, 4, 4, "", IMSLogicLayer.Enums.InterventionState.Approved, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid());
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            interventions.Setup(i => i.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);
            interventionService.Interventions = interventions.Object;

            bool toApprovedresult = interventionService.updateInterventionState(intervention.Id, IMSLogicLayer.Enums.InterventionState.Approved);
            bool toProposedresult = interventionService.updateInterventionState(intervention.Id, IMSLogicLayer.Enums.InterventionState.Proposed);

            Assert.IsFalse(toApprovedresult);
            Assert.IsFalse(toProposedresult);
        }

        /// <summary>
        /// test target: updateInterventionState(interventionid, interventionstate)
        /// the function should update the given intervention to the given interventionstate
        /// this test case test the success scenario where trying to update a Approved intervention to Completed or Cancelled
        /// </summary>
        [TestMethod]
        public void IMSLogicIntervention_UpdateInterventionState_ApprovedIntervention_To_CompletedOrCancelled()
        {
            intervention = new Intervention(10, 4, 4, "", IMSLogicLayer.Enums.InterventionState.Approved, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid());
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            interventions.Setup(i => i.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);
            interventions.Setup(i => i.update(It.IsAny<Intervention>())).Returns(true);
            interventionService.Interventions = interventions.Object;

            bool toCompletedresult = interventionService.updateInterventionState(intervention.Id, IMSLogicLayer.Enums.InterventionState.Completed);
            bool toCancelledresult = interventionService.updateInterventionState(intervention.Id, IMSLogicLayer.Enums.InterventionState.Cancelled);

            Assert.IsTrue(toCompletedresult);
            Assert.IsTrue(toCancelledresult);
        }

        /// <summary>
        /// test target: updateInterventionState(interventionid, interventionstate)
        /// the function should update the given intervention to the given interventionstate
        /// this test case test the failed scenario where trying to update a Proposed intervention to Completed
        /// </summary>
        [TestMethod]
        public void IMSLogicIntervention_UpdateInterventionState_ProposedIntervention_To_Completed()
        {
            intervention = new Intervention(10, 4, 4, "", IMSLogicLayer.Enums.InterventionState.Proposed, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid());
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            interventions.Setup(i => i.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);
            interventionService.Interventions = interventions.Object;

            bool result = interventionService.updateInterventionState(intervention.Id, IMSLogicLayer.Enums.InterventionState.Completed);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// test target: updateInterventionState(interventionid, interventionstate)
        /// the function should update the given intervention to the given interventionstate
        /// this test case test the success scenario where trying to update a Proposed intervention to any state other than Completed
        /// </summary>
        [TestMethod]
        public void IMSLogicIntervention_UpdateInterventionState_ProposedIntervention()
        {
            intervention = new Intervention(10, 4, 4, "", IMSLogicLayer.Enums.InterventionState.Proposed, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid());
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            interventions.Setup(i => i.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);
            interventions.Setup(i => i.update(It.IsAny<Intervention>())).Returns(true);

            interventionService.Interventions = interventions.Object;

            bool result = interventionService.updateInterventionState(intervention.Id, IMSLogicLayer.Enums.InterventionState.Approved);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// test target: updateInterventionDetail()
        /// the function should update the detail of the given intervention
        /// the function should return true if the operation is successed
        /// </summary>
        [TestMethod]
        public void IMSLogicIntervention_UpdateInterventionDetail()
        {
            string comment = "some comment";
            int lifeRemaining = 50;
            intervention = new Intervention(10, 4, lifeRemaining, comment, IMSLogicLayer.Enums.InterventionState.Approved, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid());
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            interventions.Setup(i => i.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);
            interventions.Setup(i => i.update(It.IsAny<Intervention>())).Returns(true);
            interventionService.Interventions = interventions.Object;

            bool result = interventionService.updateInterventionDetail(intervention.Id, comment, lifeRemaining, new DateTime());

            Assert.IsTrue(result);
        }

        /// <summary>
        /// test target: updateInterventionLastVisitDate()
        /// the function should update the lastvisitdate of the given intervention
        /// the function should return true if the operation is successed
        /// </summary>
        [TestMethod]
        public void IMSLogicIntervention_UpdateInterventionLastVisitDate()
        {
            intervention = new Intervention(10, 4, 40, "", IMSLogicLayer.Enums.InterventionState.Approved, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid());
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            interventions.Setup(i => i.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);
            interventions.Setup(i => i.update(It.IsAny<Intervention>())).Returns(true);
            interventionService.Interventions = interventions.Object;

            bool result = interventionService.updateInterventionLastVisitDate(intervention.Id, new DateTime());

            Assert.IsTrue(result);
        }

        /// <summary>
        /// test target: updateInterventionApprovedBy()
        /// the function should update the ApprovedBy of the given intervention
        /// the function should return true if the operation is successed
        /// </summary>
        [TestMethod]
        public void IMSLogicIntervention_UpdateInterventionApprovedBy()
        {
            intervention = new Intervention(10, 4, 40, "", IMSLogicLayer.Enums.InterventionState.Approved, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid());
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            interventions.Setup(i => i.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);
            interventions.Setup(i => i.update(It.IsAny<Intervention>())).Returns(true);
            interventionService.Interventions = interventions.Object;

            bool result = interventionService.updateIntervetionApprovedBy(intervention.Id, new User());

            Assert.IsTrue(result);
        }
    }
}
