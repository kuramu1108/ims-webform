using IMSLogicLayer.FakeServices;
using IMSLogicLayer.Models;
using IMSLogicLayer.Services;
using Microsoft.AspNet.Identity;
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
            //String Userid = Request.QueryString["Loginuser"];
        //    District District= Context.User.Identity.GetUserDistrict();
            FakeEngineerService es = new FakeEngineerService();
            Client client = new Client(ClientName.Text, Clientlocation.Text, System.Guid.NewGuid());
            if (es.createClient(ClientName.Text, Clientlocation.Text) != null) {
                // give creation succeed feedback to user
               // ClientScript.RegisterStartupScript(GetType(), "Y", "alert('Creation succeed!');", true);
                Response.Redirect("ClientDetails.aspx?ClientId="+client.Id);
            }
            else
            {
                // give creation failed feedback to user
                ClientScript.RegisterStartupScript(GetType(), "N", "alert('Creation failed!');", true);
            }
        }

        protected void Cancel_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }
    }

}

