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
            return Clients.fetchClientsByDistrictId(getDetail().DistrictId).Cast<Client>();
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
            return Interventions.fetchInterventionsByCreator(userId).Cast<Intervention>();
        }

        public bool updateInterventionState(Guid interventionId, InterventionState state)
        {
            Intervention intervention = getInterventionById(interventionId);
            if(intervention.CreatedBy == getDetail().IdentityId)
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
            if (intervention.CreatedBy == getDetail().IdentityId)
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
    }
}
