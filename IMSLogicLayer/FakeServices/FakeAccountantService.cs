using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSLogicLayer.Models;
using IMSLogicLayer.ServiceInterfaces;

namespace IMSLogicLayer.FakeServices
{
    public class FakeAccountantService : IAccountantService
    {
        public bool changeDistrict(Guid userId, Guid district)
        {
            return true;
        }

        public IEnumerable<User> getAllManger()
        {
            var ListOfManager = new List<User>()
            {
                
                new User("John Smith", 2,12m,2000.00m,new Guid("22222222-2222-2222-2222-222222222222"),new Guid("33333333-3333-3333-3333-333333333333") ),
                new User("Michael Jack",2,12m,2500.00m,new Guid("00000000-0000-0000-0000-000000000000"),new Guid("11111111-1111-1111-1111-111111111111"))

            };


            return ListOfManager;

        }

        public IEnumerable<User> getAllSiteEngineer()
        {
            var ListOfEngineer = new List<User>()
            {
                new User("John Miller", 1,6m,1000.00m,new Guid("44444444-4444-4444-4444-444444444444"),new Guid("66666666-6666-6666-6666-666666666666") ),
                new User("Jack James",1,6m,1500.00m,new Guid("55555555-5555-5555-5555-555555555555"),new Guid("77777777-7777-7777-7777-777777777777"))

            };


            return ListOfEngineer;
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
            accountant.IdentityId = new Guid("88888888-8888-8888-8888-888888888888");
            return accountant;
        }

        public User getUserById(Guid userId)
        {
            return new User("John Miller", 1, 6m, 1000.00m, new Guid("99999999-9999-9999-9999-999999999999"), new Guid("00000000-1111-1111-1111-1111-111111111111"));
            
        }
    }
}
