using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDBLayer;
using System.Security;

namespace IMSLogic
{
    public class Accountant:Users
    {
        private AccountantDM accountantDM;
        Accountant()
        {
            accountantDM = new AccountantDM();
        }
        //run report
        public void generateReport(Common.ReportType report, Common.Districts district)
        {
            switch((int)report)
            {
                case 1://Report.PrintTotalCostByEngineerReport();
                    break;
                case 2://Report.PrintAverageCostByEngineerReport();

                    break;
                case 3://Report.PrintCostByDistrictReport();

                    break;
                case 4://Report.PrintMonthlyCostForDistrictReport(district);

                    break;
                default:
                    //return warning
                    break;
            }
        }


        //see list of siteengineer and manager
        public void getListOfSGAndManager()
        {
            //return a list or datatable
            DataAccess.getAllSGAndManger();

        }

        public void changeDistrict(UsersDM user, Common.Districts newDistricts)
        {
            if (user.Type == Common.UserType.SiteEngineer || user.Type == Common.UserType.Manager)
            {
                //get the user with UserID()
                DataAccess.ChangeDistricts(user.UserID, newDistricts.ToString());
                //change the district of it
            }
        }


        public Accountant(int id, string name, string loginName, SecureString password, Common.UserType type)
        {
            //UserID = id;
            //Name = name;
            //LoginName = loginName;
            //Password = password;
            //Type = type;
            accountantDM = new AccountantDM(id, name, loginName, password, type);
        }
    }
}
