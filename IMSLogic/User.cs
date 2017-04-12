﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using IMSDBLayer;

namespace IMSLogic
{
    public abstract class User
    {
        public string Name { get; set; }
        public string LoginName { get; set; }

        public int UserID { get; set; }

        public System.Security.SecureString Password { get; set; }

        public Common.UserType Type { get; set; }

        private UsersDM user;
        public User() {

            user = new UsersDM();
        }
        public User(int id,string name,string loginName,SecureString password,Common.UserType type)
        {
            UserID = id;
            Name = name;
            LoginName = loginName;
            Password = password;
             Type = type;
            user = new UsersDM(name, loginName, password, type);
        }

        public Boolean changePassword(SecureString oldPassword,SecureString newPassword)
        {
            if (user.Password == oldPassword)
            {
                user.Password = newPassword;
                return true;
            }else
            {
                return false;
            }
        }
    }
}