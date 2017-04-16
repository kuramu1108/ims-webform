using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataAccessObjects;
using IMSLogicLayer.Enums;
using IMSLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.FakeServices
{
    public class FakeBaseService
    {
        private List<Intervention> interventions;
        private List<InterventionType> interventionTypes;
        private List<User> users;
        private List<District> districts;
        private List<Client> clients;
        
        public FakeBaseService(string connstring)
        {
            //Add Fake District
            districts = new List<District>();
            District district1 = new District("Urban Indonesia");
            district1.Id = Guid.NewGuid();

            District district2 = new District("Rural Indonesia");
            district2.Id = Guid.NewGuid();

            District district3 = new District("Urban Papua New Guinea");
            district3.Id = Guid.NewGuid();

            District district4 = new District("Rural Papua New Guinea");
            district4.Id = Guid.NewGuid();

            District district5 = new District("Sydney");
            district5.Id = Guid.NewGuid();

            District district6 = new District("Rural New South Wales");
            district6.Id = Guid.NewGuid();

            districts.Add(district1);
            districts.Add(district2);
            districts.Add(district3);
            districts.Add(district4);
            districts.Add(district5);
            districts.Add(district6);

            interventionTypes = new List<InterventionType>();
            InterventionType interType1 = new InterventionType("Supply and Install Portable Toilet", 10, 300);
            interType1.Id = Guid.NewGuid();

            InterventionType interType2 = new InterventionType("Hepatitis Avoidance Training", 12, 300);
            interType2.Id = Guid.NewGuid();

            InterventionType interType3 = new InterventionType("Supply and Install Storm-proof Home Kit", 4, 100);
            interType3.Id = Guid.NewGuid();

            interventionTypes.Add(interType1);
            interventionTypes.Add(interType2);
            interventionTypes.Add(interType3);
            
            users = new List<User>();
            User engineer1 = new User("Dan Dienal", 1, 10, 200, Guid.NewGuid(), district1.Id);
            engineer1.Id = Guid.NewGuid();

            User engineer2 = new User("Van Dienal", 1, 10, 200, Guid.NewGuid(), district1.Id);
            engineer2.Id = Guid.NewGuid();

            User engineer3 = new User("Lan Dienal", 1, 10, 200, Guid.NewGuid(), district1.Id);
            engineer3.Id = Guid.NewGuid();

            users.Add(engineer1);
            users.Add(engineer2);
            users.Add(engineer3);

            clients = new List<Client>();
            Client client1 = new Client("Dan Dock", "Dock Dock", district1.Id);
            client1.Id = Guid.NewGuid();

            Client client2 = new Client("Dan Hock", "Hock Hock", district1.Id);
            client2.Id = Guid.NewGuid();

            Client client3 = new Client("Dan Lock", "Lock Lock", district1.Id);
            client3.Id = Guid.NewGuid();

            Intervention inter1 = new Intervention(12m, 1750.00m, 89, "", InterventionState.Proposed, DateTime.Now, new DateTime(), new DateTime(), interType1.Id, client1.Id, engineer1.Id, Guid.Empty);
            inter1.Id = Guid.NewGuid();

            Intervention inter2 = new Intervention(12m, 1750.00m, 89, "", InterventionState.Proposed, DateTime.Now, new DateTime(), new DateTime(), interType2.Id, client2.Id, engineer1.Id, Guid.Empty);
            inter2.Id = Guid.NewGuid();

            Intervention inter3 = new Intervention(12m, 1750.00m, 89, "", InterventionState.Proposed, DateTime.Now, new DateTime(), new DateTime(), interType3.Id, client3.Id, engineer1.Id, Guid.Empty);
            inter3.Id = Guid.NewGuid();

            Intervention inter4 = new Intervention(12m, 1750.00m, 89, "", InterventionState.Proposed, DateTime.Now, new DateTime(), new DateTime(), interType1.Id, client3.Id, engineer1.Id, Guid.Empty);
            inter4.Id = Guid.NewGuid();

            Intervention inter5 = new Intervention(12m, 1750.00m, 89, "", InterventionState.Proposed, DateTime.Now, new DateTime(), new DateTime(), interType2.Id, client2.Id, engineer1.Id, Guid.Empty);
            inter5.Id = Guid.NewGuid();

            Intervention inter6 = new Intervention(12m, 1750.00m, 89, "", InterventionState.Proposed, DateTime.Now, new DateTime(), new DateTime(), interType3.Id, client1.Id, engineer1.Id, Guid.Empty);
            inter6.Id = Guid.NewGuid();

            interventions.Add(inter1);
            interventions.Add(inter2);
            interventions.Add(inter3);
            interventions.Add(inter4);
            interventions.Add(inter5);
            interventions.Add(inter6);
        }

        public List<User> Users { get => users; set => users = value; }
        public List<InterventionType> InterventionTypes { get => interventionTypes; set => interventionTypes = value; }
        public List<Intervention> Interventions { get => interventions; set => interventions = value; }
        public List<District> Districts { get => districts; set => districts = value; }
        public List<Client> Clients { get => clients; set => clients = value; }
    }
}
