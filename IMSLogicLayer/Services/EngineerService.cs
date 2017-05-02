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
    public class EngineerService : BaseService, IEngineerService
    {
        private Guid engineerIdentityId;
        private IInterventionService interventionService;
        public IInterventionService InterventionService { get => interventionService; set => interventionService = value; }

        public Guid EngineerIdentityId { get => engineerIdentityId; set => engineerIdentityId = value; }

        /// <summary>
        ///  Initialise a engineer service and intervention service from connection string and identity id 
        /// </summary>
        /// <param name="connstring">connection string to the database</param>
        /// <param name="identityId">identity id of the logged in user</param>
        public EngineerService(string connstring, string identityId) : base(connstring)
        {
            EngineerIdentityId = new Guid(identityId);
            interventionService = new InterventionService(connstring);
        }
        /// <summary>
        /// Initialise a engineer service and intervention service from connection string 
        /// </summary>
        /// <param name="connstring">connection string to the database</param>
        public EngineerService(string connstring) : base(connstring)
        {
            interventionService = new InterventionService(connstring);
        }
        /// <summary>
        /// Create a client from name and location
        /// </summary>
        /// <param name="clientName">Name of a client</param>
        /// <param name="clientLocation">Location of a client</param>
        /// <returns>A client instance created</returns>
        public Client createClient(string clientName, string clientLocation)
        {
            Client client = new Client(Clients.createClient(new Client(clientName, clientLocation, getDetail().DistrictId)));
            return client;
        }
        /// <summary>
        /// Get All intervention Types
        /// </summary>
        /// <returns>List of intervention type</returns>
        public new List<InterventionType> getInterventionTypes()
        {
            return base.GetInterventionTypes();
        }
        /// <summary>
        /// Get the instance of current user
        /// </summary>
        /// <returns>The current user instance</returns>
        public User getDetail()
        {
            return GetDetail(engineerIdentityId);
        }
        /// <summary>
        /// Get all clients on the same district as the current user
        /// </summary>
        /// <returns>A list of client</returns>
        public IEnumerable<Client> getClients()
        {
            var clients = new List<Client>();
            clients.AddRange(Clients.fetchClientsByDistrictId(getDetail().DistrictId).Select(c => new Client(c)).ToList());

           
            return clients;
        }
        /// <summary>
        /// Get all the interventions for a client
        /// </summary>
        /// <param name="clientId">The guid of a client</param>
        /// <returns>A list of interventions</returns>
        public IEnumerable<Intervention> getInterventionsByClient(Guid clientId)
        {
            var interventions = Interventions.fetchInterventionsByClientId(clientId).Select(c => new Intervention(c)).ToList();
            interventions.RemoveAll(i => i.InterventionState == InterventionState.Cancelled);
            return interventions;
        }
        /// <summary>
        /// Get an client instance from its id
        /// </summary>
        /// <param name="clientId">The guid of a client</param>
        /// <returns>An instance of client</returns>
        public Client getClientById(Guid clientId)
        {
            return new Client(Clients.fetchClientById(clientId));
        }
        /// <summary>
        /// Get an intervention form it's id
        /// </summary>
        /// <param name="interventionId">The guid of an intervention</param>
        /// <returns>The intervention instance</returns>
        public Intervention getInterventionById(Guid interventionId) {

            return new Intervention(Interventions.fetchInterventionsById(interventionId));
        }
        /// <summary>
        /// Create an intervention
        /// </summary>
        /// <param name="intervention">An intervention instance</param>
        /// <returns>An instance of Intervention created</returns>
        public Intervention createIntervention(Intervention intervention) {
            var newIntervention = new Intervention(Interventions.create(intervention));
            if (approveAnIntervention(newIntervention.Id))
            {
                return newIntervention;
            }else
            {
                return intervention;
            }
            
            
        }
        /// <summary>
        /// Get a list of interventions created and approved by this user
        /// </summary>
        /// <param name="userId">The guid of an user</param>
        /// <returns>A list of interventions</returns>
        public IEnumerable<Intervention> getInterventionListByUserId(Guid userId) {
            var interventionList = new List<Intervention>();
            interventionList.AddRange(Interventions.fetchInterventionsByCreator(userId).Select(c => new Intervention(c)).ToList());
           
            var approved=Interventions.fetchInterventionsByApprovedUser(userId).Select(c => new Intervention(c)).ToList();
            //remove duplicated records
            foreach (var intervention in approved)
            {
                interventionList.RemoveAll(i=>i.Id == intervention.Id);

            }
            interventionList.AddRange(approved);

            interventionList.RemoveAll(i => i.InterventionState == InterventionState.Cancelled);
            return interventionList;
        }
        /// <summary>
        /// Update the state property of an intervention
        /// </summary>
        /// <param name="interventionId">The guid of an intervention</param>
        /// <param name="state">The state of an intervention</param>
        /// <returns>True if success, false if fail</returns>
        public bool updateInterventionState(Guid interventionId, InterventionState state)
        {
            Intervention intervention = getInterventionById(interventionId);
            if(intervention.CreatedBy == getDetail().Id)
            {
                if (state== InterventionState.Approved)
                {
                    return approveAnIntervention(interventionId);
                }else
                {

                    return interventionService.updateInterventionState(interventionId, state);
                }
            }else
            {
                return false;
            }
        }
        /// <summary>
        /// Update approve by property of an intervention
        /// </summary>
        /// <param name="interventionId">The guid of an intervention</param>
        /// <param name="userId">The guid of an user</param>
        /// <returns>True if success, false if fail</returns>
        public bool updateInterventionApproveBy(Guid interventionId, Guid userId)
        {
            Intervention intervention = getInterventionById(interventionId);
            if (intervention.CreatedBy == getDetail().Id)
            {
                User user = new User(Users.fetchUserById(userId));
                return interventionService.updateIntervetionApprovedBy(interventionId, user);
            }else
            {
                return false;
            }
        }
        /// <summary>
        /// Update the quality information of the intervention, comments, remainlife, recentvisit date
        /// </summary>
        /// <param name="interventionId">The guid of an intervention</param>
        /// <param name="comments">The comments of an intervention</param>
        /// <param name="remainLife">The remaining life of an intervention</param>
        /// <param name="lastVisitDate">The recent visit date of an intervention</param>
        /// <returns>True if success, false if fail</returns>
        public bool updateInterventionDetail(Guid interventionId, string comments, int remainLife, DateTime lastVisitDate)
        {
            var intervention = getInterventionById(interventionId);
            var interventionDistrict = Districts.fetchDistrictById(Clients.fetchClientById(intervention.ClientId).DistrictId);
            var district = Districts.fetchDistrictById(getDetail().DistrictId);
            if (interventionDistrict.Name == district.Name)
            {
                return interventionService.updateInterventionDetail(interventionId, comments, remainLife, lastVisitDate);
            }
            else
            {
                return false;
            }
        }
      
      
        /// <summary>
        /// Approve an intervention
        /// </summary>
        /// <param name="interventionId">The guid of an intervention</param>
        /// <returns>True if success, false if fail</returns>
        public bool approveAnIntervention(Guid interventionId)
        {
            var intervention = getInterventionById(interventionId);
            var interventionType = InterventionTypes.fetchInterventionTypesById(intervention.InterventionTypeId);
            var client = getClientById(intervention.ClientId);
            var user = getDetail();
            //if meets approve criteria,approve it by engineer self and update approve by
            if (client.DistrictId == user.DistrictId && user.AuthorisedHours>=intervention.Hours && user.AuthorisedCosts>=intervention.Costs && user.AuthorisedCosts>=interventionType.Costs && user.AuthorisedHours>= interventionType.Hours)
            {

                if (interventionService.updateInterventionState(interventionId, InterventionState.Approved, user.Id))
                {
                    return updateInterventionApproveBy(interventionId, user.Id);
                }else
                {
                    return false;
                }
               
                
            }else
            {
                return false;
            }
        }
        /// <summary>
        /// Get a list of interventions based on it's creator
        /// </summary>
        /// <param name="userId">The guid of an user</param>
        /// <returns>A list of intervention</returns>
        public IEnumerable<Intervention> getInterventionListByCreator(Guid userId)
        {
            var interventions = Interventions.fetchInterventionsByCreator(userId).Select(c => new Intervention(c)).ToList();

            interventions.RemoveAll(i => i.InterventionState == InterventionState.Cancelled);
            return interventions;
        }
        /// <summary>
        /// Get the User instance by its id
        /// </summary>
        /// <param name="userId">The guid of an user</param>
        /// <returns>An user instance</returns>
        public User getUserById(Guid userId)
        {

            return new User(Users.fetchUserById(userId));
        }
    }
}
