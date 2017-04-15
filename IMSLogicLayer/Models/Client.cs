using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.Models
{
    public class Client : IMSDBLayer.DataModels.Client
    {
        public Client(string name, string location, Guid districtId)
        {
            Name = name;
            Location = location;
            DistrictId = districtId;
        }
    }
}
