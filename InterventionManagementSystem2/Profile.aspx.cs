using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSLogic;

namespace InterventionManagementSystem2
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ButtonChangePassword.Click += ButtonChangePassword_Click;
            
        }

        protected void ButtonChangePassword_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}