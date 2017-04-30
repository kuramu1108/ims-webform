using IMSLogicLayer.Enums;
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
    public partial class Report : System.Web.UI.Page
    {
        IAccountantService accountantService;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //instantiate a new instance of accountant Service
                accountantService = new AccountantService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());

                if (!String.IsNullOrEmpty(Request.QueryString["Name"]))
                {
                    //get report type from query string
                    ReportType reportType = (ReportType)Enum.Parse(typeof(ReportType), Request.QueryString["Name"].ToString());
                    var report = new List<ReportRow>();

                    //get report rows from accountant service
                    //format average to 2 place decimal
                    if (reportType == ReportType.AverageCostByEngineer)
                    {
                        report = accountantService.printAverageCostByEngineer().ToList();
                        foreach (var reportrow in report)
                        {
                            reportrow.Hours= decimal.Round(reportrow.Hours, 2, MidpointRounding.AwayFromZero);
                            reportrow.Costs = decimal.Round(reportrow.Costs, 2, MidpointRounding.AwayFromZero);
                        }
                    }
                    //if report is monthly cost by district redirect to monthly report page
                    else if (reportType == ReportType.MonthlyCostByDistrict)
                    {
                        
                        Response.Redirect("~/Accountant/MonthlyReport.aspx",false);
                    }
                    else if (reportType == ReportType.TotalCostByDistrict)
                    {
                        report = accountantService.printTotalCostByDistrict().ToList();
                    }
                    else if (reportType == ReportType.TotalCostByEngineer)
                    {
                        report = accountantService.printTotalCostByEngineer().ToList();
                    }

                    //Data bind report row with UI

                    ReportListView.DataSource = report;
                    ReportListView.DataBind();


                }
            }
            catch (Exception)
            {
                
                Response.Redirect("~/Errors/InternalErrors.aspx",true);
            }
           



        }
    }
}