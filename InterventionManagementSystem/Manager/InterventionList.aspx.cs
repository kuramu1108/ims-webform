using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSLogicLayer.ServiceInterfaces;
using IMSLogicLayer.FakeServices;
using IMSLogicLayer.Models;

namespace InterventionManagementSystem.Manager
{
    public partial class InterventionList : System.Web.UI.Page
    {
        
        FakeBaseService service = new FakeBaseService("");        
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (var intervention in service.Interventions)
            {
                Client client = service.Clients.FirstOrDefault(c => c.Id == intervention.ClientId);
                intervention.ClientName = client.Name;
                intervention.DistrictName = service.Districts.FirstOrDefault(d => d.Id == client.DistrictId).Name;
            }
            ListIntervention.DataSource = service.Interventions;
            ListIntervention.DataBind();
        }
    }
}