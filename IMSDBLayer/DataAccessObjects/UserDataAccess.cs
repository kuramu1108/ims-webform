using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataModels;
using IMSDBLayer.Enums;
using System.Data.SqlClient;

namespace IMSDBLayer.DataAccessObjects
{
    public class UserDataAccess : IUserDataAccess
    {
        private string connstring = "";

        public UserDataAccess(string connstring)
        {
            this.connstring = connstring;
        }

        public IEnumerable<User> Users => throw new NotImplementedException();

        public User createUser(User user)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO Users (Name, Type, MaxHoursCanApprove, 
                MaxCostsCanApprove, IdentityId, DistrictId) " + "VALUES(@name, @type, " +
                "@maxHoursCanApprove, @maxCostsCanApprove, @identityId, @districtId)");
            
            command.Parameters.Add(new SqlParameter("name", user.Name));
            command.Parameters.Add(new SqlParameter("type", user.Type));
            command.Parameters.Add(new SqlParameter("maxHoursCanApprove", user.MaxHoursCanApprove));
            command.Parameters.Add(new SqlParameter("maxCostsCanApprove", user.MaxCostsCanApprove));
            command.Parameters.Add(new SqlParameter("identityId", user.IdentityId));
            command.Parameters.Add(new SqlParameter("districtId", user.DistrictId));

            if (executeUpdateSqlCommand(command) == true)
                return fetchUserByIdentityId(user.IdentityId);
            return null;
        }

        public User fetchUserById(Guid userId)
        {
            SqlCommand command = new SqlCommand("Select * From Users Where UserID = @userId");
            command.Parameters.AddWithValue("userId", userId);
            return executeReadSqlCommand(command).FirstOrDefault();
        }

        public User fetchUserByIdentityId(Guid identityId)
        {
            SqlCommand command = new SqlCommand("Select * From Users Where IdentityId = @identityId");
            command.Parameters.AddWithValue("identityId", identityId);
            return executeReadSqlCommand(command).FirstOrDefault();
        }

        public IEnumerable<User> fetchUsersByUserType(UserType userType)
        {
            SqlCommand command = new SqlCommand("Select * From Users Where Type = @type");
            command.Parameters.AddWithValue("type", userType);
            return executeReadSqlCommand(command);
        }

        public bool updateUser(User user)
        {
            SqlCommand command = new SqlCommand(@"UPDATE Users Set Name = @name, Type = @type,
                MaxHoursCanApprove = @maxHoursCanApprove, MaxCostsCanApprove = @maxCostsCanApprove,
                IdentityId = @identityId, DistrictId = @districtId WHERE Id = @id");

            command.Parameters.Add(new SqlParameter("id", user.Id));
            command.Parameters.Add(new SqlParameter("name", user.Name));
            command.Parameters.Add(new SqlParameter("type", user.Type));
            command.Parameters.Add(new SqlParameter("maxHoursCanApprove", user.MaxHoursCanApprove));
            command.Parameters.Add(new SqlParameter("maxCostsCanApprove", user.MaxCostsCanApprove));
            command.Parameters.Add(new SqlParameter("identityId", user.IdentityId));
            command.Parameters.Add(new SqlParameter("districtId", user.DistrictId));

            return executeUpdateSqlCommand(command);
        }

        /// <summary>
        /// Execute sqlcommand to return list of users
        /// </summary>
        /// <param name="command"></param>
        /// <returns>List of users</returns>
        private List<User> executeReadSqlCommand(SqlCommand command)
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.Id = reader.GetGuid(0);
                    user.Name = reader.GetString(1);
                    user.Type = (UserType)reader.GetInt32(2);
                    user.MaxHoursCanApprove = reader.GetDecimal(3);
                    user.MaxCostsCanApprove = reader.GetDecimal(4);
                    user.IdentityId = reader.GetGuid(5); 
                    user.DistrictId = reader.GetGuid(6);

                    users.Add(user);
                }
                connection.Close();
            }
            return users;
        }

        private bool executeUpdateSqlCommand(SqlCommand command)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //TODO - Implement low DB SQL excution exception logging.
                return false;
            }
            return true;
        }
    }
}
