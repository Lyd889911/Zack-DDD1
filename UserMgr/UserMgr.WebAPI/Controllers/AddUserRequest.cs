using UserMgr.Domain.ValueObjects;

namespace UserMgr.WebAPI.Controllers
{
    public record AddUserRequest(Phone phone,string password);
}
