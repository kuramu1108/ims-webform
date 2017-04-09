using IMSDBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogic
{
    public class Client
    {
        //public string Name { get; set; }
        //public string Location { get; set; }
        //public Common.Districts District { get; set; }

        //public int ClientID { get; set; }

        public ClientDM clientDM;

        public Client(int id,string clientName, string clientlocation, Common.Districts clientDistricts)
        {
            //ClientID = id;
            //Name = clientName;
            //Location = clientlocation;
            //District = clientDistricts;

            clientDM = new ClientDM(id, clientName, clientlocation, clientDistricts);

        }
        public Client()
        {
            clientDM = new ClientDM();
        }
        public override string ToString(){
            return "Client name: "+clientDM.Name+", Client location: "+clientDM.Location;
         }  

    }
}
