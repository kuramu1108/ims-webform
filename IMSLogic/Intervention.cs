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
            recent_visit_date = time;
        }


        public Intervention(int intervention_id, Common.InterventionType intervention_type,
              int client_id, int labour_hours, int cost, int site_engineer_id,
              string date, Common.InterventionState state, string comment, string life_remaining = "100 %")
        {
            this.intervention_id = intervention_id;
            this.intervention_type = intervention_type;
            this.client_id = client_id;
            this.labour_hours = labour_hours;
            this.cost = cost;
            this.site_engineer_id = site_engineer_id;
            this.date = date;
            this.state = state;
            this.comment = comment;
            this.life_remaining = life_remaining;

        }
    }
}