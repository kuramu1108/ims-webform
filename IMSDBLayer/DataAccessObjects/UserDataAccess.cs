using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataAccessInterfaces;
using IMSDBLayer.DataModels;
using System.Data.SqlClient;
using IMSDBLayer.DataAccessObjects.Helpers;

namespace IMSDBLayer.DataAccessObjects
{
    public class UserDataAccess : IUserDataAccess
    {
        private SqlExecuter<User> sqlExecuter;

        public UserDataAccess(string connstring)
        {
            this.sqlExecuter = new SqlExecuter<User>(connstring);
        }

        public User createUser(User user)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO Users (Name, Type, MaxHoursCanApprove, 
                MaxCostsCanApprove, IdentityId, DistrictId) " + "VALUES(@name, @type, " +
                "@maxHoursCanApprove, @maxCostsCanApprove, @identityId, @districtId)");
            
            user.Id = (Guid)sqlExecuter.ExecuteScalar(command, user);
            if (user.Id != Guid.Empty)
                return user;
            return null;
        }

        public bool updateUser(User user)
        {
            SqlCommand command = new SqlCommand(@"UPDATE Users Set Name = @Name, Type = @Type,
                MaxHoursCanApprove = @MaxHoursCanApprove, MaxCostsCanApprove = @MaxCostsCanApprove,
                IdentityId = @IdentityId, DistrictId = @DistrictId WHERE Id = @Id");

            return sqlExecuter.ExecuteNonQuery(command, user) > 0;
        }

        public IEnumerable<User> getAll()
        {
            SqlCommand command = new SqlCommand("Select * From Users");
            return sqlExecuter.ExecuteReader(command);
        }

        public User fetchUserById(Guid userId)
        {
            SqlCommand command = new SqlCommand("Select * From Users Where Id = @Id");
            command.Parameters.AddWithValue("@Id", userId);
            return sqlExecuter.ExecuteReader(command).FirstOrDefault();
        }

        public User fetchUserByIdentityId(Guid identityId)
        {
            SqlCommand command = new SqlCommand("Select * From Users Where IdentityId = @IdentityId");
            command.Parameters.AddWithValue("@IdentityId", identityId);
            return sqlExecuter.ExecuteReader(command).FirstOrDefault();
        }

        public IEnumerable<User> fetchUsersByUserType(int userType)
        {
            SqlCommand command = new SqlCommand("Select * From Users Where Type = @Type");
            command.Parameters.AddWithValue("@Type", userType);
            return sqlExecuter.ExecuteReader(command);
        }
    }
}
