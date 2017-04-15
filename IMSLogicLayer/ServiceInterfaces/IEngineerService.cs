using IMSLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.ServiceInterfaces
{
    public interface IEngineerService
    {
        Client createClient(string clientName, string clientLocation);

        User getDetail();

        IEnumerable<Client> getClients();
    }
}
