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
    class IMSLogicInterventionServiceTest
    {
        private InterventionService interventionService;
        private Intervention intervention;

        [TestInitialize]
        public void SetUp()
        {
            interventionService = new InterventionService("");
        }

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

        [TestMethod]
        public void IMSLogicIntervention_UpdateInterventionState_ApprovedIntervention_To_CompletedOrCancelled()
        {
            intervention = new Intervention(10, 4, 4, "", IMSLogicLayer.Enums.InterventionState.Approved, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid());
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            interventions.Setup(i => i.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);
            interventionService.Interventions = interventions.Object;

            bool toCompletedresult = interventionService.updateInterventionState(intervention.Id, IMSLogicLayer.Enums.InterventionState.Completed);
            bool toCancelledresult = interventionService.updateInterventionState(intervention.Id, IMSLogicLayer.Enums.InterventionState.Cancelled);

            Assert.IsTrue(toCompletedresult);
            Assert.IsTrue(toCancelledresult);
        }

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

        [TestMethod]
        public void IMSLogicIntervention_UpdateInterventionState_ProposedIntervention()
        {
            intervention = new Intervention(10, 4, 4, "", IMSLogicLayer.Enums.InterventionState.Proposed, new DateTime(), new DateTime(), new DateTime(), new Guid(), new Guid(), new Guid(), new Guid());
            Mock<IInterventionDataAccess> interventions = new Mock<IInterventionDataAccess>();
            interventions.Setup(i => i.fetchInterventionsById(It.IsAny<Guid>())).Returns(intervention);
            interventionService.Interventions = interventions.Object;

            bool result = interventionService.updateInterventionState(intervention.Id, IMSLogicLayer.Enums.InterventionState.Approved);

            Assert.IsTrue(result);
        }

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

            //bool result = interventionService.updateInterventionDetail(intervention.Id, comment, lifeRemaining);

            Assert.IsTrue(false);
        }

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
