using IMSLogicLayer.Models;
using IMSLogicLayer.ServiceInterfaces;
using IMSLogicLayer.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionManagementSystem
{
    public partial class NewIntervention : System.Web.UI.Page
    {
        private IEngineerService engineerService;

        protected void Page_Load(object sender, EventArgs e)
        {
            engineerService = new EngineerService(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {

        }

        public List<InterventionType> getInterventionTypes()
        {
            return engineerService.getInterventionTypes();
        }
    }
}