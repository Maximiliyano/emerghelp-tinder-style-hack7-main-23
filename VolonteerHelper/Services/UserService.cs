using VolonteerHelper.Api.Context;

namespace VolonteerHelper.Api.Services
{
    public class UserService : BaseService
    {
        public UserService(VolonteerDbContext context) : base(context) { }
    }
}