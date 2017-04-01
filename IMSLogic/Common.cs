using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogic
{
    public class Common
    {
        public enum Districts
        {
            UrbanIndonesia = 1,
            RuralIndonesia,
            UrbanPapuaNewGuinea,
            RuralPapuaNewGuinea,
            Sydney,
            RuralNewSouthWales
        }

        public enum InterventionType
        {
            Proposed = 1,
            Approved,
            Completed,
            Cancelled
        }

        public enum UserType
        {
            SiteEngineer = 1,
            Manager,
            Accountant
        }


    }
}
