using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSLogicLayer;
using IMSLogicLayer.Services;
using IMSLogicLayer.Models;
using IMSLogicLayer.ServiceInterfaces;
using Microsoft.AspNet.Identity;

namespace InterventionManagementSystem
{
    public partial class ClientDetails : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    IEngineerService engineerService = new EngineerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                    string userId = User.Identity.GetUserId<string>();
                    engineerService.EngineerId = new Guid(userId);

                    Guid clientId = new Guid(Request.QueryString["Id"]);
                    Client client = engineerService.getClientById(clientId);
                    lblName.Text = client.Name;

                    lblDistrict.Text = client.DistrictId.ToString();
                    lblLocation.Text = client.Location;
                    List<Intervention> clientIntervention = engineerService.getInterventionsByClient(clientId).ToList();


                    InterventionList.DataSource = clientIntervention;
                    InterventionList.DataBind();

                }



            }
          




            


        }

       
    }
}