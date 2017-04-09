using IMSDBLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer.DataModels
{
    public class Intervention
    {
        private Guid id;
        private decimal hours;
        private decimal costs;
        private int lifeRemaining;
        private string comments;
        private InterventionState state;

        private DateTime dateCreate;
        private DateTime dateFinish;

        private DateTime dateRecentVisit;

        private Guid interventionTypeId;
        private Guid clientId;
        private Guid createdBy;
        private Guid approvedBy;

        public Guid Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public decimal Hours
        {
            get { return this.hours; }
            set { this.hours = value; }
        }

        public decimal Costs
        {
            get { return this.costs; }
            set { this.costs = value; }
        }

        public int LifeRemaining
        {
            get { return this.lifeRemaining; }
            set { this.lifeRemaining = value; }
        }

        public string Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public InterventionState State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public DateTime DateCreate
        {
            get { return this.dateCreate; }
            set { this.dateCreate = value; }
        }

        public DateTime DateFinish
        {
            get { return this.dateFinish; }
            set { this.dateFinish = value; }
        }

        public DateTime DateRecentVisit
        {
            get { return this.dateRecentVisit; }
            set { this.dateRecentVisit = value; }
        }

        public Guid InterventionTypeId
        {
            get { return this.interventionTypeId; }
            set { this.interventionTypeId = value; }
        }

        public Guid ClientId
        {
            get { return this.clientId; }
            set { this.clientId = value; }
        }
        public Guid CreatedBy
        {
            get { return this.createdBy; }
            set { this.createdBy = value; }
        }
        public Guid ApprovedBy
        {
            get { return this.approvedBy; }
            set { this.approvedBy = value; }
        }
    }
}
