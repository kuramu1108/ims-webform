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

        IEnumerable<User> getAll();

        User fetchUserById(Guid userId);

        User fetchUserByIdentityId(Guid identityId);

        User fetchUserByName(string name);

        IEnumerable<User> fetchUsersByUserType(int userType);
    } 
}
