using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.Models
{
    public class User : IMSDBLayer.DataModels.User
    {
        public User() { }
        public User(string name, int type, decimal authorisedHours, decimal authorisedCosts, Guid identityId, Guid districtId)
        {
            Name = name;
            Type = type;
            AuthorisedHours = authorisedHours;
            AuthorisedCosts = authorisedCosts;
            IdentityId = identityId;
            DistrictId = districtId;
        }
    }
}
