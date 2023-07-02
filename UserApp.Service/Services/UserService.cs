using Microsoft.EntityFrameworkCore;
using UserApp.Data.UoW;
using UserApp.EFCore.Models;
using UserApp.Model.CommandModels;
using UserApp.Model.QueryModels;

namespace UserApp.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserViewModel> GetByEmail(GetUserByEmailRequest request)
        {
            var userRepo = _unitOfWork.GetRepository<User>();

            var dbUser = await userRepo.FindBy(u => u.Email.Equals(request.Email)).SingleOrDefaultAsync();
            var user = new UserViewModel()
            {
                Id = dbUser.Id
            };
            return user;
        }
    }
}
