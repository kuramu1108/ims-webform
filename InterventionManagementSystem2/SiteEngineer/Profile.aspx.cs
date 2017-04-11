using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSLogic;
using IMSDBLayer;

namespace InterventionManagementSystem2
{
    public partial class Profile : System.Web.UI.Page
    {
        private Manager user;
        protected void Page_Load(object sender, EventArgs e)
        {
            ButtonChangePassword.Click += ButtonChangePassword_Click;
            user = new Manager(1, "Po", "kuramu1108", Support.convertToSS("12345"), Common.UserType.Manager, Common.Districts.RuralIndonesia, 10, 10000);
            TextDistrict.Text = Common.Districts.RuralIndonesia.ToString();
            TextMAH.Text = user.AuthorisedHour.ToString();
            TextMAC.Text = user.AuthorisedCost.ToString();

        }

        protected void ButtonChangePassword_Click(object sender, EventArgs e)
        {
            string current = ButtonChangePassword.Text;
            const string BT_CHANGEPASSWORD = "Change Password";
            const string BT_SUBMIT = "Submit";
            const string BT_TRYAGAIN = "current password mismatch, try again";
            if (current != BT_SUBMIT)
            {
                LabelOldPassword.Visible = true;
                TextBoxOldPassword.Visible = true;
                LabelNewPassword.Visible = true;
                TextBoxNewPassword.Visible = true;
                ButtonChangePassword.Text = BT_SUBMIT;
            }
            else
            {
                String oldPassword = TextBoxOldPassword.Text;
                String newPassword = TextBoxNewPassword.Text;

                if(user.changePassword(Support.convertToSS(oldPassword), Support.convertToSS(newPassword)))
                {
                    LabelOldPassword.Visible = false;
                    TextBoxOldPassword.Visible = false;
                    LabelNewPassword.Visible = false;
                    TextBoxNewPassword.Visible = false;
                    ButtonChangePassword.Text = BT_CHANGEPASSWORD;
                } else
                {
                    TextBoxOldPassword.Text = "";
                    TextBoxNewPassword.Text = "";
                    ButtonChangePassword.Text = BT_TRYAGAIN;
                }
                
            }
        }

    }
}