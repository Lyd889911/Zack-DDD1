using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain.ValueObjects;

namespace UserMgr.Domain.Entities
{
    public record UserLoginHistory:IAggregateRoot
    {
        public long Id { get; set; }
        public Guid? UserId { get; set; }//逻辑外键
        public Phone Phone { get; set; }
        public DateTime CreateDateTime { get; init; }
        public string Message { get; init; }
        private UserLoginHistory()
        {

        }
        public UserLoginHistory(Guid? userId,Phone phone,string message)
        {
            this.UserId = userId;
            this.Phone = phone;
            this.CreateDateTime = DateTime.Now;
            this.Message = message;
        }
    }
}
