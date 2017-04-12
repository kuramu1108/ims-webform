using IMSDBLayer.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IMSDBLayer.DataModels
{
    public class User
    {
        private Guid id;
        private string name;
        private UserType type;
        private decimal maxHoursCanApprove;
        private decimal maxCostsCanApprove;

        private Guid identityId;
        private Guid districtId;

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

        public UserType Type
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

        public IEnumerator<User> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
