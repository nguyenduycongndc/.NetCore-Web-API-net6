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
        public UserRsModel GetAllUser(SearchUserModel searchUserModel)
        {
            var qr = userRepo.GetAll();
            List<UserModel> lst = new List<UserModel>();
            var listUser = qr.Where(x => (x.UserName.ToLower().Contains(searchUserModel.UserName.ToLower()) || string.IsNullOrEmpty(searchUserModel.UserName))
                                          && (searchUserModel.IsActive == -1 || (searchUserModel.IsActive == 1 ? x.IsActive == 1 : x.IsActive == 0))).Select(x => new UserModel()
                                          {
                                              Id = x.Id,
                                              UserName = x.UserName,
                                              FullName = x.FullName,
                                              IsActive = x.IsActive,
                                          }).OrderBy(x => x.Id).ToList();
            var count = listUser.Count();
            lst = listUser.Skip(searchUserModel.StartNumber).Take(searchUserModel.PageSize).ToList();
            var data = new UserRsModel()
            {
                Data = lst,
                Count = listUser.Count(),
            };
            return data;
        }
    }
}
