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
            return Users.fetchUsersByUserType((int)UserType.Manager).Select(c => new User(c)).ToList(); ;
        }

        public IEnumerable<User> getAllSiteEngineer()
        {
            return Users.fetchUsersByUserType((int)UserType.SiteEngineer).Select(c => new User(c)).ToList();
        }

        public IEnumerable<User> getAllUser()
        {
           return Users.getAll().Select(c => new User(c)).ToList();
        }

        public User getDetail()
        {
            return new User(Users.fetchUserByIdentityId(accoutantId));
        }

        public User getUserById(Guid userId)
        {
            return new User(Users.fetchUserById(userId));
        }

        public IEnumerable<ReportRow> printAverageCostByEngineer()
        {
            return ReportDataAccess.averageCostByEngineer().Select(c => new ReportRow(c)).ToList();
        }

        public IEnumerable<ReportRow> printMonthlyCostByEngineer(Guid districtId)
        {
            return ReportDataAccess.monthlyCostForDistrict(districtId).Select(c => new ReportRow(c)).ToList();
        }

        public IEnumerable<ReportRow> printTotalCostByDistrict()
        {
            return ReportDataAccess.totalCostByEngineer().Select(c => new ReportRow(c)).ToList();
        }

        public IEnumerable<ReportRow> printTotalCostByEngineer()
        {
            return ReportDataAccess.totalCostByEngineer().Select(c => new ReportRow(c)).ToList();
        }
    }
}
