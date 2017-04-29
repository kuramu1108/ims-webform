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

namespace InterventionManagementSystem.Engineer
{
    public partial class InterventionList : System.Web.UI.Page
    {
        private IEngineerService engineerService;
        protected void Page_Load(object sender, EventArgs e)
        {
            engineerService = new EngineerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
            if (!IsPostBack)
            {
                List<Intervention> interventions = engineerService.getInterventionListByCreator(getDetail().Id).ToList();
                foreach (var intervention in interventions)
                {
                    intervention.InterventionType = engineerService.getInterventionTypes().Find(it => it.Id == intervention.InterventionTypeId);
                }

                ListofIntervention.DataSource = interventions;
                ListofIntervention.DataBind();

            }
        }

        protected User getDetail()
        {
            return engineerService.getDetail();
        }
    }
}