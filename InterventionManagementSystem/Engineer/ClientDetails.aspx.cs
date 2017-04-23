using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSLogicLayer;
using IMSLogicLayer.FakeServices;
using IMSLogicLayer.Models;

namespace InterventionManagementSystem
{
    public partial class ClientDetails : System.Web.UI.Page
    {
        FakeBaseService service = new FakeBaseService("");

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //real code
                //if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                //{
                //    Guid clientId = new Guid(Request.QueryString["Id"]);
                //    Client client = service.Clients.Find(c => c.Id == clientId);
                //    lblName.Text = client.Name;
                //    lblDistrict.Text = service.Districts.First(d => d.Id == client.DistrictId).Name;
                //    lblLocation.Text = client.Location;
                //    List<Intervention> clientIntervention = service.Interventions.FindAll(i => i.ClientId == client.Id);


                //    InterventionList.DataSource = clientIntervention;
                //    InterventionList.DataBind();

                //}

                //just use for test
                if (!string.IsNullOrEmpty(Request.QueryString["Name"]))
                {
                    string clientName =  Request.QueryString["Name"];
                    Client client = service.Clients.Find(c => c.Name == clientName);
                    lblName.Text = client.Name;
                    lblDistrict.Text = service.Districts.First(d => d.Id == client.DistrictId).Name;
                    lblLocation.Text = client.Location;

                    IEnumerable<Intervention> clientIntervention = service.Interventions.Where(i => i.ClientId == client.Id);

                    List<InterventionType> interventions = new List<InterventionType>();
                    foreach (var intervention in clientIntervention)
                    {
                        var interventionType = service.InterventionTypes.First(i => i.Id == intervention.InterventionTypeId);
                        interventions.Add(interventionType);
                    }
                    
                    InterventionList.DataSource = interventions;
                    InterventionList.DataBind();

                }
            }
          




            


        }

       
    }
}