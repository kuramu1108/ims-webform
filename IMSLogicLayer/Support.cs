using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer
{
    public class Support
    {
        public static SecureString convertToSS(string pwd)
        {
            SecureString ss = new SecureString();
            foreach (char c in pwd)
            {
                ss.AppendChar(c);
            }
            return ss;
        }
    }
}
