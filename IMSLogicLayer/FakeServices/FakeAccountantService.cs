using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSLogicLayer.Models;
using IMSLogicLayer.ServiceInterfaces;

namespace IMSLogicLayer.FakeServices
{
    public class FakeAccountantService : FakeBaseService,IAccountantService
    {
        public FakeAccountantService(string connstring) : base(connstring)
        {
        }

        public bool changeDistrict(Guid userId, Guid district)
        {
            return true;
        }

        public IEnumerable<User> getAllManger()
        {

            return Users.FindAll(u=>u.Type==2) ;

        }

        public IEnumerable<User> getAllSiteEngineer()
        {
            


            return Users.FindAll(u => u.Type == 1);
        }

        public IEnumerable<User> getAllUser()
        {
            var AllUsers = new List<User>();
            
            AllUsers.Add(getDetail());
            AllUsers.AddRange(getAllManger());
            AllUsers.AddRange(getAllSiteEngineer());
            return AllUsers;
        }

        public User getDetail()
        {
            User accountant = new User();
            accountant.Name = "Angelica Smith";
            accountant.Type = 3;
            accountant.IdentityId = "88888888-8888-8888-8888-888888888888";
            return accountant;
        }

        public User getUserById(Guid userId)
        {
            return new User("John Miller", 1, 6m, 1000.00m, "99999999-9999-9999-9999-999999999999", new Guid("00000000-1111-1111-1111-111111111111"));
            
        }

        public IEnumerable<ReportRow> printAverageCostByEngineer()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportRow> printMonthlyCostByEngineer(Guid districtId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportRow> printTotalCostByDistrict()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportRow> printTotalCostByEngineer()
        {
            throw new NotImplementedException();
        }
    }
}
