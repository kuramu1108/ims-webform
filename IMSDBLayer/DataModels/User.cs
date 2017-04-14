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
        private int type;
        private decimal authorisedHours;
        private decimal authorisedCosts;

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

        public int Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public decimal AuthorisedHours
        {
            get { return this.authorisedHours; }
            set { this.authorisedHours = value; }
        }

        public decimal AuthorisedCosts
        {
            get { return this.authorisedCosts; }
            set { this.authorisedCosts = value; }
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
