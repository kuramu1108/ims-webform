﻿using IMSDBLayer;
using IMSDBLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogic
{
    public class SiteEngineer : User
    {
        //districts, cost hour
        //public Common.Districts Districts { get; set; }
        //public double AuthorisedHour { get; set; }
        //public decimal AuthorisedCost { get; set; }


        private IMSDBLayer.DataModels.User SiteEngineerDM;
        public SiteEngineer() { SiteEngineerDM = new IMSDBLayer.DataModels.User(); }

        public SiteEngineer(int id, string name, string loginName, System.Security.SecureString password, Common.UserType type, Common.Districts districts, double hour, decimal cost)
        {
           

            SiteEngineerDM = null;
        }
        //public void CreateClient(string name, string location, Common.Districts district)
        //{
        //    DB.CreateClient(Name,Location,district);
        //}
        //public List<Client> ViewAllClients()
        //{
        //    DB.ViewAll();
        //}
        //public Client ViewDetails(int client_id)
        //{
        //    DB.GetOneClient(id);
        //}
        //public Intervention DetailsOfIntervention(int client_id)
        //{
        //    DB.GetInterventionDetail(client_id);
        //}
        //public void CreateNewIntervention(Intervention intervention)
        //{
        //    DB.CreateIntervention(UserID,intervention);
        //}
        //public List<Intervention> ViewOwnInterventions()
        //{
        //    DB.ViewEngineerInterventions(UserID);
        //}
        //public void ChangeState(int intervention_id, string new_state)
        //{
        //    DB.ChangeInterventionState(intervention_id,new_state);
        //}





    }
}
