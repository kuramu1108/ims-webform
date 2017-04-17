using IMSLogicLayer.FakeServices;
using IMSLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionManagementSystem
{
    public partial class NewClient : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            else
            {
              
            }
        }

        protected void Submit_btn_Click(object sender, EventArgs e)
        {
            FakeEngineerService es = new FakeEngineerService();

            if (es.createClient(ClientName.Text, Clientlocation.Text) != null) {
                // give creation succeed feedback to user
            }
            else
            {
                // give creation failed feedback to user
            }
        }

        protected void Cancel_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }
    }
}