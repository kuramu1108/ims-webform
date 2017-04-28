using IMSLogicLayer.FakeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSLogicLayer.Models;
using IMSLogicLayer.ServiceInterfaces;
using Microsoft.AspNet.Identity;
using IMSLogicLayer.Services;

namespace InterventionManagementSystem.Engineer
{
    public partial class InterventionList : System.Web.UI.Page
    {
        IInterventionService interventionService;
        protected void Page_Load(object sender, EventArgs e)
        {

            interventionService = new InterventionService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string userId = User.Identity.GetUserId<string>();
            IEnumerable<Intervention> interventions=interventionService.getInterventionsByCreatorId(new Guid(userId));


            ListIntervention.DataSource = interventions;
            ListIntervention.DataBind();
        }
    }
}