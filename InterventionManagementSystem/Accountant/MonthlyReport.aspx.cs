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

        public List<District> getDistricts()
        {
            try
            {
                IDistrictService districtService = new DistrictService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                var districts = districtService.GetAllDistrict().ToList();

                return districts;
            }
            catch (Exception)
            {

                //Response.Redirect("~/Errors/InternalErrors.aspx");
                return null;

            }
            
        }

        protected void DropDownDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                IAccountantService accountantService = new AccountantService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
                var report = accountantService.printMonthlyCostByDistrict(new Guid(DropDownDistrict.SelectedValue)).ToList();
                ReportListView.DataSource = report;
                ReportListView.DataBind();
            }
            catch (Exception)
            {

               // Response.Redirect("~/Errors/InternalErrors.aspx");
            }

            

            


        }
    }
}