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
            try
            {
                //if the query string is not null process, else go to the homepage
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    //Instantiate a new instance of engineer service
                    IEngineerService engineerService = new EngineerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
                    //Instantiate a new instance of district service
                    IDistrictService districtService = new DistrictService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                    Guid clientId = new Guid(Request.QueryString["Id"]);
                    //get client form engineer service
                    Client client = engineerService.getClientById(clientId);

                    //Data bind UI with client details
                    lblName.Text = client.Name;

                    lblDistrict.Text = districtService.GetDistrictById(client.DistrictId).Name;
                    lblLocation.Text = client.Location;

                    //get a list of interventions for the client
                    List<Intervention> clientIntervention = engineerService.getInterventionsByClient(clientId).ToList();

                    //Data bind UI with intervention details
                    foreach (var intervention in clientIntervention)
                    {
                        intervention.InterventionType = engineerService.getInterventionTypes().Find(it => it.Id == intervention.InterventionTypeId);
                    }

                    InterventionList.DataSource = clientIntervention;
                    InterventionList.DataBind();

                }
                else
                {
                    Response.Redirect("~/Engineer/Welcome.aspx");
                }
            }
            catch (Exception)
            {

                Response.Redirect("~/Errors/InternalErrors.aspx");
            }

          
            
        }


    }
}