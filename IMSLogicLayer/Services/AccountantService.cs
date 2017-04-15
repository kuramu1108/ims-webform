using IMSLogicLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer.DataModels;
using IMSLogicLayer.Enums;

namespace IMSLogicLayer.Services
{
    public class AccountantService : BaseService,IAccountantService
    {
        private Guid accoutantId;
        public AccountantService(string connstring) : base(connstring)
        {
        }

        public IEnumerable<User> getAllManger()
        {
            return Users.fetchUsersByUserType((int)UserType.Manager);
        }

        public IEnumerable<User> getAllSiteEngineer()
        {
            return Users.fetchUsersByUserType((int)UserType.SiteEngineer);
        }

        public IEnumerable<User> getAllUser()
        {
           return Users.getAll();
        }

        public User getDetail()
        {
            return (User)Users.fetchUserByIdentityId(accoutantId);
        }

        public User getUserById(Guid userId)
        {
            return Users.fetchUserById(userId);
        }
    }
}
