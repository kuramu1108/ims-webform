using IMSLogicLayer.Enums;
using IMSLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.ServiceInterfaces
{
    public interface IEngineerService
    {
        //use to create client
        Client createClient(string clientName, string clientLocation);

        //use to get details of this user
        User getDetail();

        //use to get list of client
        IEnumerable<Client> getClients();

        //use to get a list of intervention from client id 
        IEnumerable<Intervention> getInterventionsByClient(Guid clientId);

        //use to get a client
        Client getClientById(Guid clientId);

        //use to get an intervention and also edit
        Intervention getInterventionById(Guid interventionId);

        //use to create intervention
        Intervention createIntervention(Intervention intervention);

        //use to get a list of intervention for a engineer
        IEnumerable<Intervention> getInterventionListByUserId(Guid userId);
        //use to change Administrative information state
        bool updateInterventionState(Guid interventionId, InterventionState state);
        //use to change Administrative information approveby
        bool updateInterventionApproveBy(Guid interventionId, string name);

    }
}
