using IMSLogicLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSLogicLayer.Models;
using IMSLogicLayer.Enums;

namespace IMSLogicLayer.FakeServices
{
    public class FakeManagerService : FakeBaseService, IManagerService
    {
        public FakeManagerService(string connstring) : base(connstring) { }

        public Guid ManagerId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool approveAnIntervention(Guid interventionId)
        {
            FakeInterventionService IS = new FakeInterventionService("");
            return IS.updateInterventionState(new Guid(),InterventionState.Approved);
        }

        public User getDetail()
        {
            return new User("John Smith", 2, 12m, 2000.00m, "22222222-2222-2222-2222-222222222222", new Guid("33333333-3333-3333-3333-3333-333333333333"));
        }

        public Intervention getInterventionById(Guid interventionId)
        {
            FakeInterventionService IS = new FakeInterventionService("");
            return IS.getInterventionsById(interventionId);
        }

        public IEnumerable<Intervention> getListOfProposedIntervention()
        {
            FakeInterventionService IS = new FakeInterventionService("");
            return IS.getListofProposedInterventions();
        }

        public bool updateInterventionApproveBy(Guid interventionId, string name)
        {
            return true;
        }

        public bool updateInterventionApproveBy(Guid interventionId, Guid userId)
        {
            return true;
        }

        public bool updateInterventionState(Guid interventionId, InterventionState state)
        {
            return true;
        }
    }
}
