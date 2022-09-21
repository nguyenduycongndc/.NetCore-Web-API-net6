using ProjectTest.Model;

namespace ProjectTest.Services.Interface
{
    public interface IUserService
    {
        Task<UserRsModel> GetAllUser(SearchUserModel searchUserModel);
        public Task<bool> CreateUse(CreateModel input, CurrentUserModel _userInfo);
        public CurrentUserModel GetDetailModels(int id);
    }
}
