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
        /// <summary>
        /// get and set property manager identity id
        /// </summary>
        public Guid ManagerId { get => managerIdentityId; set => managerIdentityId = value; }

        public ManagerService(string connstring) : base(connstring)
        {
            interventionService = new InterventionService(connstring);
        }
        /// <summary>
        /// Manager constructor
        /// </summary>
        /// <param name="connstring">connection string for data base</param>
        /// <param name="identityId">identityId of the manager</param>
        public ManagerService(string connstring, string identityId) : base(connstring)
        {
            managerIdentityId = new Guid(identityId);
            //instantiate a new instance of intervention service
            interventionService = new InterventionService(connstring);
        }
        /// <summary>
        /// return the current manager using  the base service user data access
        /// return the object in logic layer model
        /// </summary>
        /// <returns>the current manager instance</returns>
        public User getDetail()
        {
            return new User(Users.fetchUserByIdentityId(managerIdentityId));
        }
        /// <summary>
        /// get a list of intervention from database which their state is the same as the parameter
        /// using the base service intervention data access
        /// return the object in logic lay model
        /// </summary>
        /// <param name="state">the state of the intervention</param>
        /// <returns>A list of intervention of specific state</returns>
        public IEnumerable<Intervention> getInterventionsByState(InterventionState state)
        {
            //get a list of interventions from database using base service intervention data access
            var interventions = Interventions.fetchInterventionsByState((int)state).Select(c => new Intervention(c)).ToList();


            //prepare details for the UI layer to display
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
