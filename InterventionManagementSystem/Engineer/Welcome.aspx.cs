using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionManagementSystem
{
    public partial class Welcome : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Redirect to specific page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CreateClientButton_Click(Object sender, EventArgs e)
        {
            Response.Redirect("~/Engineer/NewClient.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            Response.Redirect("~/Account/Login.aspx");
        }

        protected void ViewClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Engineer/ClientList.aspx");
        }

        protected void ViewIntervention_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Engineer/NewIntervention.aspx");
        }

        protected void CreateIntervention_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Engineer/NewIntervention.aspx");
        }
    }
}