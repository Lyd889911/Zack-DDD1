using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain;
using UserMgr.Domain.ValueObjects;

namespace UserMgr.Infrastracture
{
    public class MockSmsCodeSender : ISmsCodeSender
    {
        public Task SendAsync(Phone phone, string code)
        {
            Console.WriteLine($"向{phone.RegionNumber}-{phone.RegionNumber}发送短信验证码{code}");
            return Task.CompletedTask;
        }
    }
}
