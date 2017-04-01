using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogic
{
    public class Client
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public Common.Districts District { get; set; }

        public Client(string clientName, string clientlocation, Common.Districts clientDistricts)
        {
            Name = clientName;
            Location = clientlocation;
            District = clientDistricts;

        }
        public Client()
        {

        }


    }
}
