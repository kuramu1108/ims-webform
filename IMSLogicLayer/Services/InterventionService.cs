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
            return Interventions.fetchInterventionsByCreator(creatorId).Cast<Intervention>();
        }

        public Intervention getInterventionsById(Guid interventionId)
        {
            return (Intervention)Interventions.fetchInterventionsById(interventionId);
        }

        public IEnumerable<Intervention> getListofProposedInterventions()
        {
            return Interventions.fetchInterventionsByState((int)InterventionState.Proposed).Cast<Intervention>();
        }

        public bool updateInterventionDetail(Guid interventionId, string comments, int remainLife)
        {
            Intervention intervention = getInterventionsById(interventionId);
            intervention.Comments = comments;
            intervention.LifeRemaining = remainLife;

            return Interventions.update(intervention);
        }

        public bool updateInterventionLastVisitDate(Guid interventionId, DateTime lastVisitDate)
        {
            Intervention intervention = getInterventionsById(interventionId);
            intervention.DateRecentVisit = lastVisitDate;
            return Interventions.update(intervention);

        }

        public bool updateInterventionState(Guid interventionId, InterventionState state)
        {
            Intervention intervention = getInterventionsById(interventionId);
            intervention.State = state;
            return Interventions.update(intervention);
        }
    }
}
