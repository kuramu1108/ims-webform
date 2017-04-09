using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer
{
    public class AccountantDM : UsersDM
    {

        public  AccountantDM() : base() { }

        public AccountantDM(int id, string name, string loginName, SecureString password, Common.UserType type) : base() { }

    }
}
