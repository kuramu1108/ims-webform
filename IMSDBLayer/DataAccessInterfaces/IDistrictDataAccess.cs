using IMSDBLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer.DataAccessInterfaces
{
    public interface IDistrictDataAccess
    {
        District create(District district);

        bool update(District district);

        IEnumerable<District> Districts { get; }

        District fetchDistrictById(Guid districtId);
    }
}
