﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            Response.Redirect("~/SiteEngineer/NewClient");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {

        }
    }
}