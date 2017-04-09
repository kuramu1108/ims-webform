using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer;

namespace IMSLogic
{
    public class Manager:Users
    {
        public Common.Districts Districts { get; set; }
        public double AuthorisedHour { get; set; }
        public decimal AuthorisedCost { get; set; }

        public Manager() { }

        public Manager(int id,string name, string loginName, System.Security.SecureString password, Common.UserType type, Common.Districts districts, double hour, decimal cost)
        {
            UserID = id;
            Name = name;
            LoginName = loginName;
            Password = password;
            Type = type;
            Districts = districts;
            AuthorisedHour = hour;
            AuthorisedCost = cost;


        }

        public void GetListOfInterventions()
        {
            DataAccess.GetListofProposedInterventions();
        }

        public void ApproveIntervention(Intervention intervention)
        {
            if (intervention.Cost < AuthorisedCost && intervention.Labour_hours <AuthorisedHour)
            {
                DataAccess.ChangeState(intervention.Intervention_id, Common.InterventionState.Approved.ToString());
            }

        }
    }
}
