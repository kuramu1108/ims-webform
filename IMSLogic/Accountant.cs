using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogic
{
    public class Accountant:Users
    {
        public Accountant(int id, string name, string loginName, SecureString password, Common.UserType type)
        {
            UserID = id;
            Name = name;
            LoginName = loginName;
            Password = password;
            Type = type;
        }

        public void generateReport(Common.ReportType report, Common.Districts district)
        {
            switch((int)report)
            {
                case 1:Report.PrintTotalCostByEngineerReport();
                    break;
                case 2:Report.PrintAverageCostByEngineerReport();

                    break;
                case 3:Report.PrintCostByDistrictReport();

                    break;
                case 4:Report.PrintMonthlyCostForDistrictReport(district);

                    break;
                default:
                    //return warning
                    break;
            }
        }
    }
}
