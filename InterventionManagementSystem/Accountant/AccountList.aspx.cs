using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSDBLayer.DataModels;
using IMSLogicLayer.ServiceInterfaces;
using IMSLogicLayer.Services;

namespace InterventionManagementSystem.Accountant
{
    public partial class AccountList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccountantService accountantService = new AccountantService("");
            //IAccountantService accountantServuce = new AccountantService();
            ListViewEngineer.DataSource = accountantService.getAllSiteEngineer();
            ListViewEngineer.DataBind();

            ListViewManager.DataSource = accountantService.getAllManger();
            ListViewManager.DataBind();
        }
    }
}