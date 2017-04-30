using IMSLogicLayer.Models;
using System;
using System.Web.UI;
using IMSLogicLayer.ServiceInterfaces;
using IMSLogicLayer.Services;
using System.Web.Security;
using System.Web;
using Microsoft.AspNet.Identity;

namespace InterventionManagementSystem
{

    public partial class NewClient : Page
    {
        private IEngineerService engineerService;
        protected void Page_Load(object sender, EventArgs e)
        {
            engineerService = new EngineerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
            if (!IsPostBack)
            {

            }
            else
            {

            }
        }

        protected void Submit_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Client client = engineerService.createClient(ClientName.Text, Clientlocation.Text);
                if (client != null)
                {
                    //Response.Redirect("ClientDetails.aspx?ClientId=" + client.Id);
                    Response.Redirect("ClientList.aspx");
                }
                else
                {
                    // give creation failed feedback to user
                    ClientScript.RegisterStartupScript(GetType(), "N", "alert('Creation failed!');", true);
                }
            }
            catch (Exception)
            {

                Response.Redirect("~/Errors/InternalErrors.aspx");
            }
         
        }

        protected void Cancel_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Engineer/Welcome.aspx");
        }

        protected User getDetail()
        {
            return engineerService.getDetail();
        }
    }

}

