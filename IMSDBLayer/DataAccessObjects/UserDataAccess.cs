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
    public class UserDataAccess : IUserDataAccess
    {
        private ISqlExecuter<User> sqlExecuter;

        public UserDataAccess(ISqlExecuter<User> sqlExecuter)
        {
            this.sqlExecuter = sqlExecuter;
        }
        /// <summary>
        /// Create a new user in database
        /// </summary>
        /// <param name="user">The user object</param>
        /// <returns>A user object created</returns>
        public User createUser(User user)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO Users (Name, Type, AuthorisedHours, 
                AuthorisedCosts, IdentityId, DistrictId) " + "VALUES(@name, @type, " +
                "@AuthorisedHours, @AuthorisedCosts, @identityId, @districtId)");
            
            user.Id = (Guid)sqlExecuter.ExecuteScalar(command, user);
            if (user.Id != Guid.Empty)
                return user;
            return null;
        }
        /// <summary>
        /// Update the user in database
        /// </summary>
        /// <param name="user">The user instance</param>
        /// <returns>True if success, false if fail</returns>
        public bool updateUser(User user)
        {
            SqlCommand command = new SqlCommand(@"UPDATE Users Set Name = @Name, Type = @Type,
                AuthorisedHours = @AuthorisedHours, AuthorisedCosts = @AuthorisedCosts,
                IdentityId = @IdentityId, DistrictId = @DistrictId WHERE Id = @Id");

            return sqlExecuter.ExecuteNonQuery(command, user) > 0;
        }

        /// <summary>
        /// Get all user from database
        /// </summary>
        /// <returns>A list of user</returns>
        public IEnumerable<User> getAll()
        {
            SqlCommand command = new SqlCommand("Select * From Users");
            return sqlExecuter.ExecuteReader(command);
        }

        /// <summary>
        /// Get an user from database using it's id
        /// </summary>
        /// <param name="userId">The guid of an users</param>
        /// <returns>An user object</returns>
        public User fetchUserById(Guid userId)
        {
            SqlCommand command = new SqlCommand("Select * From Users Where Id = @Id");
            command.Parameters.AddWithValue("@Id", userId);
            return sqlExecuter.ExecuteReader(command).FirstOrDefault();
        }
        /// <summary>
        /// Get an user from database using it's identity id
        /// </summary>
        /// <param name="identityId">The identity id of a logged in user</param>
        /// <returns>An user object</returns>
        public User fetchUserByIdentityId(Guid identityId)
        {
            SqlCommand command = new SqlCommand("Select * From Users Where IdentityId = @IdentityId");
            command.Parameters.AddWithValue("@IdentityId", identityId);
            return sqlExecuter.ExecuteReader(command).FirstOrDefault();
        }
        /// <summary>
        /// Get Users by it's role
        /// </summary>
        /// <param name="userType">roles of the user</param>
        /// <returns>A list of user</returns>
        public IEnumerable<User> fetchUsersByUserType(int userType)
        {
            SqlCommand command = new SqlCommand("Select * From Users Where Type = @Type");
            command.Parameters.AddWithValue("@Type", userType);
            return sqlExecuter.ExecuteReader(command);
        }
        /// <summary>
        /// Get user by it's name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>An user object</returns>
        public User fetchUserByName(string name)
        {
            SqlCommand command = new SqlCommand("Select * From Users Where Name = @name");
            command.Parameters.AddWithValue("@name", name);
            return sqlExecuter.ExecuteReader(command).FirstOrDefault();
        }
    }
}
