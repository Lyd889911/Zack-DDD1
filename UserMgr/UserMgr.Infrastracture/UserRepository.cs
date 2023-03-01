using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain;
using UserMgr.Domain.Entities;
using UserMgr.Domain.ValueObjects;

namespace UserMgr.Infrastracture
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext dbContext;
        private readonly IMemoryCache memory;
        private readonly IMediator mediator;
        public UserRepository(UserDbContext dbcontext,IMemoryCache memory, IMediator mediator)
        {
            this.dbContext = dbcontext;
            this.memory = memory;
            this.mediator = mediator;
        }

        public async Task AddNewLoginHistory(Phone phone, string message)
        {
            User? user = await FindOneAsync(phone);
            if (user != null)
            {
                dbContext.UserLoginHistories.Add(new UserLoginHistory(user.Id, phone, message));
            }
            
        }

        public async Task<User?> FindOneAsync(Phone phone)
        {
            User? user = await dbContext.Users.SingleOrDefaultAsync(u => u.Phone.PhoneNumber == phone.PhoneNumber && u.Phone.RegionNumber == phone.RegionNumber);
            return user;
        }

        public async Task<User?> FindOneAsync(Guid id)
        {
            User? user = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public Task<string?> FindPhoneCodeAsync(Phone phone)
        {
            string key = $"phonecode:{phone.RegionNumber}:{phone.PhoneNumber}";
            object? code = memory.Get(key);
            if (code == null)
                code = "";
            return Task.FromResult(code.ToString());
        }

        public Task PublishEventAsync(UserAccessResultEvent _event)
        {
            return mediator.Publish(_event);
        }

        public Task SavePhoneCodeAsync(Phone phone, string code)
        {
            //随便保存到哪里,我这里就保存到内存中,测试
            string key = $"phonecode:{phone.RegionNumber}:{phone.PhoneNumber}";
            var opt = new MemoryCacheEntryOptions();
            opt.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
            memory.Set(key, code, opt);
            return Task.CompletedTask;
        }
    }
}
