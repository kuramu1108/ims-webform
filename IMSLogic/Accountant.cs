using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogic
{
    class Accountant:Users
    {

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
