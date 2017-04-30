using IMSDBLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer.DataAccessInterfaces
{
    public interface IInterventionTypeDataAccess
    {
        InterventionType create(InterventionType interventionType);

        bool update(InterventionType interventionType);

        IEnumerable<InterventionType> getAll();

        InterventionType fetchInterventionTypesById(Guid interventionTypeId);
    }
}
