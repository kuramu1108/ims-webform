using IMSDBLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer.DataAccessInterfaces
{
    public interface IUserDataAccess
    {
        User createUser(User user);

        bool updateUser(User user);

        User fetchUserById(Guid userId);

        User fetchUserByIdentityId(Guid identityId);

        IEnumerable<User> fetchUsersByUserType(int userType);

        IEnumerable<User> Users { get; }
    } 
}
