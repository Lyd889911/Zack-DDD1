using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMgr.Domain
{
    /// <summary>
    /// 用户登录的结果
    /// </summary>
    public enum UserAccessResult
    {
        OK,
        PhoneNotFound,
        Lockout,
        NoPassword,
        PasswordError
    }
}
