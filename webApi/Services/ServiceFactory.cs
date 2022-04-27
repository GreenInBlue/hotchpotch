using webApi.Services.impl;

namespace webApi.Services
{
    public class ServiceFactory
    {
        public static IUserService UserService { get { return new UserServiceImpl(); } }
    }
}
