using MediatR;
using UserMgr.Domain;
using UserMgr.Infrastracture;

namespace UserMgr.WebAPI
{
    public class UserAccessResultEventHandler : INotificationHandler<UserAccessResultEvent>
    {

        private readonly IServiceScopeFactory serviceScopeFactory;
        public UserAccessResultEventHandler(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }
        public async Task Handle(UserAccessResultEvent notification, CancellationToken cancellationToken)
        {
            using var scope = serviceScopeFactory.CreateScope();
            IUserRepository userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
            UserDbContext userDbContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
            await userRepository.AddNewLoginHistory(notification.Phone, $"登陆结果是{notification.Result}");
            await userDbContext.SaveChangesAsync();
        }
    }
}
