using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSLogicLayer.ServiceInterfaces;
using IMSLogicLayer.Services;
using IMSLogicLayer.Models;
using Microsoft.AspNet.Identity;

namespace InterventionManagementSystem.Manager
{
    public partial class InterventionList : System.Web.UI.Page
    {
        
      
        protected void Page_Load(object sender, EventArgs e)
        {
            IManagerService managerService = new ManagerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string userId = User.Identity.GetUserId<string>();
            managerService.ManagerId = new Guid(userId);


            List<Intervention> interventions = managerService.getListOfProposedIntervention().ToList();


            foreach (var intervention in interventions)
            {
               
            }
            ListIntervention.DataSource = interventions;
            ListIntervention.DataBind();
        }
    }
}