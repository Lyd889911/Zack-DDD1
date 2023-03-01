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
    /// 用户领域服务
    /// </summary>
    public class UserDomainService
    {
        /// <summary>
        /// 在用户领域服务里面注入需要用的对象
        /// </summary>
        private IUserRepository _userRepository;
        private ISmsCodeSender _smsSender;
        public UserDomainService(IUserRepository userRepository,ISmsCodeSender smsCodeSender)
        {
            _userRepository = userRepository;  
            _smsSender = smsCodeSender;
        }
        public async Task<UserAccessResult> CheckPassword(Phone phone,string password)
        {
            UserAccessResult result;
            var user = await _userRepository.FindOneAsync(phone);
            if (user == null)
                result = UserAccessResult.PhoneNotFound;
            else if (IsLockOut(user))
                result = UserAccessResult.Lockout;
            else if (!user.HasPassword())
                result = UserAccessResult.NoPassword;
            else if (user.CheckPassword(password))
                result = UserAccessResult.OK;
            else
                result = UserAccessResult.PasswordError;
            if(user == null)
            {
                if (result == UserAccessResult.OK)
                    ResetAccessFail(user);
                else
                    AccessFail(user);
            }
            await _userRepository.PublishEventAsync(new UserAccessResultEvent(phone, result));
            return result;

        }
        public void ResetAccessFail(User user)
        {
            //user.UserAccessFail.Reset();
        }
        public bool IsLockOut(User user)
        {
            //return user.UserAccessFail.IsLockOut();
            return false;
        }
        public void AccessFail(User user)
        {
            //user.UserAccessFail.Fail();
        }
        public async Task<CheckCodeResult> CheckPhoneCodeAsync(Phone phone,string code)
        {
            User? user = await _userRepository.FindOneAsync(phone);
            if (user == null)
                return CheckCodeResult.PhoneNotFound;
            else if (IsLockOut(user))
                return CheckCodeResult.LockOut;
            string? codeInServer = await _userRepository.FindPhoneCodeAsync(phone);
            if (string.IsNullOrEmpty(codeInServer))
                return CheckCodeResult.CodeError;
            if (codeInServer == code)
                return CheckCodeResult.OK;
            else
            {
                AccessFail(user);
                return CheckCodeResult.CodeError;
            }
        }

    }
}
