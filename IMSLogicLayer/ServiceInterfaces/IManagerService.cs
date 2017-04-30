using IMSLogicLayer.Enums;
using IMSLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.ServiceInterfaces
{
    public interface IManagerService
    {
        Guid ManagerId { get; set; }
        //use to get the details of this user
        User getDetail();

        //use to get a list of intervention where state is proposed
        IEnumerable<Intervention> getInterventionsByState(InterventionState state);

        //use to get an intervention so the user can approve
        Intervention getInterventionById(Guid interventionId);

        //approve an intervention
        Boolean approveAnIntervention(Guid interventionId);


        bool updateInterventionState(Guid interventionId, InterventionState state);
        bool updateInterventionApproveBy(Guid interventionId, Guid userId);

    }
}
