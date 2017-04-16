using IMSLogicLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSLogicLayer.Enums;
using IMSLogicLayer.Models;

namespace IMSLogicLayer.Services
{
    public class AccountantService : BaseService,IAccountantService
    {
        private Guid accoutantId;
        public AccountantService(string connstring) : base(connstring)
        {
        }

        public bool changeDistrict(Guid userId, Guid districtId)
        {
            var user = getUserById(userId);

            
            user.DistrictId = districtId;


            return true;
        }

        public IEnumerable<User> getAllManger()
        {
            return Users.fetchUsersByUserType((int)UserType.Manager).Cast<User>();
        }

        public IEnumerable<User> getAllSiteEngineer()
        {
            return Users.fetchUsersByUserType((int)UserType.SiteEngineer).Cast<User>();
        }

        public IEnumerable<User> getAllUser()
        {
           return Users.getAll().Cast<User>();
        }

        public User getDetail()
        {
            return (User)Users.fetchUserByIdentityId(accoutantId);
        }

        public User getUserById(Guid userId)
        {
            return (User)Users.fetchUserById(userId);
        }
    }
}
