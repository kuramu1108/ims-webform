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
        /// <summary>
        /// redirect to account list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ViewAccountList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Accountant/AccountList.aspx",true);
        }
        /// <summary>
        /// redirect to report list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ViewReportList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Accountant/ReportList.aspx",true);
        } 
    }
}