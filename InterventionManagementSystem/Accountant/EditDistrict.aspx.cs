using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSLogicLayer.Models;
using IMSLogicLayer.ServiceInterfaces;
using IMSLogicLayer.Services;
using Microsoft.AspNet.Identity;

namespace InterventionManagementSystem.Accountant
{
    public partial class EditDistrict : System.Web.UI.Page
    {
        private IAccountantService accountService;
        private IDistrictService districtService;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                accountService = new AccountantService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
                districtService = new DistrictService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                    {
                        var user = accountService.getUserById(new Guid(Request.QueryString["Id"]));
                        txtUser.Text = user.Name;
                        txtDistrict.Text = districtService.GetDistrictById(user.DistrictId).Name;

                    }

                }
            }
            catch (Exception)
            {

                Response.Redirect("~/Errors/InternalErrors.aspx");
            }
           
               
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

                Response.Redirect("~/Errors/InternalErrors.aspx");
                return null;
            }
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Guid userId = new Guid(Request.QueryString["Id"]);
                Guid districtId = new Guid(DropDownDistrict.SelectedItem.Value);

                bool success = accountService.changeDistrict(userId, districtId);
                if (success)
                {
                    Response.Redirect("~/Accountant/AccountList.aspx");
                }else

                {

                }
            }
            catch (Exception)
            {

                Response.Redirect("~/Errors/InternalErrors.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Accountant/AccountList.aspx");
        }
    }
}