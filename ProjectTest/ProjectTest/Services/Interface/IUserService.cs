using ProjectTest.Model;

namespace ProjectTest.Services.Interface
{
    public interface IUserService
    {
        Task<UserRsModel> GetAllUser(SearchUserModel searchUserModel);
    }
}
