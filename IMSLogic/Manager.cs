using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer;

namespace IMSLogic
{
    public class Manager : Users
    {
    //    public Common.Districts Districts { get; set; }
    //    public double AuthorisedHour { get; set; }
    //    public decimal AuthorisedCost { get; set; }


        private ManagerDM managerDM;
    public Manager()
    {
        managerDM = new ManagerDM();
    }

    public Manager(int id, string name, string loginName, System.Security.SecureString password, Common.UserType type, Common.Districts districts, double hour, decimal cost)
    {
        //UserID = id;
        //Name = name;
        //LoginName = loginName;
        //Password = password;
        //Type = type;
        //Districts = districts;
        //AuthorisedHour = hour;
        //AuthorisedCost = cost;
        managerDM = new ManagerDM(id, name, loginName, password, type, districts, hour, cost);


    }

    public void GetListOfInterventions()
    {
        DataAccess.GetListofProposedInterventions();
    }

    public void ApproveIntervention(Intervention intervention)
    {
        if (intervention.Cost < managerDM.AuthorisedCost && intervention.Labour_hours < managerDM.AuthorisedHour)
        {
            DataAccess.ChangeState(intervention.Intervention_id, Common.InterventionState.Approved.ToString());
        }

    }
}
}
