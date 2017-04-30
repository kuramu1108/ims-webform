using IMSLogicLayer.Enums;
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
    
    public partial class ChangeState : System.Web.UI.Page
    {
        private IEngineerService engineerService;

        private Intervention intervention;
        protected void Page_Load(object sender, EventArgs e)
        {
            engineerService = new EngineerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
            intervention = engineerService.getInterventionById(new Guid(Request.QueryString["Id"]));

            type.Text = engineerService.getInterventionTypes().Find(i => i.Id == intervention.InterventionTypeId).Name;
            client.Text = engineerService.getClientById(intervention.ClientId).Name;
            creator.Text = engineerService.getUserById(intervention.CreatedBy).Name;

           
            State.DataSource = getInterventionState();
            State.DataBind();
            
        }

        public List<InterventionState> getInterventionState()
        {
            List<InterventionState> state = new List<InterventionState>()
            { InterventionState.Proposed,
                InterventionState.Approved,
                InterventionState.Completed,
                InterventionState.Cancelled
            };
            return state;
        }

        protected void Submit_btn_Click(object sender, EventArgs e)
        {
            
            try
            {
               bool success=  engineerService.updateInterventionState(intervention.Id,(InterventionState)State.SelectedIndex);

                if (success)
                {
                    Response.Redirect("~/Engineer/Welcome.aspx");
                }else
                {
                    //Response.Redirect("~/InternalError.aspx");
                }

            }
            catch (Exception)
            {

                //Response.Redirect("~/InternalError.aspx");
                throw;
            }
          
        }

        protected void Cancel_btn_Click(object sender, EventArgs e)
        {

        }
    }
}