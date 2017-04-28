using IMSDBLayer.DataAccessObjects;
using IMSDBLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.BusinessHandler
{
    public class InterventionHandler
    {
        InterventionDataAccess InterventionDb = null;

        public InterventionHandler()
        {
            InterventionDb = new InterventionDataAccess();
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of interventions
        public IEnumerable<Intervention> GetInterventionList()
        {
            return InterventionDb.getAll();
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of interventions, we can put some logic here if needed
        public bool UpdateIntervention(Intervention intervention)
        {
            return InterventionDb.update(intervention);
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of interventions, we can put some logic here if needed
        public void create(Intervention intervention)
        {
            InterventionDb.create(intervention);
        }

    }
}
