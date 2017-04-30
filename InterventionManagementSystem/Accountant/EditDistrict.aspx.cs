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
                //instantiate a new instance of account service
                accountService = new AccountantService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
                //instantiate a new instance of district service
                districtService = new DistrictService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                if (!IsPostBack)
                {
                    //if query string is not null then process else return to home page
                    if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                    {
                        //get user from account service using query string id
                        var user = accountService.getUserById(new Guid(Request.QueryString["Id"]));

                        //data bind ui with user details
                        txtUser.Text = user.Name;
                        txtDistrict.Text = districtService.GetDistrictById(user.DistrictId).Name;

                    }else
                    {
                        Response.Redirect("~/Accountant/Welcome.aspx");
                    }

                }
            }
            catch (Exception)
            {

                Response.Redirect("~/Errors/InternalErrors.aspx");
            }
           
               
        }
        /// <summary>
        /// get a list of districts using districtService
        /// </summary>
        /// <returns>A list of district in the system</returns>
        public List<District> getDistricts()
        {
            try
            {
                //instantiate a new instance of district service
                IDistrictService districtService = new DistrictService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                //get all district in the system using district service
                var districts = districtService.GetAllDistrict().ToList();

                return districts;
            }
            catch (Exception)
            {

                Response.Redirect("~/Errors/InternalErrors.aspx");
                return null;
            }
            
        }
        /// <summary>
        /// Change district of the user using accountant service 
        /// using query string as user id
        /// get district id from user selection
        /// if success redirect to account list
        /// else display error message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Guid userId = new Guid(Request.QueryString["Id"]);
                Guid districtId = new Guid(DropDownDistrict.SelectedItem.Value);

                bool success = accountService.changeDistrict(userId, districtId);
                if (success)
                {
                    Response.Redirect("~/Accountant/AccountList.aspx",false);
                }else

                {
                    errorMessage.Text = "Update Failed! The selected District is no valid";
                }
            }
            catch (Exception ex)
            {

                Response.Redirect("~/Errors/InternalErrors.aspx",false);
            }
        }
        /// <summary>
        /// redirect to account list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Accountant/AccountList.aspx");
        }
    }
}