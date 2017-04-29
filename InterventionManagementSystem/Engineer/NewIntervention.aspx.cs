using IMSLogicLayer.Enums;
using IMSLogicLayer.Models;
using IMSLogicLayer.ServiceInterfaces;
using IMSLogicLayer.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterventionManagementSystem
{
    public partial class NewIntervention : System.Web.UI.Page
    {
        private IEngineerService engineerService;

        protected void Page_Load(object sender, EventArgs e)
        {
            engineerService = new EngineerService(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, User.Identity.GetUserId());
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                decimal hour = decimal.Parse(InterventionHour.Text);
                decimal cost = decimal.Parse(InterventionCost.Text);
                string comments = InterventionComments.Text;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                DateTime createDate = DateTime.Parse(DateTime.Now.ToShortDateString());

                DateTime finishDate = DateTime.Parse(InterventionPerformDate.Text);
                DateTime recentVisit = DateTime.Parse(DateTime.Now.ToShortDateString());
                var typeID = SeletedInterventionType.SelectedValue;
                var clientID = SelectClient.SelectedValue;
                InterventionState state = InterventionState.Proposed;
                




                Intervention intervention = new Intervention(hour,cost,100,comments,state,createDate,finishDate,recentVisit,new Guid(typeID),new Guid(clientID), engineerService.getDetail().Id,null);
                engineerService.createIntervention(intervention);
            }
        }

        public List<InterventionType> getInterventionTypes()
        {
            return engineerService.getInterventionTypes();
        }

        public List<Client> getClients()
        {
            return engineerService.getClients().ToList();
        }

        protected void SeletedInterventionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var interventionTypes = engineerService.getInterventionTypes();

            var interventionType = interventionTypes.Find(i => i.Id == new Guid(SeletedInterventionType.SelectedValue));

            InterventionHour.Text = interventionType.Hours.ToString();
            InterventionCost.Text = interventionType.Costs.ToString();

        }
    }
}