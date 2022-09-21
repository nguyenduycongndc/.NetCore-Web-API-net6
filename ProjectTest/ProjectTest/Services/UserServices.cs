using ProjectTest.Data;
using ProjectTest.Model;
using ProjectTest.Repo.Interface;
using ProjectTest.Services.Interface;
using System.Text;
using System.Web.Helpers;

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
        public async Task<bool> CreateUse(CreateModel input, CurrentUserModel _userInfo)
        {
            try
            {
                var checkUser = await userRepo.CheckUser(input.UserName);
                if (checkUser.Count() > 0)
                {
                    _logger.LogError("Tài khoản đã tồn tại");
                    return false;
                }
                if (input.UserName == "" || input.UserName == null || input.Password == "" || input.Password == null)
                {
                    return false;
                }
                string salt = "";
                string hashedPassword = "";
                if (input != null)
                {
                    var pass = input.Password;
                    salt = Crypto.GenerateSalt(); // salt key
                    var password = input.Password + salt;
                    hashedPassword = Crypto.HashPassword(password);
                }
                //string salt = "123";
                //string hashedPassword = "";
                ////salt = Crypto.GenerateSalt(); // salt key
                //var password = input.Password/* + salt*/;
                //hashedPassword = EncodeServerName(password);
                Users us = new Users()
                {
                    FullName = input.UserName.Trim(),
                    UserName = input.UserName.ToLower(),
                    Password = hashedPassword,
                    IsActive = 1,
                    DateOfJoining = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    SaltKey = salt,
                    RoleId = input.RoleId,
                    CreatedBy = _userInfo.Id,
                };
                var _userrole = new UsersRoles
                {
                    roles_id = input.RoleId,
                    Users = us
                };
                return await userRepo.CreateUs(us, _userrole);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public CurrentUserModel GetDetailModels(int Id)
        {
            try
            {
                var data = userRepo.GetDetail(Id);

                var detailUs = new CurrentUserModel()
                {
                    Id = data.Id,
                    UserName = data.UserName,
                    FullName = data.FullName,
                    IsActive = data.IsActive,
                    Email = data.Email,
                    RoleId = data.RoleId,
                };

                return detailUs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        public static string EncodeServerName(string serverName)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(serverName));
        }
    }
}
