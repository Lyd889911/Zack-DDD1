using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain.ValueObjects;

namespace UserMgr.Domain
{
    /// <summary>
    /// 用户登陆结果的事件
    /// </summary>
    /// <param name="phone"></param>
    /// <param name=""></param>
    /// <param name="result"></param>
    public record UserAccessResultEvent(Phone Phone,UserAccessResult Result):INotification;
}
