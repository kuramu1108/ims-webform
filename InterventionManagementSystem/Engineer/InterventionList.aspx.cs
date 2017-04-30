using IMSLogicLayer.Models;
using IMSLogicLayer.ServiceInterfaces;
using IMSLogicLayer.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionManagementSystem.Engineer
{
    public partial class InterventionList : System.Web.UI.Page
    {
        private IEngineerService engineerService;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //instantiate a new instance of engineer service
                engineerService = new EngineerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
                if (!IsPostBack)
                {
                    //call engineer service to get a list of interventions created by this engineer and then bind them to UIs
                    List<Intervention> interventions = engineerService.getInterventionListByCreator(getDetail().Id).ToList();
                    foreach (var intervention in interventions)
                    {
                        intervention.InterventionType = engineerService.getInterventionTypes().Find(it => it.Id == intervention.InterventionTypeId);
                    }

                    ListofIntervention.DataSource = interventions;
                    ListofIntervention.DataBind();

                }
            }
            catch (Exception)
            {

                Response.Redirect("~/Errors/InternalErrors.aspx",true);
            }
            
        }
        /// <summary>
        /// Function to get the detail of the current user
        /// </summary>
        /// <returns>The current engineer</returns>
        protected User getDetail()
        {
            return engineerService.getDetail();
        }
    }
}