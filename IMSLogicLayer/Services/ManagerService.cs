﻿using IMSLogicLayer.ServiceInterfaces;
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
        private Guid managerId;

        private IInterventionService interventionService;

        public Guid ManagerId { get => managerId; set => managerId = value; }

        public IInterventionService InterventionService { get => interventionService; set => interventionService = value; }
        /// <summary>
        /// Initialise an instance of the manager service from connection string
        /// </summary>
        /// <param name="connstring">The connection string to the database</param>
        public ManagerService(string connstring) : base(connstring)
        {
            interventionService = new InterventionService(connstring);
        }
        /// <summary>
        /// Initialise manager service from connection string and an identity id
        /// </summary>
        /// <param name="connstring">The connection string to database</param>
        /// <param name="identityId">The identity id of the current user</param>
        public ManagerService(string connstring, string identityId) : base(connstring)
        {
            managerIdentityId = new Guid(identityId);
            managerId = Users.fetchUserByIdentityId(managerIdentityId).Id;

            interventionService = new InterventionService(connstring);
        }
        /// <summary>
        /// Get the current User instance
        /// </summary>
        /// <returns>The current user</returns>
        public User GetDetail()
        {
            var user = new User(Users.fetchUserByIdentityId(managerIdentityId));
            user.District = new District(Districts.fetchDistrictById(user.DistrictId));
            return user;
        }
        /// <summary>
        /// Get a list of interventions from the state they are in
        /// </summary>
        /// <param name="state">The state of an intervention</param>
        /// <returns>A list of intervention</returns>
        public IEnumerable<Intervention> GetInterventionsByState(InterventionState state)
        {
            var interventions = Interventions.fetchInterventionsByState((int)state).Select(c => new Intervention(c)).ToList();
            List<Intervention> managerInterventions = new List<Intervention>();
            User manager = GetDetail();
            foreach (var intervention in interventions)
            {
                intervention.Client = new Client(Clients.fetchClientById(intervention.ClientId));
                intervention.InterventionType = new InterventionType(InterventionTypes.fetchInterventionTypesById(intervention.InterventionTypeId));
                intervention.District = new District(Districts.fetchDistrictById(intervention.Client.DistrictId));
                if (manager.DistrictId == intervention.District.Id)
                {
                    managerInterventions.Add(intervention);
                }
            }
            return managerInterventions;
        }

        /// <summary>
        /// Get an intervention from guid provided
        /// </summary>
        /// <param name="interventionId">The guid of an intervention</param>
        /// <returns>The corresponding intervention</returns>
        public Intervention GetInterventionById(Guid interventionId)
        {
            return new Intervention(Interventions.fetchInterventionsById(interventionId));
        }

        /// <summary>
        /// Approve an intervention 
        /// </summary>
        /// <param name="interventionId">The guid of an intervention</param>
        /// <returns>True if successfully approved an intervention, false if fail</returns>
        public Boolean ApproveAnIntervention(Guid interventionId)
        {
            //create instance of intervention from guid
            var intervention = GetInterventionById(interventionId);
            //create instance of intervention type from intervention type id using interventionType
            var interventionType = InterventionTypes.fetchInterventionTypesById(intervention.InterventionTypeId);

            //create instance of client from intervention's client id
            var client = Clients.fetchClientById(intervention.ClientId);

            //create instance of the current user
            var user = GetDetail();
            //if the criteria of approve an intervention meets then update the state of an intervention
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

        /// <summary>
        /// Update the state of an intervention 
        /// </summary>
        /// <param name="interventionId">The guid of an intervention</param>
        /// <param name="state">The enum intervention state to update to</param>
        /// <returns>True if successfully updated, false if fail</returns>
        public bool UpdateInterventionState(Guid interventionId, InterventionState state)
        {
            //create intervention instance from guid
            var intervention = GetInterventionById(interventionId);
            //create an instance of district object with the intervention's client's district id
            var interventionDistrict = Districts.fetchDistrictById(Clients.fetchClientById(intervention.ClientId).DistrictId);

            //create an instance of district from the current user's district id
            var district = Districts.fetchDistrictById(GetDetail().DistrictId);

            //if district is same, then update the state of the intervention
            if (interventionDistrict.Name == district.Name)
            {
                return interventionService.updateInterventionState(interventionId, state);
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Update Approved by property of the intervention
        /// </summary>
        /// <param name="interventionId">The guid of an intervention</param>
        /// <param name="userId">The current user id</param>
        /// <returns>True if success, false if fail</returns>
        public bool UpdateInterventionApproveBy(Guid interventionId, Guid userId)
        {
            //create intervention instance with guid
            Intervention intervention = GetInterventionById(interventionId);

            //create an instance of district object with the intervention's client's district id
            var interventionDistrict = Districts.fetchDistrictById(Clients.fetchClientById(intervention.ClientId).DistrictId);
            //get district from the current user district
            var district = Districts.fetchDistrictById(GetDetail().DistrictId);
            //if the district is the same approve it and update approve by
            //return true is success, else false
            if (interventionDistrict.Name == district.Name)
            {
                User user = new User(Users.fetchUserById(userId));
                return interventionService.updateIntervetionApprovedBy(interventionId, user);
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Get approved Interventions of the current Manager
        /// </summary>
        /// <returns>A list of Intervention with interventionType, client, district property</returns>
        public IEnumerable<Intervention> GetApprovedInterventions()
        {
            //get intervention by state approved and complete
            var interventions = Interventions.fetchInterventionsByState((int)InterventionState.Approved).Select(c => new Intervention(c)).ToList();
            interventions.AddRange(Interventions.fetchInterventionsByState((int)InterventionState.Completed).Select(c => new Intervention(c)).ToList());

            //only select interventions approved by this manager
            interventions = interventions.Where(x => x.ApprovedBy == managerId).ToList();

            foreach (var intervention in interventions)
            {
                intervention.InterventionType = new InterventionType(InterventionTypes.fetchInterventionTypesById(intervention.InterventionTypeId));
                intervention.Client = new Client(Clients.fetchClientById(intervention.ClientId));
                intervention.District = new District(Districts.fetchDistrictById(intervention.Client.DistrictId));

            }
            return interventions;
        }
    }
}
