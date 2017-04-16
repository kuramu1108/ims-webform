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
        private Guid engineerId;
        private IInterventionService interventionService;
        public EngineerService(string connstring) : base(connstring)
        {
            interventionService = new InterventionService(connstring);
        }

        public Client createClient(string clientName, string clientLocation)
        {
            Client client = new Client(clientName, clientLocation, getDetail().DistrictId);
            return client;
        }
        
        public User getDetail()
        {
            return (User)Users.fetchUserByIdentityId(engineerId);
        }

        public IEnumerable<Client> getClients()
        {
            var clients = new List<Client>();
            //list of clients on the current district
            clients.AddRange(Clients.fetchClientsByDistrictId(getDetail().DistrictId).Cast<Client>());

            var interventions = getInterventionListByUserId(getDetail().Id);
            foreach (var intervention in interventions)
            {
                clients.Add((Client)Clients.fetchClientById(intervention.ClientId));
            }
            interventions = interventionService.getInterventionByApprovedUser(getDetail().Id);
            foreach (var intervention in interventions)
            {
                clients.Add((Client)Clients.fetchClientById(intervention.ClientId));
            }
           

            return clients;
        }

        
        public IEnumerable<Intervention> getInterventionsByClient(Guid clientId)
        {
          
            return Interventions.fetchInterventionsByClientId(clientId).Cast<Intervention>();
        }

     
        public Client getClientById(Guid clientId)
        {
            return (Client)Clients.fetchClientById(clientId);
        }


        public Intervention getInterventionById(Guid interventionId) {

            return (Intervention)Interventions.fetchInterventionsById(interventionId);
        }



        public Intervention createIntervention(Intervention intervention) {
            return (Intervention)Interventions.create(intervention);
        }


        public IEnumerable<Intervention> getInterventionListByUserId(Guid userId) {
            var interventionList = new List<Intervention>();
            interventionList.AddRange(Interventions.fetchInterventionsByCreator(userId).Cast<Intervention>());
            interventionList.AddRange(interventionService.getInterventionByApprovedUser(userId).Cast<Intervention>());
            return interventionList;
        }

        public bool updateInterventionState(Guid interventionId, InterventionState state)
        {
            Intervention intervention = getInterventionById(interventionId);
            if(intervention.CreatedBy == getDetail().Id)
            {
                return interventionService.updateInterventionState(interventionId, state);
            }else
            {
                return false;
            }
        }

        public bool updateInterventionApproveBy(Guid interventionId, string name)
        {
            Intervention intervention = getInterventionById(interventionId);
            if (intervention.CreatedBy == getDetail().Id)
            {
                User user = (User)Users.fetchUserByName(name);
                return interventionService.updateIntervetionApprovedBy(interventionId, user);
            }else
            {
                return false;
            }
        }

        public bool updateInterventionDetail(Guid interventionId, string comments, int remainLife)
        {
            var intervention = getInterventionById(interventionId);
            var district = Districts.fetchDistrictById(getDetail().DistrictId);
            if (intervention.DistrictName==district.Name)
            {
                return interventionService.updateInterventionDetail(interventionId, comments, remainLife);
            }else
            {
                return false;
            }
        }

        public bool updateInterventionLastVisitDate(Guid interventionId, DateTime lastVisitDate)
        {
            var intervention = getInterventionById(interventionId);
            var district = Districts.fetchDistrictById(getDetail().DistrictId);
            if (intervention.DistrictName == district.Name)
            {
                return interventionService.updateInterventionLastVisitDate(interventionId, lastVisitDate);
            }
            else
            {
                return false;
            }
        }

        public bool approveAnIntervention(Guid interventionId)
        {
            var intervention = getInterventionById(interventionId);
            var interventionType = InterventionTypes.fetchInterventionTypesById(intervention.InterventionTypeId);
            var client = getClientById(intervention.ClientId);
            var user = getDetail();

            if (client.DistrictId == user.DistrictId && user.AuthorisedHours>=intervention.Hours && user.AuthorisedCosts>=intervention.Costs && user.AuthorisedCosts>=interventionType.Costs && user.AuthorisedHours>= interventionType.Hours)
            {
                return interventionService.updateInterventionState(interventionId, InterventionState.Approved, user.Id);
            }else
            {
                return false;
            }

         
        }

        public IEnumerable<Intervention> getInterventionListByCreator(Guid userId)
        {
            return Interventions.fetchInterventionsByCreator(userId).Cast<Intervention>();
        }
    }
}