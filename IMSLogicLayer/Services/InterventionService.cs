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

        public IEnumerable<Intervention> getInterventionsByClientId(Guid clientId)
        {
            return Interventions.fetchInterventionsByClientId(clientId).Cast<Intervention>();
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
            if (intervention.State !=InterventionState.Completed && intervention.State!=InterventionState.Cancelled)
            {
                if (intervention.State ==InterventionState.Proposed)
                {
                    if (state==InterventionState.Completed)
                    {
                        return false;
                    }
                    else
                    {
                        intervention.State = state;
                    }
                }else
                {
                    if(state != InterventionState.Proposed && state!=InterventionState.Approved)
                    {
                        intervention.State = state;
                    }else
                    {
                        return false;
                    }
                }
                
            }else
            {
                return false;
            }
            
            return Interventions.update(intervention);
        }

        public bool updateIntervetionApprovedBy(Guid interventionId, User user)
        {
            Intervention intervention = getInterventionsById(interventionId);
            intervention.ApprovedBy = user.IdentityId;
            return Interventions.update(intervention);
        }

        public bool updateInterventionState(Guid interventionId, InterventionState state, Guid identityId)
        {
            if (updateInterventionState(interventionId,state))
            {
                var intervention = getInterventionsById(interventionId);
                intervention.ApprovedBy = identityId;
                return Interventions.update(intervention);
            }else
            {
                return false;
            }
        }

        public IEnumerable<Intervention> getInterventionByApprovedUser(Guid userId)
        {
            return Interventions.fetchInterventionsByApprovedUser(userId).Cast<Intervention>();
        }
    }
}
