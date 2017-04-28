using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSLogicLayer.Models;
using IMSLogicLayer.Services;
using IMSLogicLayer.ServiceInterfaces;
using Microsoft.AspNet.Identity;

namespace InterventionManagementSystem.Engineer
{
    public partial class ClientList : System.Web.UI.Page
    {
        private IEngineerService engineerService = new EngineerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = User.Identity.GetUserId<string>();
            engineerService.EngineerId = new Guid(userId);

            ClientListView.DataSource = engineerService.getClients();
            ClientListView.DataBind();
        }

        protected User getDetail()
        {
            return engineerService.getDetail();
        }
    }
}