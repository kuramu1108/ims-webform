using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace IMSLogic
{
    public abstract class Users
    {
        public string Name { get; set; }
        public string LoginName { get; set; }

        public int UserID { get; set; }

        public System.Security.SecureString Password { get; set; }

        public Common.UserType Type { get; set; }

        public Boolean changePassword(SecureString oldPassword,SecureString newPassword)
        {
            if (Password == oldPassword)
            {
                Password = newPassword;
                return true;
            }else
            {
                return false;
            }
        }
    }
}
