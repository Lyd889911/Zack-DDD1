using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserMgr.Domain;
using UserMgr.Domain.Entities;
using UserMgr.Infrastracture;

namespace UserMgr.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly UserDbContext userDbContext;
        public CRUDController(IUserRepository userRepository, UserDbContext userDbContext)
        {
            this.userRepository = userRepository;
            this.userDbContext = userDbContext;
        }
        [HttpPost]
        [UnitOfWork(typeof(UserDbContext))]
        public async Task<IActionResult> AddNewUser(AddUserRequest req)
        {
            if(await userRepository.FindOneAsync(req.phone) != null)
            {
                return BadRequest("手机号已经存在");
            }
            var user = new User(req.phone);
            user.ChangePassword(req.password);
            userDbContext.Users.Add(user);
            return Ok(user);
        }
    }
}
