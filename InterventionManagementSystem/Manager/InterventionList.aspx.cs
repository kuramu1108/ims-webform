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

namespace InterventionManagementSystem.Manager
{
    public partial class InterventionList : System.Web.UI.Page
    {
        private IManagerService managerService;
        private IEnumerable<Intervention> interventionsList;
        private User managerDetail;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Instantiate a new instance of manager service
            managerService = new ManagerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
            managerDetail = managerService.GetDetail();

            if (!IsPostBack)
            {
                //Fill the intervention-state dropdown list items
                SeletedInterventionState.Items.Add(new ListItem(InterventionState.Proposed.ToString(), ((int)InterventionState.Proposed).ToString()));
                SeletedInterventionState.Items.Add(new ListItem(InterventionState.Approved.ToString(), ((int)InterventionState.Approved).ToString()));
                SeletedInterventionState.SelectedIndex = (int)InterventionState.Proposed;
                //Show all proposed interventions that the manager can approve
                interventionsList = managerService.GetInterventionsByState(InterventionState.Proposed);
                InterventionListView.DataSource = interventionsList;
                InterventionListView.DataBind();
            }
        }

        public List<Intervention> GetInterventionList()
        {
            return null;
        }

        public User GetManagerDetail()
        {
            return managerDetail;
        }
        /// <summary>
        /// Show corresonponding interventions when the index of intervention state changed
        protected void SeletedInterventionState_SelectedIndexChanged(object sender, EventArgs e)
        {
            var state = (InterventionState)SeletedInterventionState.SelectedIndex;
            if(state == InterventionState.Proposed)
                interventionsList = managerService.GetInterventionsByState(state);
            if (state == InterventionState.Approved)
                interventionsList = managerService.GetApprovedInterventions();

            InterventionListView.DataSource = interventionsList;
            InterventionListView.DataBind();
        }
        /// <summary>
        /// Approve selected intervention
        protected void BtnApprove_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            managerService.ApproveAnIntervention(new Guid(button.CommandArgument));
            SeletedInterventionState_SelectedIndexChanged(sender, e);
        }
        /// <summary>
        /// If the intervention's state is proposed and the costs, hours of the intervention
        /// are within the manager's authorised value, then the approve button is enabled,
        /// else the button is disabled.
        /// </summary>
        /// <param name="interventionId">The Id of an intervention</param>
        /// <returns>bool value</returns>
        public bool CanApprove(object interventionId)
        {
            var intervention = managerService.GetInterventionById((Guid)interventionId);
            return intervention.InterventionState == InterventionState.Proposed &&
                intervention.Costs <= managerDetail.AuthorisedCosts &&
                intervention.Hours <= managerDetail.AuthorisedHours;
        }

        public User GetDetail()
        {
            return managerDetail;
        }
    }
}