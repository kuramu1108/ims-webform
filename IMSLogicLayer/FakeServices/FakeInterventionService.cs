using IMSLogicLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSLogicLayer.Enums;
using IMSLogicLayer.Models;

namespace IMSLogicLayer.FakeServices
{
    public class FakeInterventionService : FakeBaseService, IInterventionService
    {
        List<Intervention> interventions;
        public FakeInterventionService(string connstring) : base(connstring)
        {
        }

        public IEnumerable<Intervention> getInterventionsByCreatorId(Guid creatorId)
        {
             interventions = new List<Intervention>()
            {
                 

            new Intervention(12m,1750.00m,89,"",1,new DateTime(2017, 4, 10, 13, 31, 17),new DateTime(2017, 4, 10, 13, 31, 17),new DateTime(2017, 4, 13, 13, 31, 17),new Guid("99999999-8888-7777-6666-55555555555555"), new Guid("11111111-2222-3333-4444-555555555555"),new Guid("99999999-9999-9999-9999-999999999999"),new Guid("22222222-2222-2222-2222-222222222222")),

            new Intervention(12m,1750.00m,89,"",1,new DateTime(2017, 4, 11, 13, 31, 17),new DateTime(2017, 4, 12, 13, 31, 17),new DateTime(2017, 4, 11, 13, 31, 17),new Guid("99999999-8888-7777-6666-55555555555555"), new Guid("11111111-2222-3333-4444-555555555555"),new Guid("99999999-9999-9999-9999-999999999999"),new Guid("22222222-2222-2222-2222-222222222222"))
            };


            return interventions;
        }

        public Intervention getInterventionsById(Guid interventionId)
        {
            return new Intervention(12m, 1750.00m, 89, "", 1, new DateTime(2017, 4, 10, 13, 31, 17), new DateTime(2017, 4, 10, 13, 31, 17), new DateTime(2017, 4, 13, 13, 31, 17), new Guid("99999999-8888-7777-6666-55555555555555"), new Guid("11111111-2222-3333-4444-555555555555"), new Guid("99999999-9999-9999-9999-999999999999"), new Guid("22222222-2222-2222-2222-222222222222"));
        }

        public IEnumerable<Intervention> getListofProposedInterventions()
        {
            return interventions;
        }

        public IEnumerable<Intervention>getInterventionsByClientId(Guid clientId)
        {
            return interventions;
        }

        public bool updateInterventionDetail(Guid interventionId, string comments, int remainLife)
        {
            return true;
        }

        public bool updateInterventionLastVisitDate(Guid interventionId, DateTime lastVisitDate)
        {
            return true;
        }

        public bool updateInterventionState(Guid interventionId, InterventionState state)
        {
            return true;
        }

        public bool updateIntervetionApprovedBy(Guid interventionId, User user)
        {
            return true;
        }

        public bool updateInterventionState(Guid interventionId, InterventionState state, Guid identityId)
        {
            return true;
        }

        public IEnumerable<Intervention> getInterventionByApprovedUser(Guid userId)
        {
            return interventions;
        }
    }
}
