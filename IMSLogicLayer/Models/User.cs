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
        
        public User(string name, int type, decimal authorisedHours, decimal authorisedCosts, string identityId, Guid districtId)
        {
            Name = name;
            Type = type;
            AuthorisedHours = authorisedHours;
            AuthorisedCosts = authorisedCosts;
            IdentityId = identityId;
            DistrictId = districtId;
        }

        public User(IMSDBLayer.DataModels.User user)
        {
            base.Id = user.Id;
            base.Name = user.Name;
            base.Type = user.Type;
            base.AuthorisedHours = user.AuthorisedHours;
            base.AuthorisedCosts = user.AuthorisedCosts;
            base.IdentityId = user.IdentityId;
            base.DistrictId = user.DistrictId;
        }
    }
}
