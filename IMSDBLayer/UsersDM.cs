using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer
{
    public class UsersDM
    {
        private string v;

        public UsersDM(string name, string loginName, SecureString password, string v)
        {
            Name = name;
            LoginName = loginName;
            Password = password;
            this.v = v;

        }

        public UsersDM() { }

        public string Name { get; set; }
        public string LoginName { get; set; }

        public int UserID { get; set; }

        public System.Security.SecureString Password { get; set; }

        public Common.UserType Type { get; set; }

        

    }
}
