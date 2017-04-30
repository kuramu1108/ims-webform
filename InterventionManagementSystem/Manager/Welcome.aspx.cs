using IMSLogicLayer.Models;
using IMSLogicLayer.ServiceInterfaces;
using IMSLogicLayer.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionManagementSystem.Manager
{
    public partial class Welcome : System.Web.UI.Page
    {
        private IManagerService managerService;
        private User managerDetail;

        protected void Page_Load(object sender, EventArgs e)
        {
            managerService = new ManagerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
            managerDetail = managerService.getDetail();
        }

        public User getDetail()
        {
            return managerDetail;
        }
    }
}