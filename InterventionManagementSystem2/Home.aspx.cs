using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionManagementSystem
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        //{
        //    //if (Validation(Login1.UserName, Login1.Password))
        //    //{
        //    //    // e.Authenticated = true;
        //    //    Login1.Visible = false;
        //    //    MessageLabel.Text = "Successfully Logged In";
        //    //}
        //    //else
        //    //{
        //    //    e.Authenticated = false;
        //    //}
        //}
        protected void Login1_LoginError(object sender, EventArgs e)
        {
            //if (ViewState["LoginErrors"] == null)
            //    ViewState["LoginErrors"] = 0;

            //int ErrorCount = (int)ViewState["LoginErrors"] + 1;
            //ViewState["LoginErrors"] = ErrorCount;

            //if ((ErrorCount > 3) && (Login1.PasswordRecoveryUrl != string.Empty))
            //    Response.Redirect(Login1.PasswordRecoveryUrl);
        }
        private bool Validation(string UserName, string Password)
        {
            bool boolReturnValue = false;
            //string strConnection = "server=.;database=Vendor;uid=sa;pwd=wintellect;";
            //SqlConnection sqlConnection = new SqlConnection(strConnection);
            //String SQLQuery = "SELECT UserName, Password FROM Login";
            //SqlCommand command = new SqlCommand(SQLQuery, sqlConnection);
            //SqlDataReader Dr;
            //sqlConnection.Open();
            //Dr = command.ExecuteReader();
            //while (Dr.Read())
            //{
            //    if ((UserName == Dr["UserName"].ToString()) & (Password == Dr["Password"].ToString()))
            //    {
            //        boolReturnValue = true;
            //    }
            //    Dr.Close();
            //    return boolReturnValue;
            //}
            return boolReturnValue;
        }
    }
}