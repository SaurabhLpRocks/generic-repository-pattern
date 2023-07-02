using UserApp.Model.CommandModels;
using UserApp.Model.QueryModels;

namespace UserApp.Service.Services
{
    public interface IUserService
    {
        Task<UserViewModel> GetByEmail(GetUserByEmailRequest request);
    }
}