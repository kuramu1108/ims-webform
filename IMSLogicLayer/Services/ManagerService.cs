using IMSLogicLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSLogicLayer.Models;
using IMSLogicLayer.Enums;

namespace IMSLogicLayer.Services
{
    public class ManagerService : BaseService, IManagerService
    {
        private Guid managerId;
        public ManagerService(string connstring) : base(connstring) { }

        public User getDetail()
        {
            return (User)Users.fetchUserByIdentityId(managerId);
        }

        IEnumerable<Intervention> getListOfProposedIntervention() {
            return (IEnumerable<Intervention>)Interventions.fetchInterventionsByState((int)InterventionState.Proposed);
        }


        Intervention getInterventionById(Guid interventionId) {
            return (Intervention)Interventions.fetchInterventionsById(interventionId);
        }


        Boolean approveAnIntervention(Guid interventionId) {

            var intervention = getInterventionById(interventionId);
            intervention.State = InterventionState.Approved;

            return Interventions.update(intervention);
        }
    }
}
