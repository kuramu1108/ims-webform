using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer
{
    public class Setup : IMSDBLayer.Setup
    {
        public Setup(string connstring) : base(connstring)
        {
        }
    }
}
