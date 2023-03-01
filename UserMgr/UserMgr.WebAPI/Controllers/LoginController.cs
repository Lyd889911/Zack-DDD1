using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserMgr.Domain;
using UserMgr.Infrastracture;

namespace UserMgr.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserDomainService userService;
        public LoginController(UserDomainService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        [UnitOfWork(typeof(UserDbContext))]
        public async Task<IActionResult> Login(LoginByPhoneAndPasswordRequest req)
        {
            if (req.password.Length <= 3)
            {
                return BadRequest("密码长度必须大于3");
            }
            var result = await userService.CheckPassword(req.phone, req.password);
            switch (result)
            {
                case UserAccessResult.OK: return Ok("登陆成功");
                case UserAccessResult.PasswordError:
                case UserAccessResult.PhoneNotFound: return BadRequest("登陆失败");
                default: return BadRequest("其他");
            }
        }
    }
}
