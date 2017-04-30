using IMSLogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionManagementSystem.Accountant
{
    public partial class ReportList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var reportType = getReportType();
                ReportListView.DataSource = reportType;
                ReportListView.DataBind();
            }
            catch (Exception)
            {

                Response.Redirect("~/Errors/InternalErrors.aspx");
            }
           
        }

        public List<string> getReportType()
        {
            return Enum.GetNames(typeof(ReportType)).ToList();
        }
        
    }
}