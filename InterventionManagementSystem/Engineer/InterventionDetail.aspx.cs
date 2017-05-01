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
            //if the query string is not null process, else go to the homepage

            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                //instantiate a new instance of the engineer service
                engineerService = new EngineerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
                try
                {
                    //get the intervention by its id
                    intervention = engineerService.getInterventionById(new Guid(Request.QueryString["Id"]));

                    //Databind the UI with details of the intervention

                    type.Text = engineerService.getInterventionTypes().Find(i => i.Id == intervention.InterventionTypeId).Name;
                    client.Text = engineerService.getClientById(intervention.ClientId).Name;
                    creator.Text = engineerService.getUserById(intervention.CreatedBy).Name;
                    if (intervention.ApprovedBy == null)
                    {
                        approver.Text = "";
                    }
                    else
                    {
                        approver.Text = engineerService.getUserById(intervention.ApprovedBy.Value).Name;
                    }

                    state.Text = intervention.InterventionState.ToString();



                    hour.Text = intervention.Hours.ToString();
                    cost.Text = intervention.Costs.ToString();

                    Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");

                    proposedDate.Text = intervention.DateCreate.ToShortDateString();
                    if (intervention.DateFinish ==null)
                    {
                        completedDate.Text = "";
                    }else
                    {
                        completedDate.Text = intervention.DateFinish.Value.ToShortDateString();
                    }
                
                    recentVisitDate.Text = intervention.DateRecentVisit.ToShortDateString();
                    lifeRemaining.Text = intervention.LifeRemaining.ToString() + "%";
                    Comments.Text = intervention.Comments;
                }
                catch (Exception)
                {

                    Response.Redirect("~/Errors/InternalErrors.aspx",true);
                }
                


            }else
            {
                Response.Redirect("~/Engineer/Welcome.aspx",true);
            }




        }
        /// <summary>
        /// Redirect to edit intervention page with query string id to 
        /// modify quality information of an intervention
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Engineer/EditIntervention.aspx?id=" + Request.QueryString["Id"], true);
        }
        /// <summary>
        /// Redirect to change state page with query string to process state of an intervention
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void changeState_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Engineer/ChangeState.aspx?id="+ Request.QueryString["Id"], true);

        }
    }
}