using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer.DataModels
{
    public class Client
    {
        private Guid id;
        private string name;
        private string location;

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

        public string Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        public Guid DistrictId
        {
            get { return this.districtId; }
            set { districtId = value; }
        }
    }
}
