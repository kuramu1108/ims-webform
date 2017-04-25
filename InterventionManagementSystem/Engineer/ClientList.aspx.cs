using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSLogicLayer.Models;
using IMSLogicLayer.Services;
using IMSLogicLayer.FakeServices;
using IMSLogicLayer.ServiceInterfaces;


namespace InterventionManagementSystem.Engineer
{
    public partial class ClientList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IEngineerService engineerService = new IMSLogicLayer.FakeServices.EngineerService("");
            //IEngineerService engineerService = new EngineerService();
            ClientListView.DataSource = engineerService.getClients();
            ClientListView.DataBind();
        }
    }
}