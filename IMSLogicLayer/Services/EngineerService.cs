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
    public class EngineerService : BaseService, IEngineerService
    {
        private Guid engineerIdentityId;
        private IInterventionService interventionService;

        public Guid EngineerIdentityId { get => engineerIdentityId; set => engineerIdentityId = value; }

        public EngineerService(string connstring, string identityId) : base(connstring)
        {
            EngineerIdentityId = new Guid(identityId);
            interventionService = new InterventionService(connstring);
        }

        public EngineerService(string connstring) : base(connstring)
        {
            interventionService = new InterventionService(connstring);
        }

        public Client createClient(string clientName, string clientLocation)
        {
            Client client = new Client(Clients.createClient(new Client(clientName, clientLocation, getDetail().DistrictId)));
            return client;
        }

        public new List<InterventionType> getInterventionTypes()
        {
            return base.getInterventionTypes();
        }

        public User getDetail()
        {
            return getDetail(engineerIdentityId);
        }

        public IEnumerable<Client> getClients()
        {
            var clients = new List<Client>();
            //list of clients on the current district
            clients.AddRange(Clients.fetchClientsByDistrictId(getDetail().DistrictId).Select(c => new Client(c)).ToList());

            //var interventions = getInterventionListByUserId(getDetail().Id);
            //foreach (var intervention in interventions)
            //{
            //    clients.Add(new Client(Clients.fetchClientById(intervention.ClientId)));
            //}
         
            return clients;
        }
        
        public IEnumerable<Intervention> getInterventionsByClient(Guid clientId)
        {
          
            return Interventions.fetchInterventionsByClientId(clientId).Select(c => new Intervention(c)).ToList();
        }
        
        public Client getClientById(Guid clientId)
        {
            return new Client(Clients.fetchClientById(clientId));
        }
        
        public Intervention getInterventionById(Guid interventionId) {

            return new Intervention(Interventions.fetchInterventionsById(interventionId));
        }
        
        public Intervention createIntervention(Intervention intervention) {
            return new Intervention(Interventions.create(intervention));
        }
        
        public IEnumerable<Intervention> getInterventionListByUserId(Guid userId) {
            var interventionList = new List<Intervention>();
            interventionList.AddRange(Interventions.fetchInterventionsByCreator(userId).Select(c => new Intervention(c)).ToList());
            interventionList.AddRange(interventionService.getInterventionsByApprovedUser(userId).Select(c => new Intervention(c)).ToList());
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

        public bool updateInterventionDetail(Guid interventionId, string comments, int remainLife)
        {
            var intervention = getInterventionById(interventionId);
            var interventionDistrict = Districts.fetchDistrictById(Clients.fetchClientById(intervention.ClientId).DistrictId);
            var district = Districts.fetchDistrictById(getDetail().DistrictId);
            if (interventionDistrict.Name==district.Name)
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
            if (intervention.District.Name == district.Name)
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
            return Interventions.fetchInterventionsByCreator(userId).Select(c => new Intervention(c)).ToList();
        }
    }
}
