using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionManagementSystem.Accountant
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ViewAccountList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Accountant/AccountList.aspx");
        }

        protected void ViewReportList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Accountant/ReportList.aspx");
        } 
    }
}