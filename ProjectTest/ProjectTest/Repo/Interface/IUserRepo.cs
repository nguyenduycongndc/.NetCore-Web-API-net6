using ProjectTest.Data;
using ProjectTest.Model;
using System.Data;

namespace ProjectTest.Repo.Interface
{
    public interface IUserRepo
    {
        Task<List<Users>> GetAll(SearchUserModel searchUserModel);
        //Task<bool> CreateUs(Users user, UsersRoles usersRoles);
        Task<bool> CreateUs(UserCreateModel us);
        List<Users> CheckUser(string userName);
        Task<List<Roles>> CheckRoles(int RolesId);
        List<Users> GetDetail(int? id);
        List<Users> CheckEmail(string email);
        List<Users> CheckAllEmail();
        List<Users> CheckOTP(checkOTPModel checkOTPModel);
        Task<bool> UpdateUs(UserUpdateModel user);
        Task<bool> UpdateOTPUs(UserUpdateOTPModel userUpdateOTPModel);
        Task<bool> DeleteUs(int id, CurrentUserModel _userInfo);
        Task<bool> ForgotPassWordUs(ChangePassWordModel changePassWordModel);
        Task<bool> Register(RegisterSaltModel registerSaltModel);
        Task<bool> ChangePassWordRepo(ChangePassWordLoginSuccessModel changePassWordLoginSuccessModel);

        List<RsDetailUserModel> GetDetailUser(int? id);

        //public Users GetDetail(int id);
        //Users GetDetailByName(InputLoginModel inputModel);
    }
}
