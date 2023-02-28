using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain.Entities;
using UserMgr.Domain.ValueObjects;

namespace UserMgr.Domain
{
    /// <summary>
    /// 用户仓储
    /// </summary>
    public interface IUserRepository
    {
        public Task<User?> FindOneAsync(Phone phone);
        public Task<User?> FindOneAsync(Guid id);
        public Task AddNewLoginHistory(Phone phone, string message);
        public Task SavePhoneCodeAsync(Phone phone, string code);
        public Task<string?> FindPhoneCodeAsync(Phone phone);
        public Task PublishEventAsync(UserAccessResultEvent _event);
    }
}
