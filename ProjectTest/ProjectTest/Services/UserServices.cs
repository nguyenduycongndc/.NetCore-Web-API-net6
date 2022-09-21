using ProjectTest.Model;
using ProjectTest.Repo.Interface;
using ProjectTest.Services.Interface;

namespace ProjectTest.Services
{
    public class UserServices : IUserService
    {
        private readonly ILogger<UserServices> _logger;
        private readonly IUserRepo userRepo;
        public UserServices(IUserRepo userRepo, ILogger<UserServices> logger)
        {
            this.userRepo = userRepo;
            _logger = logger;
        }
        public async Task<UserRsModel> GetAllUser(SearchUserModel searchUserModel)
        {
            var qr = await userRepo.GetAll(searchUserModel);
            List<UserModel> lst = new List<UserModel>();
            var listUser = qr.Select(x => new UserModel()
            {
                Id = x.Id,
                UserName = x.UserName,
                FullName = x.FullName,
                IsActive = x.IsActive,
            }).OrderBy(x => x.Id).ToList();
            var data = new UserRsModel()
            {
                Data = listUser,
                Count = listUser.Count(),
            };
            return data;
        }
    }
}
