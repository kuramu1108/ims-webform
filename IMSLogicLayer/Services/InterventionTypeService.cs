using IMSDBLayer.DataModels;
using IMSLogicLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.Services
{
    public class InterventionTypeService : BaseService, IInterventionTypeService
    {
        public InterventionTypeService(string connstring) : base(connstring)
        {
        }

        public Guid getInterventionTypeId(String interventionTypeName)
        {
            return InterventionTypes.getInterventionTypeId(interventionTypeName);
        }
    }
}
