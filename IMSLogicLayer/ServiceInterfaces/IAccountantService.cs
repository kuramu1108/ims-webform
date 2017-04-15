using IMSDBLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.ServiceInterfaces
{
    public interface IAccountantService
    {
        //use to get all user
        IEnumerable<User> getAllUser();
        //use to get all site engineer
        IEnumerable<User> getAllSiteEngineer();
        //use to get all manager
        IEnumerable<User> getAllManger();
        //use to get a user by id
        User getUserById(Guid userId);

        //use to get details of this user
        User getDetail();

    }
}
