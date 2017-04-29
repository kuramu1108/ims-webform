using IMSLogicLayer.Models;
using IMSLogicLayer.ServiceInterfaces;
using IMSLogicLayer.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionManagementSystem.Engineer
{
    public partial class InterventionDetail : System.Web.UI.Page
    {
        private IEngineerService engineerService;

        private Intervention intervention;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                engineerService = new EngineerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
                intervention = engineerService.getInterventionById(new Guid(Request.QueryString["Id"]));

                type.Text = engineerService.getInterventionTypes().Find(i => i.Id == intervention.InterventionTypeId).Name;
                client.Text = engineerService.getClientById(intervention.ClientId).Name;
                creator.Text = engineerService.getUserById(intervention.CreatedBy).Name;
                if (intervention.ApprovedBy==null)
                {
                    approver.Text = "";
                }else
                {
                    approver.Text = engineerService.getUserById(intervention.ApprovedBy.Value).Name;
                }
                
                state.Text = intervention.InterventionState.ToString();

           

                hour.Text = intervention.Hours.ToString();
                cost.Text = intervention.Costs.ToString();

                Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");

                proposedDate.Text = intervention.DateCreate.ToShortDateString();
                completedDate.Text = intervention.DateFinish.ToShortDateString();
                recentVisitDate.Text = intervention.DateRecentVisit.ToShortDateString();
                lifeRemaining.Text = intervention.LifeRemaining.ToString() + "%";
                Comments.Text = intervention.Comments;

            }else
            {
                Response.Redirect("~/Engineer/Welcome.aspx");
            }




        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Engineer/EditIntervention.aspx?id=" + intervention.Id);
        }

        protected void changeState_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Engineer/ChangeState.aspx?id="+ intervention.Id);

        }
    }
}