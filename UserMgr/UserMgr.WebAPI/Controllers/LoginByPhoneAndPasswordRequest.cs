using UserMgr.Domain.ValueObjects;

namespace UserMgr.WebAPI.Controllers
{
    public record LoginByPhoneAndPasswordRequest(Phone phone,string password);
}
