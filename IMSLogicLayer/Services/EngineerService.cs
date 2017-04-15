using IMSLogicLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSLogicLayer.Models;

namespace IMSLogicLayer.Services
{
    public class EngineerService : BaseService, IEngineerService
    {
        private Guid engineerId;

        public EngineerService(string connstring) : base(connstring)
        {
        }

        public Client createClient(string clientName, string clientLocation)
        {
            Client client = new Client(clientName, clientLocation, getDetail().DistrictId);
            return client;
        }
        
        public User getDetail()
        {
            return (User)Users.fetchUserByIdentityId(engineerId);
        }

        public IEnumerable<Client> getClients()
        {
            return Clients.fetchClientsByDistrictId(getDetail().DistrictId).Cast<Client>();
        }



    }
}
