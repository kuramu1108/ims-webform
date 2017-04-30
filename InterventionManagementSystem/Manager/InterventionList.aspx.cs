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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                managerService = new ManagerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
                interventionsList = new List<Intervention>();
                InterventionListView.DataSource = interventionsList;
                InterventionListView.DataBind();
            }

            interventionsList = managerService.getListOfProposedIntervention();
        }

        public List<Intervention> getInterventionList()
        {
            return null;
        }
    }
}