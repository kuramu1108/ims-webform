using IMSLogicLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSLogicLayer.Enums;
using IMSLogicLayer.Models;

namespace IMSLogicLayer.Services
{
    public class InterventionService : BaseService, IInterventionService
    {
        public InterventionService(string connstring) : base(connstring)
        {
        }

        public IEnumerable<Intervention> getInterventionsByCreatorId(Guid creatorId)
        {
            throw new NotImplementedException();
        }

        public Intervention getInterventionsById(Guid interventionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Intervention> getListofProposedInterventions()
        {
            throw new NotImplementedException();
        }

        public bool updateInterventionDetail(Guid interventionId, string comments, int remainLife)
        {
            throw new NotImplementedException();
        }

        public bool updateInterventionLastVisitDate(Guid interventionId, DateTime lastVisitDate)
        {
            throw new NotImplementedException();
        }

        public bool updateInterventionState(Guid interventionId, InterventionState state)
        {
            throw new NotImplementedException();
        }
    }
}
