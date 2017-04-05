using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogic
{
    public class Intervention
    {
        public string Name { get; set; }
        public int Intervention_id { get; set; }
        public Common.InterventionType Intervention_type { get; set; }
        public int Client_id { get; set; }
        public int Labour_hours { get; set; }
        public int Cost { get; set; }
        public int Site_engineer_id { get; set; }
        public string Date { get; set; }
        public Common.InterventionState State { get; set; }
        public string Comment { get; set; }
        public string Life_remaining { get; set; }
        public string Recent_visit_date { get; set; }
        public void SetLifeRemining(string remainind)
        {
            life_remaining = remainind;
        }
        public void SetRecentVisitDate(string time)
        {
            Recent_visit_date = time;
        }


        public Intervention(int intervention_id, Common.InterventionType intervention_type,
              int client_id, int labour_hours, int cost, int site_engineer_id,
              string date, Common.InterventionState state, string comment, string life_remaining)
        {
            this.Intervention_id = intervention_id;
            this.Intervention_type = intervention_type;
            this.Client_id = client_id;
            this.Labour_hours = labour_hours;
            this.Cost = cost;
            this.Site_engineer_id = site_engineer_id;
            this.Date = date;
            this.State = state;
            this.Comment = comment;
            this.Life_remaining = life_remaining;

        }
    }
}