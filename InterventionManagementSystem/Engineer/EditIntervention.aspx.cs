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
            //Instantiate a new instance of engineer service
            engineerService = new EngineerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());


            if (!IsPostBack)
            {
                //if the query string is not null process, else go to the homepage
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    
                    interventionId = new Guid(Request.QueryString["Id"]);
                    try
                    {
                        //get intervention from engineer service by using the query string
                        Intervention intervention = engineerService.getInterventionById(interventionId);

                        //Data bind the UI with intervention quality information
                        txtInterventionType.Text = engineerService.getInterventionTypes().Find(i => i.Id == intervention.InterventionTypeId).Name;
                        ClientName.Text = engineerService.getClients().First(c => c.Id == intervention.ClientId).Name;
                        InterventionComments.Text = intervention.Comments;

                        LifeRemaining.Text = intervention.LifeRemaining.ToString();
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                        InterventionVisitDate.Text = intervention.DateRecentVisit.ToShortDateString();
                    }
                    catch (Exception)
                    {

                        Response.Redirect("~/Errors/InternalErrors.aspx",true);
                    }

                }else
                {
                    Response.Redirect("~/Engineer/Welcome.aspx",false);
                }
            }
          

        }
        /// <summary>
        /// update the quality information of an intervention by using engieer service
        /// if update success redirect to intervention detail page
        /// else redirect to error page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                //parse date format to dd/mm/yyyy
                DateTime date = DateTime.Parse(InterventionVisitDate.Text, new CultureInfo("de-DE"));
                Guid interventionId = new Guid(Request.QueryString["Id"]);
              
                bool updateDetails = engineerService.updateInterventionDetail(interventionId, InterventionComments.Text, Int32.Parse(LifeRemaining.Text), date);

                //if update success redirect to intervention detail page
                if (updateDetails==true)
                {
                    Response.Redirect("~/Engineer/InterventionDetail.aspx",false);
                }
            }
            catch (Exception)
            {

                Response.Redirect("~/Errors/InternalErrors.aspx",true);
            }
            
            
        }
        /// <summary>
        /// Redirect back to the intervention detail page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Engineer/InterventionDetail.aspx",true);
        }
    }
}