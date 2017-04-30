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
            managerService = new ManagerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
            managerDetail = managerService.getDetail();

            if (!IsPostBack)
            {
                SeletedInterventionState.Items.Add(new ListItem(InterventionState.Proposed.ToString(), ((int)InterventionState.Proposed).ToString()));
                SeletedInterventionState.Items.Add(new ListItem(InterventionState.Approved.ToString(), ((int)InterventionState.Approved).ToString()));
                SeletedInterventionState.SelectedIndex = (int)InterventionState.Proposed;
                
                interventionsList = managerService.getInterventionsByState(InterventionState.Proposed);
                InterventionListView.DataSource = interventionsList;
                InterventionListView.DataBind();
            }
        }

        public List<Intervention> getInterventionList()
        {
            return null;
        }

        public User getManagerDetail()
        {
            return managerDetail;
        }

        protected void SeletedInterventionState_SelectedIndexChanged(object sender, EventArgs e)
        {
            var state = (InterventionState)SeletedInterventionState.SelectedIndex;
            if(state == InterventionState.Proposed)
                interventionsList = managerService.getInterventionsByState(state);
            if (state == InterventionState.Approved)
                interventionsList = managerService.getApprovedInterventions();

            InterventionListView.DataSource = interventionsList;
            InterventionListView.DataBind();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            managerService.approveAnIntervention(new Guid(button.CommandArgument));
            SeletedInterventionState_SelectedIndexChanged(sender, e);
        }

        public bool canApprove(object interventionId)
        {
            var intervention = managerService.getInterventionById((Guid)interventionId);
            return intervention.InterventionState == InterventionState.Proposed &&
                intervention.Costs <= managerDetail.AuthorisedCosts &&
                intervention.Hours <= managerDetail.AuthorisedHours;
        }

        public User getDetail()
        {
            return managerDetail;
        }
    }
}