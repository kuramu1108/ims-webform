using IMSDBLayer.DataModels;
using IMSDBLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer.DataAccessInterfaces
{
    public interface IInterventionDataAccess
    {
        Intervention create(Intervention intervention);
        bool update(Intervention intervention);

        IEnumerable<Intervention> Interventions { get; }

        IEnumerable<Intervention> fetchInterventionsByState(InterventionState state);

        IEnumerable<Intervention> fetchInterventionsByDistrict(Guid districtId);

        IEnumerable<Intervention> fetchInterventionsByCreator(Guid creatorId);
    }
}
