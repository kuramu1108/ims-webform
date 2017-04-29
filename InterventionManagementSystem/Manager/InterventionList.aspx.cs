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
                Array states = Enum.GetValues(typeof(InterventionState));
                foreach (var state in states)
                {
                    SeletedInterventionState.Items.Add(new ListItem(state.ToString(), ((int)state).ToString()));
                }
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
            interventionsList = managerService.getInterventionsByState(state);
            InterventionListView.DataSource = interventionsList;
            InterventionListView.DataBind();
        }

        protected void ButtonView_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.CommandArgument = "";
        }
    }
}