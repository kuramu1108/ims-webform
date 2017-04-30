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
            try
            {
                //instantiate a new instance of accountant service
                accountantService = new AccountantService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());

                //get a list of engineers using accountant service
                //data bind the engineers details with ui
                EngineerListView.DataSource = accountantService.getAllSiteEngineer();
                EngineerListView.DataBind();

                //get a list of manager using accountant service
                //data bind the manager details with ui
                ManagerListView.DataSource = accountantService.getAllManger();
                ManagerListView.DataBind();
            }
            catch (Exception)
            {

                Response.Redirect("~/Errors/InternalErrors.aspx");
            }
           
        }
    }
}