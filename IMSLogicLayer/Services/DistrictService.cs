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
        /// <summary>
        /// Get all district 
        /// </summary>
        /// <returns>A list of districts</returns>
        public IEnumerable<District> GetAllDistrict()
        {
            return Districts.getAll().Select(d => new District(d)).ToList();
        }
        /// <summary>
        /// Get a district from it's id
        /// </summary>
        /// <param name="Id">The guid of a district</param>
        /// <returns>A district instance</returns>
        public District GetDistrictById(Guid Id)
        {
            return new District(Districts.fetchDistrictById(Id));
        }
        /// <summary>
        /// Get a district from it's name
        /// </summary>
        /// <param name="name">name of a district</param>
        /// <returns>A district instance</returns>
        public District GetDistrictByName(string name)
        {
            return new District(Districts.fetchDistrictByName(name));
        }
    }
}
