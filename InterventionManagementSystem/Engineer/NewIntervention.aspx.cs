//using IMSDBLayer.DataModels;
using IMSLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSLogicLayer;
using IMSLogicLayer.BusinessHandler;
using IMSLogicLayer.ServiceInterfaces;
using IMSLogicLayer.Services;
using Microsoft.AspNet.Identity;
using IMSLogicLayer.Enums;
using System.Globalization;

namespace InterventionManagementSystem
{
    public partial class NewIntervention : System.Web.UI.Page
    {

        IEngineerService engineerService=null;
        InterventionTypeService interventionTypeService = null;
        protected void Page_Load(object sender, EventArgs e)
        {

          //  if (!IsPostBack) {
            engineerService  = new EngineerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            interventionTypeService= new InterventionTypeService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //    }
            Creator.Text = User.Identity.GetUserName();
            DateTime localDate = DateTime.Now;
            Date.Text = localDate.ToString();
            Date_reccent_visit.Text= localDate.ToString();

  
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            decimal hours = Convert.ToDecimal(Hours.Text);
            decimal costs = Convert.ToDecimal(Cost.Text);
            int life_remaining = Int32.Parse(LifeRemaining.Text);
            string comments = Comments.Text;
            InterventionState state = Approval_check.Checked ? InterventionState.Approved : InterventionState.Proposed;
            DateTime date_created = DateTime.Parse(Date.Text);
            DateTime date_finish = DateTime.Now;
            DateTime dateRecentVisit = DateTime.Now;
            String intervention_type = interventionTypes.SelectedValue;
            //Fear 
            Guid interventionTypeId = interventionTypeService.getInterventionTypeId(interventionTypes.SelectedValue);
           // Guid clientId = new Guid();
              Guid clientId = new Guid(Clients.SelectedValue);
           //  Guid createdBy = new Guid();
              Guid createdBy = new Guid(User.Identity.GetUserName());
           // Guid approvedBy = new Guid();
             Guid approvedBy = new Guid(Approval_check.Checked ? InterventionState.Approved.ToString() : InterventionState.Proposed.ToString());

            Intervention new_intervention = new Intervention(hours,costs,life_remaining,comments,state, date_created, date_finish, dateRecentVisit, 
                interventionTypeId,clientId,createdBy,approvedBy);
            engineerService.createIntervention(new_intervention);



        }
   


    }
}