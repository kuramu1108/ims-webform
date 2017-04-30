using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSLogicLayer.ServiceInterfaces;
using IMSLogicLayer.Services;
using Microsoft.AspNet.Identity;

namespace InterventionManagementSystem.Accountant
{
    public partial class AccountList : System.Web.UI.Page
    {
        private IAccountantService accountantService;
        protected void Page_Load(object sender, EventArgs e)
        {
            accountantService = new AccountantService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
           
            
            EngineerListView.DataSource = accountantService.getAllSiteEngineer();
            EngineerListView.DataBind();

            ManagerListView.DataSource = accountantService.getAllManger();
            ManagerListView.DataBind();
        }
    }
}