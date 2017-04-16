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
        private Guid managerId;
        private IInterventionService interventionService;
        public ManagerService(string connstring) : base(connstring)
        {
            interventionService = new InterventionService(connstring);
        }

        public User getDetail()
        {
            return (User)Users.fetchUserByIdentityId(managerId);
        }

        public IEnumerable<Intervention> getListOfProposedIntervention()
        {
            return Interventions.fetchInterventionsByState((int)InterventionState.Proposed).Cast<Intervention>();
        }


        public Intervention getInterventionById(Guid interventionId)
        {
            return (Intervention)Interventions.fetchInterventionsById(interventionId);
        }


        public Boolean approveAnIntervention(Guid interventionId)
        {

            var intervention = getInterventionById(interventionId);
            var interventionType = InterventionTypes.fetchInterventionTypesById(intervention.InterventionTypeId);
            var client = Clients.fetchClientById(intervention.ClientId);
            var user = getDetail();

            if (client.DistrictId == user.DistrictId && user.AuthorisedHours >= intervention.Hours && user.AuthorisedCosts >= intervention.Costs && user.AuthorisedCosts >= interventionType.Costs && user.AuthorisedHours >= interventionType.Hours)
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
            if (intervention.DistrictName == districtName.Name)
            {
                return interventionService.updateInterventionState(interventionId, state);
            }
            else
            {
                return false;
            }
        }

        public bool updateInterventionApproveBy(Guid interventionId, string name)
        {
            Intervention intervention = getInterventionById(interventionId);
            var district = Districts.fetchDistrictById(getDetail().DistrictId);
            if (intervention.DistrictName == district.Name)
            {
                User user = (User)Users.fetchUserByName(name);
                return interventionService.updateIntervetionApprovedBy(interventionId, user);
            }
            else
            {
                return false;
            }
        }

    }
}