using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataAccessInterfaces.Helpers;
using IMSDBLayer.DataModels;
using System.Data.SqlClient;

namespace IMSDBLayer.DataAccessObjects
{
    public class ClientDataAccess : IClientDataAccess
    {
        private ISqlExecuter<Client> sqlExecuter;

        public ClientDataAccess(ISqlExecuter<Client> sqlExecuter)
        {
            this.sqlExecuter = sqlExecuter;
        }
        
        public Client createClient(Client client)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO Clients (Name, Location, DistrictId) " 
                + "VALUES(@Name, @Location, @DistrictId)");
            client.Id = (Guid) sqlExecuter.ExecuteScalar(command, client);

            if (client.Id != Guid.Empty)
                return client;
            return null;
        }

        public bool updateClient(Client client)
        {
            SqlCommand command = new SqlCommand(@"UPDATE Clients Set Name = @Name, Location = @Location, DistrictId = @DistrictId WHERE Id = @Id");
            return sqlExecuter.ExecuteNonQuery(command, client) > 0;
        }

        public IEnumerable<Client> getAll()
        {
            SqlCommand command = new SqlCommand("Select * From Clients");
            return sqlExecuter.ExecuteReader(command);
        }
        
        public IEnumerable<Client> fetchClientsByDistrictId(Guid districtId)
        {
            SqlCommand command = new SqlCommand("Select * From Clients Where DistrictId = @DistrictId");
            command.Parameters.AddWithValue("@DistrictId", districtId);
            return sqlExecuter.ExecuteReader(command);
        }

        public Client fetchClientById(Guid clientId)
        {
            SqlCommand command = new SqlCommand(@"Select * From Clients WHERE Id = @Id");
            command.Parameters.AddWithValue("@Id", clientId);
            return sqlExecuter.ExecuteReader(command).FirstOrDefault();
        }
    }
}
