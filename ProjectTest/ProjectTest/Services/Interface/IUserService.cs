using ProjectTest.Model;

namespace ProjectTest.Services.Interface
{
    public interface IUserService
    {
        UserRsModel GetAllUser(SearchUserModel searchUserModel);
    }
}
