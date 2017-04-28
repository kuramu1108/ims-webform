using IMSDBLayer.DataAccessObjects;
using IMSDBLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.BusinessHandler
{
    public class ClientHandler
    {
        ClientDataAccess ClientDb = null;

        public ClientHandler()
        {
            ClientDb = new ClientDataAccess();
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of interventions
        public IEnumerable<Client> GetClientList()
        {
            return ClientDb.getAll();
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of interventions, we can put some logic here if needed
        public bool UpdateClient(Client client)
        {
            return ClientDb.updateClient(client);
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of interventions, we can put some logic here if needed
        public void createClient(Client client)
        {
            ClientDb.createClient(client);
        }
    }
}
