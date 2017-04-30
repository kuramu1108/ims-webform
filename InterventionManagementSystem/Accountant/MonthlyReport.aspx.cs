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

namespace InterventionManagementSystem.Accountant
{
    public partial class MonthlyReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Get a list of district from the system using district service
        /// </summary>
        /// <returns></returns>
        public List<District> getDistricts()
        {
            try
            {
                //instantiate a new instance of district service
                IDistrictService districtService = new DistrictService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                //get a list of districts
                var districts = districtService.GetAllDistrict().ToList();

                return districts;
            }
            catch (Exception)
            {

                Response.Redirect("~/Errors/InternalErrors.aspx",false);
                return null;

            }
            
        }
        /// <summary>
        /// get report from accountant service and data bind them to UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //instantiate a new instance of accountant service
                IAccountantService accountantService = new AccountantService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());

                //get report for district selected by user
                var report = accountantService.printMonthlyCostByDistrict(new Guid(DropDownDistrict.SelectedValue)).ToList();
                ReportListView.DataSource = report;
                ReportListView.DataBind();
            }
            catch (Exception)
            {

               Response.Redirect("~/Errors/InternalErrors.aspx",true);
            }

            

            


        }
    }
}