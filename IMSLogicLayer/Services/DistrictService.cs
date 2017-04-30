using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSLogicLayer.Models;
using IMSLogicLayer.ServiceInterfaces;

namespace IMSLogicLayer.Services
{
    public class DistrictService : BaseService, IDistrictService
    {
        public DistrictService(string connstring) : base(connstring)
        {


        }

        public IEnumerable<District> GetAllDistrict()
        {
            return Districts.getAll().Select(d => new District(d)).ToList();
        }

        public District GetDistrictById(Guid Id)
        {
            return new District(Districts.fetchDistrictById(Id));
        }

        public District GetDistrictByName(string name)
        {
            return new District(Districts.fetchDistrictByName(name));
        }
    }
}
