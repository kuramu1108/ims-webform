using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer;
using IMSDBLayer.DataModels;

namespace IMSLogicLayer
{
    public class Manager : User
    {
        public District District { get; set; }
        public double AuthorisedHour { get; set; }
        public decimal AuthorisedCost { get; set; }


        private IMSDBLayer.DataModels.User managerDM;

        public Manager()
        {
                managerDM = new IMSDBLayer.DataModels.User();
        }

        //public void GetListOfInterventions()
        //{
        //    DataAccess.GetListofProposedInterventions();
        //}

        public void ApproveIntervention(Intervention intervention)
        {
            //if (intervention.Cost < managerDM.AuthorisedCost && intervention.Labour_hours < managerDM.AuthorisedHour)
            //{
            //    DataAccess.ChangeState(intervention.Intervention_id, Common.InterventionState.Approved.ToString());
            //}
        }
    }
}
