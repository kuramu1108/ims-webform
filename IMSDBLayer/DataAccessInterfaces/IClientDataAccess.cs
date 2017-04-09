using IMSDBLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer.DataAccessInterfaces
{
    public interface IClientDataAccess
    {
        Client createClient(Client client);

        IEnumerable<Client> fetchClientsByDistrictId(Guid districtId);

        IEnumerable<Client> Clients { get; }
    }
}
