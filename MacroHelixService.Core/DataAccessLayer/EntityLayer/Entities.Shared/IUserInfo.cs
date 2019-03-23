using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Shared
{
    public interface IUserInfo
    {
        int? UID { get; set; }

        string[] Roles { get; set; }
    }

    public class UserInfo : IUserInfo
    {
        public UserInfo()
        {
        }

        public int? UID { get; set; }

        public string[] Roles { get; set; }
    }
}
