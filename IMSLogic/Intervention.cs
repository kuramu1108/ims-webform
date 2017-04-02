using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogic
{
    public class Intervention
    {
        public string name { get; set; }
        public int intervention_id { get; set; }
        public String intervention_type { get; set; }
        public int client_id { get; set; }
        public int labour_hours { get; set; }
        public int cost { get; set; }
        public int site_engineer_id { get; set; }
        public string date { get; set; }
        public string state { get; set; }
        public string comment { get; set; }
        public string life_remaining { get; set; }
        public string recent_visit_date { get; set; }

        public void setLifeRemining(string remainind)
        {
            life_remaining = remainind;
        }
        public void setRecentVisitDate(string time)
        {
            recent_visit_date = time;
        }


        public Intervention(int intervention_id, String intervention_type,
              int client_id, int labour_hours, int cost, int site_engineer_id,
              string date, string state, string comment, string life_remaining = "100 %")
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