using IMSDBLayer.DataModels;
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

        IEnumerable<Intervention> getAll();

        IEnumerable<Intervention> fetchInterventionsByClientId(Guid clientId);
        Intervention fetchInterventionsById(Guid interventionId);

        IEnumerable<Intervention> fetchInterventionsByState(int state);

        IEnumerable<Intervention> fetchInterventionsByDistrict(Guid districtId);

        IEnumerable<Intervention> fetchInterventionsByInterventionType(Guid interventionTypeId);

        IEnumerable<Intervention> fetchInterventionsByCreator(Guid creatorId);

        IEnumerable<Intervention> fetchInterventionsByApprovedUser(Guid userId);
    }
}
