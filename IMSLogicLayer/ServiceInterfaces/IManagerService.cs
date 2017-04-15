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
        //use to get the details of this user
        User getDetail();

        //use to get a list of intervention where state is proposed
        IEnumerable<Intervention> getListOfProposedIntervention();

        //use to get an intervention so the user can approve
        Intervention getInterventionById(Guid interventionId);

        //approve an intervention
        Boolean approveAnIntervention(Guid interventionId);
    }
}
