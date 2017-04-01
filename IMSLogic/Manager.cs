using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogic
{
    public class Manager:Users
    {
        public Common.Districts Districts { get; set; }
        public double AuthorisedHour { get; set; }
        public decimal AuthorisedCost { get; set; }

        public Manager() { }

        public Manager(string name, string loginName, System.Security.SecureString password, Common.UserType type, Common.Districts districts, double hour, decimal cost)
        {
            Name = name;
            LoginName = loginName;
            Password = password;
            Type = type;
            Districts = districts;
            AuthorisedHour = hour;
            AuthorisedCost = cost;


        }

    }
}
