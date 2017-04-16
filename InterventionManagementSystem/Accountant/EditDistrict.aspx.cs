using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSDBLayer.DataModels;
using IMSLogicLayer.FakeServices;
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
            accountService = new FakeAccountantService();
            //accountService = new AccountantService();

            if (Request.QueryString["id"] != null)
            {
                Guid userId = new Guid(Request.QueryString["id"]);
                user = accountService.getUserById(userId);
                if (user != null)
                {
                    lblUser.Text = user.Name;
                    lblCurrentDistrict.Text = user.DistrictId.ToString();
                }
            }
            btnSubmit.Click += BtnSubmit_Click;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string selectedValue = DropDownDistrict.SelectedValue;
            Guid selectedDistrictId = new Guid(selectedValue);
            accountService.changeDistrict(user.Id, selectedDistrictId);
        }
    }
}