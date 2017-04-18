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

        protected void CreateClientButton_Click(Object sender, EventArgs e)
        {
            //  Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
         //   String Loginuser=Context.User.Identity.GetUserId();
      
            Response.Redirect("~/Engineer/NewClient");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            Response.Redirect("~/Account/Login.aspx");
        }

        protected void ViewClient_Click(object sender, EventArgs e)
        {

        }
    }
}