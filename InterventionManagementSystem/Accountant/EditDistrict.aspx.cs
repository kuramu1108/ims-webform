using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSLogicLayer.Models;
using IMSLogicLayer.ServiceInterfaces;
using IMSLogicLayer.Services;

namespace InterventionManagementSystem.Accountant
{
    public partial class EditDistrict : System.Web.UI.Page
    {
        IAccountantService accountService;
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                accountService = new AccountantService("");


                //accountService = new AccountantService();
                //real
                //if (!string.IsNullOrEmpty(Request.QueryString["Name"]))
                //{
                //    Guid userId = new Guid(Request.QueryString["id"]);
                //    user = accountService.getUserById(userId);
                //    if (user != null)
                //    {
                //        lblUser.Text = user.Name;
                //        lblCurrentDistrict.Text = user.DistrictId.ToString();
                //    }
                //}
                //btnSubmit.Click += BtnSubmit_Click;


                //demo code
                if (!string.IsNullOrEmpty(Request.QueryString["Name"]))
                {
                    string name = Request.QueryString["Name"];
                    List<User> users = accountService.getAllUser().ToList();
                    User user = users.Find(u => u.Name == name);
                    if (user != null)
                    {
                        lblUser.Text = user.Name;
                        lblCurrentDistrict.Text = user.DistrictId.ToString();
                    }

                }
                btnSubmit.Click += BtnSubmit_Click;
            }
               
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string selectedValue = DropDownDistrict.SelectedValue;
            Guid selectedDistrictId = new Guid(selectedValue);
            accountService.changeDistrict(user.Id, selectedDistrictId);
        }
    }
}