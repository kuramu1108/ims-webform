using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using IMSDBLayer;
using IMSDBLayer.DataAccessObjects;

namespace IMSLogicLayer
{
    public abstract class User
    {
        private Guid id;
        private string name;
        private int type;
        private decimal maxHoursCanApprove;
        private decimal maxCostsCanApprove;

        private Guid identityId;
        private Guid districtId;
        
        public User() { }

        public User(Guid identityId)
        {
            var user = new UserDataAccess("").fetchUserByIdentityId(identityId);
        }

        public Guid Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public decimal MaxHoursCanApprove
        {
            get { return this.maxHoursCanApprove; }
            set { this.maxHoursCanApprove = value; }
        }

        public decimal MaxCostsCanApprove
        {
            get { return this.maxCostsCanApprove; }
            set { this.maxCostsCanApprove = value; }
        }

        public Guid IdentityId
        {
            get { return this.identityId; }
            set { this.identityId = value; }
        }

        public Guid DistrictId
        {
            get { return this.districtId; }
            set { this.districtId = value; }
        }
    }
}
