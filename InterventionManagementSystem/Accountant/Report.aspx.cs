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
                accountantService = new AccountantService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());

                if (!String.IsNullOrEmpty(Request.QueryString["Name"]))
                {
                    ReportType reportType = (ReportType)Enum.Parse(typeof(ReportType), Request.QueryString["Name"].ToString());
                    var report = new List<ReportRow>();
                    if (reportType == ReportType.AverageCostByEngineer)
                    {
                        report = accountantService.printAverageCostByEngineer().ToList();
                    }
                    else if (reportType == ReportType.MonthlyCostByDistrict)
                    {
                        //report = accountantService.printMonthlyCostByDistrict().ToList();
                        Response.Redirect("~/Accountant/MonthlyReport.aspx");
                    }
                    else if (reportType == ReportType.TotalCostByDistrict)
                    {
                        report = accountantService.printTotalCostByDistrict().ToList();
                    }
                    else if (reportType == ReportType.TotalCostByEngineer)
                    {
                        report = accountantService.printTotalCostByEngineer().ToList();
                    }

                    ReportListView.DataSource = report;
                    ReportListView.DataBind();


                }
            }
            catch (Exception)
            {
                throw;
                //Response.Redirect("~/Errors/InternalErrors.aspx");
            }
           



        }
    }
}