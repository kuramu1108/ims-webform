using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogic
{
    public class Client
    {
        public string name { get; set; }
        public string location { get; set; }
        public Common.Districts district { get; set; }

        public Client(string clientName, string clientlocation, Common.Districts clientDistricts)
        {
            name = clientName;
            location = clientlocation;
            district = clientDistricts;

        }
        public Client()
        {

        }


    }
}
