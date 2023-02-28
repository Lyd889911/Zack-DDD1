using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain.ValueObjects;

namespace UserMgr.Domain.Entities
{
    public record User:IAggregateRoot
    {
        public Guid Id { get; set; }
        public Phone Phone { get; private set; }
        private string? passwordHash;
        public UserAccessFail USerAccessFail { get;private set; }
        private User() { }
        public User(Phone phone)
        {
            this.Phone = phone;
            this.Id=Guid.NewGuid();
            this.USerAccessFail = new UserAccessFail(this);
        }
        public bool HasPassword()
        {
            return !string.IsNullOrEmpty(this.passwordHash);
        }
        public void ChangePassword(string password)
        {
            if (password.Length <= 3)
            {
                throw new ArgumentOutOfRangeException("密码长度必须大于三");
            }
            this.passwordHash = "MD5"+password;
        }
        public bool CheckPassword(string password)
        {
            return this.passwordHash == "MD5" + password;
        }
        public void ChangePhone(Phone phone)
        {
            this.Phone = phone;
        }
    }
}
