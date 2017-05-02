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
        /// <summary>
        /// Create a Client
        /// </summary>
        /// <param name="client">Client object</param>
        /// <returns>Client object created</returns>
        public Client createClient(Client client)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO Clients (Name, Location, DistrictId) " 
                + "OUTPUT INSERTED.Id "
                + "VALUES(@Name, @Location, @DistrictId)");
         

            client.Id = (Guid) sqlExecuter.ExecuteScalar(command, client);

            if (client.Id != Guid.Empty)
                return client;
            return null;
        }
        /// <summary>
        /// Update a Client
        /// </summary>
        /// <param name="client">client object</param>
        /// <returns>true if success, false if fail</returns>
        public bool updateClient(Client client)
        {
            SqlCommand command = new SqlCommand(@"UPDATE Clients Set Name = @Name, Location = @Location, DistrictId = @DistrictId WHERE Id = @Id");
            return sqlExecuter.ExecuteNonQuery(command, client) > 0;
        }
        /// <summary>
        /// Get all Client
        /// </summary>
        /// <returns>A list of Client</returns>
        public IEnumerable<Client> getAll()
        {
            SqlCommand command = new SqlCommand("Select * From Clients");
            return sqlExecuter.ExecuteReader(command);
        }

        /// <summary>
        /// Get all clients in the district
        /// </summary>
        /// <param name="districtId">The guid of a district</param>
        /// <returns>A list of Client</returns>
        public IEnumerable<Client> fetchClientsByDistrictId(Guid districtId)
        {
            SqlCommand command = new SqlCommand("Select * From Clients Where DistrictId = @DistrictId");
            command.Parameters.AddWithValue("@DistrictId", districtId);
            return sqlExecuter.ExecuteReader(command);
        }
        /// <summary>
        /// Get a client by it's id
        /// </summary>
        /// <param name="clientId">the guid of Client</param>
        /// <returns>Client object</returns>
        public Client fetchClientById(Guid clientId)
        {
            SqlCommand command = new SqlCommand(@"Select * From Clients WHERE Id = @Id");
            command.Parameters.AddWithValue("@Id", clientId);
            return sqlExecuter.ExecuteReader(command).FirstOrDefault();
        }
    }
}
