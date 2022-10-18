using ProjectTest.Data;
using ProjectTest.Model;

namespace ProjectTest.Repo.Interface
{
    public interface IUserRepo
    {
        Task<List<Users>> GetAll(SearchUserModel searchUserModel);
        //Task<bool> CreateUs(Users user, UsersRoles usersRoles);
        Task<bool> CreateUs(UserCreateModel us);
        List<Users> CheckUser(string userName);
        Task<List<Roles>> CheckRoles(int RolesId);
        List<Users> GetDetail(int id);
        Task<bool> UpdateUs(UserUpdateModel user);

        //public Users GetDetail(int id);
        //Users GetDetailByName(InputLoginModel inputModel);
    }
}
