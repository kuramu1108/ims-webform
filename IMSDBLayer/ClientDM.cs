using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer
{
    public class ClientDM
    {

        public string Name { get; set; }
        public string Location { get; set; }
        public Common.Districts District { get; set; }

        public int ClientID { get; set; }

        public ClientDM(int id, string clientName, string clientlocation, Common.Districts clientDistricts)
        {
            ClientID = id;
            Name = clientName;
            Location = clientlocation;
            District = clientDistricts;

        }
        public ClientDM()
        {

        }
    }
}
