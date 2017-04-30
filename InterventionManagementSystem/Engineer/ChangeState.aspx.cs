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
            try
            {
                engineerService = new EngineerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());

                if (!IsPostBack)
                {
                    //if the query string is not null process, else go to the homepage
                    if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                    {
                        //instantiate a new instance of engineer service
                      
                        //instantiate a new instance of engineer service
                        intervention = engineerService.getInterventionById(new Guid(Request.QueryString["Id"]));


                        //Data bind UI with intervention details
                        type.Text = engineerService.getInterventionTypes().Find(i => i.Id == intervention.InterventionTypeId).Name;
                        client.Text = engineerService.getClientById(intervention.ClientId).Name;
                        creator.Text = engineerService.getUserById(intervention.CreatedBy).Name;

                        State.SelectedIndex = (int)intervention.InterventionState;
                        State.DataSource = getInterventionState();
                        State.DataBind();
                    }
                    else
                    {
                        Response.Redirect("~/Engineer/Welcome.aspx",false);
                    }
                }
            }
            catch (Exception)
            {

                Response.Redirect("~/Errors/InternalErrors.aspx",false);
            }
           
           
          
            
        }
        /// <summary>
        /// get a list of intervention state made from enum
        /// </summary>
        /// <returns>a list of intervention state</returns>
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
        /// <summary>
        /// update the state of the intervention using engineer service
        /// if success redirect to homepage
        /// else display error message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Submit_btn_Click(object sender, EventArgs e)
        {
            
            try
            {
               bool success=  engineerService.updateInterventionState(new Guid(Request.QueryString["Id"]), (InterventionState)State.SelectedIndex);

                if (success)
                {
                    Response.Redirect("~/Engineer/Welcome.aspx",false);
                }else
                {
                    errorMessage.Text = "Update Failed, this can be one of the following reasons"+" <br />" +
                        " You are not authorized to change this intervention state or" + " <br />"+
                        " The state selected is invalid" + " <br />";
                    //Response.Redirect("~/InternalError.aspx");
                }

            }
            catch (Exception)
            {

                Response.Redirect("~/Errors/InternalErrors.aspx",true);
        
            }
          
        }
        /// <summary>
        /// redirect to home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Cancel_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Engineer/Welcome.aspx",true);
        }
    }
}