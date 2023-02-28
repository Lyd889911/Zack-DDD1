using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMgr.Domain.Entities
{
    public record UserAccessFail
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        private bool isLockOut;
        public DateTime? LockEnd { get; private set; }
        public int AccessFailCount { get; private set; }
        private UserAccessFail() { }
        public UserAccessFail(User user)
        {
            this.Id = Guid.NewGuid();
            this.User = user;  
        }
        //重置
        public void Reset()
        {
            this.AccessFailCount = 0;
            this.LockEnd = null;
            this.isLockOut = false;
        }
        //登录失败
        public void Fail()
        {
            this.AccessFailCount++;
            if(this.AccessFailCount>=3)
            {
                this.LockEnd = DateTime.Now.AddMinutes(5);
                this.isLockOut = true;
            }
        }
        //判断用户是否被锁定
        public bool IsLockOut()
        {
            if (this.isLockOut)
            {
                if (DateTime.Now > this.LockEnd)//超过锁定时间
                {
                    Reset();
                    return false;
                }
                else
                    return true;
            }
            else
                return false;
        }

    }
}
