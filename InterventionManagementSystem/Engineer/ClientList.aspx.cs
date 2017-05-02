using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSLogicLayer.Models;
using IMSLogicLayer.Services;
using IMSLogicLayer.ServiceInterfaces;
using Microsoft.AspNet.Identity;

namespace InterventionManagementSystem.Engineer
{
    public partial class ClientList : System.Web.UI.Page
    {
        private IEngineerService engineerService;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //instantiate a new instance of engineer service
                //get all clients from engineer service and data bind them to UI
                engineerService = new EngineerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
                if (!IsPostBack)
                {
                    ClientListView.DataSource = engineerService.getClients();
                    ClientListView.DataBind();
                }
            }
            catch (Exception)
            {

                Response.Redirect("~/Errors/InternalErrors.aspx",true);
            }

           
            
        }
        /// <summary>
        /// get the current user
        /// </summary>
        /// <returns>The current engineer</returns>
        protected User GetDetail()
        {
            return engineerService.getDetail();
        }
    }
}