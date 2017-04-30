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
        private Guid managerIdentityId;
        private IInterventionService interventionService;

        public Guid ManagerId { get => managerIdentityId; set => managerIdentityId = value; }
        public IInterventionService InterventionService { get => interventionService; set => interventionService = value; }

        public ManagerService(string connstring) : base(connstring)
        {
            interventionService = new InterventionService(connstring);
        }

        public ManagerService(string connstring, string identityId) : base(connstring)
        {
            managerIdentityId = new Guid(identityId);
            interventionService = new InterventionService(connstring);
        }

        public User getDetail()
        {
            return new User(Users.fetchUserByIdentityId(managerIdentityId));
        }

        public IEnumerable<Intervention> getInterventionsByState(InterventionState state)
        {
            var interventions = Interventions.fetchInterventionsByState((int)state).Select(c => new Intervention(c)).ToList();

            foreach (var intervention in interventions)
            {
                intervention.InterventionType = new InterventionType(InterventionTypes.fetchInterventionTypesById(intervention.InterventionTypeId));
                intervention.Client = new Client(Clients.fetchClientById(intervention.ClientId));
                intervention.District = new District(Districts.fetchDistrictById(intervention.Client.DistrictId));
                intervention.InterventionState = InterventionState.Proposed;

            }
            return interventions;
        }


        public Intervention getInterventionById(Guid interventionId)
        {
            return new Intervention(Interventions.fetchInterventionsById(interventionId));
        }


        public Boolean approveAnIntervention(Guid interventionId)
        {

            var intervention = getInterventionById(interventionId);
            var interventionType = InterventionTypes.fetchInterventionTypesById(intervention.InterventionTypeId);
            var client = Clients.fetchClientById(intervention.ClientId);
            var user = getDetail();

            if (client.DistrictId == user.DistrictId && user.AuthorisedHours >= intervention.Hours 
                && user.AuthorisedCosts >= intervention.Costs && user.AuthorisedCosts >= interventionType.Costs 
                && user.AuthorisedHours >= interventionType.Hours)
            {
                return interventionService.updateInterventionState(interventionId, InterventionState.Approved, user.Id);
            }
            else
            {
                return false;
            }

        }


        public bool updateInterventionState(Guid interventionId, InterventionState state)
        {
            Intervention intervention = getInterventionById(interventionId);
            var districtName = Districts.fetchDistrictById(getDetail().DistrictId);
            if (intervention.District.Name == districtName.Name)
            {
                return interventionService.updateInterventionState(interventionId, state);
            }
            else
            {
                return false;
            }
        }

        public bool updateInterventionApproveBy(Guid interventionId, Guid userId)
        {
            Intervention intervention = getInterventionById(interventionId);
            var district = Districts.fetchDistrictById(getDetail().DistrictId);
            if (intervention.District.Name == district.Name)
            {
                User user = new User(Users.fetchUserById(userId));
                return interventionService.updateIntervetionApprovedBy(interventionId, user);
            }
            else
            {
                return false;
            }
        }

    }
}
