using IMSLogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.Models
{
    public class Intervention : IMSDBLayer.DataModels.Intervention
    {
        private string clientName;
        private string districtName;
        
        public Intervention(decimal hours, decimal costs, int lifeRemaining, string comments, InterventionState state, DateTime dateCreate, DateTime dateFinish, DateTime dateRecentVisit, Guid interventionTypeId, Guid clientId, Guid createdBy, Guid approvedBy)
        {
            Hours = hours;
            Costs = costs;
            LifeRemaining = lifeRemaining;
            Comments = comments;
            base.State = (int)state;

            DateCreate = dateCreate;
            DateFinish = dateFinish;

            DateRecentVisit = dateRecentVisit;
            InterventionTypeId = interventionTypeId;
            ClientId = clientId;
            CreatedBy = createdBy;
            ApprovedBy = approvedBy;
        }

        public Intervention(IMSDBLayer.DataModels.Intervention intervention)
        {
            base.Id = intervention.Id;
            base.Hours = intervention.Hours;
            base.Costs = intervention.Costs;
            base.LifeRemaining = intervention.LifeRemaining;
            base.Comments = intervention.Comments;
            base.State = intervention.State;

            base.DateCreate = intervention.DateCreate;
            base.DateFinish = intervention.DateFinish;

            base.DateRecentVisit = intervention.DateRecentVisit;
            base.InterventionTypeId = intervention.InterventionTypeId;
            base.ClientId = intervention.ClientId;
            base.CreatedBy = intervention.CreatedBy;
            base.ApprovedBy = intervention.ApprovedBy;
        }

        public string ClientName
        {
            get { return clientName; }
            set { this.clientName = value; }
        }

        public string DistrictName
        {
            get { return districtName; }
            set { this.districtName = value; }
        }

        public new InterventionState State
        {
            get { return (InterventionState)base.State; }
            set { base.State = (int)value; }
        }
    }
}
