using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataModels;

namespace IMSDBLayer.DataAccessObjects
{
    public class ClientDataAccess : IClientDataAccess
    {
        private string connstring = "";

        public ClientDataAccess(string connstring)
        {
            this.connstring = connstring;
        }

        public IEnumerable<Client> Clients => throw new NotImplementedException();

        public Client createClient(Client client)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> fetchClientsByDistrictId(Guid districtId)
        {
            throw new NotImplementedException();
        }
    }
}
