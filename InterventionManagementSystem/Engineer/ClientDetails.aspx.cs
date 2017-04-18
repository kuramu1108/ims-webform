using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSDBLayer;
using IMSLogicLayer;
using IMSDBLayer.DataModels;

namespace InterventionManagementSystem
{
    public partial class ClientDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
              
            }
            else
            {
               
            }


            //Client client = new Client(1, "John Smith", "123 Happy St", Common.Districts.RuralPapuaNewGuinea);

            //lblName.Text = client.clientDM.Name;
            //lblLocation.Text = client.clientDM.Location;
            //lblDistrict.Text = client.clientDM.District.ToString();

            List<string> TestData = new List<string>()
            {
                    "Supply and Install Portable Toilet",
                    "Hepatitis Avoidance Training",
                    "Supply and Install Storm-proof Home Kit"
            };

            InterventionList.DataSource = TestData;
            InterventionList.DataBind();


        }

       
    }
}