using IMSLogicLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSLogicLayer.Models;

namespace IMSLogicLayer.FakeServices
{
    public class FakeManagerService : FakeBaseService, IManagerService
    {
        public FakeManagerService(string connstring) : base(connstring) { }

        public User getDetail()
        {
            throw new NotImplementedException();
        }
    }
}
