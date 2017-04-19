using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSLogicLayer.Enums;
using IMSLogicLayer.Models;
using IMSLogicLayer.ServiceInterfaces;

namespace IMSLogicLayer.FakeServices
{
    public class FakeEngineerService : FakeBaseService, IEngineerService
    {
        public FakeEngineerService(string connstring) : base(connstring)
        {
        }

        public Client createClient(string clientName, string clientLocation)
        {
            Client client = new Client("Josh Tims", "Sydney", new Guid("11111111-2222-3333-4444-555555555555"));
            return client;
        }

        public Intervention createIntervention(Intervention intervention)
        {
            return intervention;
        }

        public Client getClientById(Guid clientId)
        {
            Client client = new Client("Josh Tims", "Sydney", new Guid("11111111-2222-3333-4444-555555555555"));
            return client;
        }

        public IEnumerable<Client> getClients()
        {
            //var Clients = new List<Client>()
            //{
            //   new Client("Josh Tims","Sydney",  new Guid("11111111-2222-3333-4444-555555555555")),
            //   new Client("Johnathan Miller","Sydeny",  new Guid("11111111-2222-3333-4444-555555555555"))
            //};

            return Clients;
        }

        public User getDetail()
        {
            return new User("John Miller", 1, 6m, 1000.00m, new Guid("44444444-4444-4444-4444-444444444444"), new Guid("66666666-6666-6666-6666-6666-666666666666"));
        }

        public IEnumerable<Intervention> getInterventionsByClient(Guid clientId)
        {
            FakeInterventionService IS = new FakeInterventionService("");
            return IS.getInterventionsByClientId(clientId);

        }

        public Intervention getInterventionById(Guid interventionId)
        {
            FakeInterventionService IS = new FakeInterventionService("");
            return IS.getInterventionsById(interventionId);
        }

        public IEnumerable<Intervention> getInterventionListByUserId(Guid userId)
        {
            FakeInterventionService IS = new FakeInterventionService("");
            return IS.getInterventionsByCreatorId(userId);
        }

        public bool updateInterventionState(Guid interventionId, InterventionState state)
        {
            return true;
        }

        public bool updateInterventionApproveBy(Guid interventionId, string name)
        {
            return true; 
        }

        public bool updateInterventionDetail(Guid interventionId, string comments, int remainLife)
        {
            return true;
        }

        public bool updateInterventionLastVisitDate(Guid interventionId, DateTime lastVisitDate)
        {
            return true;
        }

        public bool approveAnIntervention(Guid interventionId)
        {
            return true;
        }

        public IEnumerable<Intervention> getInterventionListByCreator(Guid userId)
        {
            FakeInterventionService IS = new FakeInterventionService("");
            return IS.getInterventionsByCreatorId(userId);
        }

        public bool updateInterventionApproveBy(Guid interventionId, Guid userId)
        {
            return true;
        }
    }
}
