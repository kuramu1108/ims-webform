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
    internal class InterventionService : BaseService, IInterventionService
    {
        public InterventionService(string connstring) : base(connstring)
        {
        }

        public IEnumerable<Intervention> getInterventionsByCreatorId(Guid creatorId)
        {
            return Interventions.fetchInterventionsByCreator(creatorId).Select(c => new Intervention(c)).ToList();
        }

        public Intervention getInterventionsById(Guid interventionId)
        {
            return new Intervention(Interventions.fetchInterventionsById(interventionId));
        }

        public IEnumerable<Intervention> getListofProposedInterventions()
        {
            return Interventions.fetchInterventionsByState((int)InterventionState.Proposed).Select(c => new Intervention(c)).ToList();
        }

        public IEnumerable<Intervention> getInterventionsByClientId(Guid clientId)
        {
            return Interventions.fetchInterventionsByClientId(clientId).Select(c => new Intervention(c)).ToList();
        }

        public bool updateInterventionDetail(Guid interventionId, string comments, int remainLife, DateTime lastVisitDate)
        {
            Intervention intervention = getInterventionsById(interventionId);
            intervention.Comments = comments;
            intervention.LifeRemaining = remainLife;
            intervention.DateRecentVisit = lastVisitDate;

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
            if (intervention.InterventionState !=InterventionState.Completed && intervention.InterventionState!=InterventionState.Cancelled)
            {
                if (intervention.InterventionState ==InterventionState.Proposed)
                {
                    if (state==InterventionState.Completed)
                    {
                        return false;
                    }
                    else
                    {
                        intervention.InterventionState = state;
                    }
                }else //original = Approved
                {
                    if(state != InterventionState.Proposed && state!=InterventionState.Approved)
                    {
                        intervention.InterventionState = state;
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
            intervention.ApprovedBy = user.Id;
            return Interventions.update(intervention);
        }

        public bool updateInterventionState(Guid interventionId, InterventionState state, Guid userId)
        {
            if (updateInterventionState(interventionId,state))
            {
                var intervention = getInterventionsById(interventionId);
                intervention.ApprovedBy = userId;
                return Interventions.update(intervention);
            }else
            {
                return false;
            }
        }

        public IEnumerable<Intervention> getInterventionsByApprovedUser(Guid userId)
        {
            return Interventions.fetchInterventionsByApprovedUser(userId).Select(c => new Intervention(c)).ToList();
        }
    }
}
