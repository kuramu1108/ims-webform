using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer;
using IMSDBLayer.DataModels;

namespace IMSLogic
{
    public class Manager : User
    {
        public Common.Districts Districts { get; set; }
        public double AuthorisedHour { get; set; }
        public decimal AuthorisedCost { get; set; }


        private IMSDBLayer.DataModels.User managerDM;
    public Manager()
    {
            managerDM = new IMSDBLayer.DataModels.User();
    }

    public Manager(int id, string name, string loginName, System.Security.SecureString password, Common.UserType type, Common.Districts districts, double hour, decimal cost)
    {
            UserID = id;
            Name = name;
            LoginName = loginName;
            Password = password;
            Type = type;
            Districts = districts;
            AuthorisedHour = hour;
            AuthorisedCost = cost;
            managerDM = null;


    }

    public void GetListOfInterventions()
    {
        DataAccess.GetListofProposedInterventions();
    }

    public void ApproveIntervention(Intervention intervention)
    {
        //if (intervention.Cost < managerDM.AuthorisedCost && intervention.Labour_hours < managerDM.AuthorisedHour)
        //{
        //    DataAccess.ChangeState(intervention.Intervention_id, Common.InterventionState.Approved.ToString());
        //}

    }
}
}
