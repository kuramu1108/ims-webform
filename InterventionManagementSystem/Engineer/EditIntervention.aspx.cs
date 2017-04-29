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

namespace InterventionManagementSystem
{
    public partial class EditIntervention : System.Web.UI.Page
    {
        private IEngineerService engineerService;
        private Guid interventionId;
        protected void Page_Load(object sender, EventArgs e)
        {
            engineerService = new EngineerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());

            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
              
                interventionId =new Guid(Request.QueryString["Id"]);

                Intervention intervention = engineerService.getInterventionById(interventionId);

                txtInterventionType.Text = engineerService.getInterventionTypes().Find(i => i.Id == intervention.InterventionTypeId).Name;
                ClientName.Text = engineerService.getClients().First(c => c.Id == intervention.ClientId).Name;
                InterventionComments.Text = intervention.Comments;
               
                LifeRemaining.Text =intervention.LifeRemaining.ToString();
                Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                InterventionVisitDate.Text = intervention.DateRecentVisit.ToShortDateString();



            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                bool updateDetails = engineerService.updateInterventionDetail(interventionId, InterventionComments.Text, Int32.Parse(LifeRemaining.Text));

                bool updateLastVisit = engineerService.updateInterventionLastVisitDate(interventionId, DateTime.Parse(InterventionVisitDate.Text));

                if (updateDetails==true && updateLastVisit==true)
                {
                    Response.Redirect("~/Engineer/InterventionDetail.aspx");
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Engineer/InterventionDetail.aspx");
        }
    }
}