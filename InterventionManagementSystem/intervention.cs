+?using System;
+using System.Collections.Generic;
+using System.Linq;
+using System.Text;
+using System.Threading.Tasks;
+
+namespace IMSLogic
Class Intervention{
 public string name { get; set; }
-        private int intervention_id { get; set; }
-        private String intervention_type { get; set; }     
         private int client_id { get; set; }
+        private int labour_hours { get; set; }     
         private int cost { get; set; }
		 private int site_engineer_id{ get; set; }
		 private string date{ get; set; }
	     private string state{ get; set; }
		 private string comment{ get; set; }
		 private string life_remaining { get; set; }
		 private string recent_visit_date { get; set; }
		  
         public Intervention(int intervention_id,String intervention_type,
		 int client_id,int labour_hours ,int cost,int site_engineer_id,
		 string date,string state,string comment,string life_remaining=100%)
         {
-           this.intervention_id=intervention_id;
            this.intervention_type=intervention_type;
			this.client_id=client_id;
			this.labour_hours=labour_hours;
			this.cost=cost;
			this.site_engineer_id=site_engineer_id;
			this.date=date;
            this.state=state;
			this.comment=comment;
			this.life_remaining=life_remaining;

         }
		 public void setLifeRemining(string remainind){
			 life_remaining=remainind;
		 }
		 public void setRecentVisitDate(string time){
		    recent_visit_date=time;
		 }
		 
         public Intervention()
         {
 
         }
 
     }
	
}