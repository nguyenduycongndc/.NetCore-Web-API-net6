using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Data;
using ProjectTest.Model;
using ProjectTest.Repo.Interface;
using System.Diagnostics;
using System.Text;

namespace ProjectTest.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly SqlDbContext context;

        public UserRepo(SqlDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Users>> GetAll(SearchUserModel searchUserModel)
        {
            //return context.Users.ToList();
            List<Users> list;
            //string sql = "EXECUTE SP_USER";
            try
            {
                string sql = "EXECUTE SP_USER @user_name, @is_active, @start_number, @page_size";

                ////string sql = "EXECUTE SP_USER" +
                ////"@user_name = '" + searchUserModel.UserName + "'," +
                ////"@is_active = " + searchUserModel.IsActive + "," +
                ////"@start_number = " + searchUserModel.StartNumber + "," +
                ////"@page_size = " + searchUserModel.PageSize + ",";


                List<SqlParameter> parms = new List<SqlParameter>
                { 
                    // Create parameters    
                    new SqlParameter { ParameterName = "@user_name", Value = searchUserModel.UserName },
                    new SqlParameter { ParameterName = "@is_active", Value = searchUserModel.IsActive },
                    new SqlParameter { ParameterName = "@start_number", Value = searchUserModel.StartNumber },
                    new SqlParameter { ParameterName = "@page_size", Value = searchUserModel.PageSize }
                };
                list = await context.Users.FromSqlRaw<Users>(sql,parms.ToArray()).ToListAsync();

                ////List<SqlParameter> LstParam = new List<SqlParameter>();
                ////SqlParameter param = new SqlParameter();
                ////param = new SqlParameter("@user_name", searchUserModel.UserName);
                ////LstParam.Add(param);
                ////param = new SqlParameter("@is_active", searchUserModel.IsActive);
                ////LstParam.Add(param);
                ////param = new SqlParameter("@start_number", searchUserModel.StartNumber);
                ////LstParam.Add(param);
                ////param = new SqlParameter("@page_size", searchUserModel.PageSize);
                ////LstParam.Add(param);

                //list = await context.Users.FromSqlRaw<Users>(sql,parms.ToArray()).ToListAsync();
                //Debugger.Break();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public async Task<bool> CreateUs(Users user, UsersRoles usersRoles)
        public async Task<bool> CreateUs(UserCreateModel user)
        {
            try
            {
                string sql = "EXECUTE SP_CREATE_USER @user_name, @role_id, @password, @salt, @created_by";

                List<SqlParameter> parms = new List<SqlParameter>
                { 
                    // Create parameters    
                    new SqlParameter { ParameterName = "@user_name", Value = user.UserName },
                    new SqlParameter { ParameterName = "@role_id", Value = user.RoleId },
                    new SqlParameter { ParameterName = "@password", Value = user.PassWord },
                    new SqlParameter { ParameterName = "@salt", Value = user.SaltKey },
                    new SqlParameter { ParameterName = "@created_by", Value = user.CreatedBy },
                };

                var dt = await context.Database.ExecuteSqlRawAsync(sql, parms.ToArray());
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Users>> CheckUser(string userName)
        {
            List<Users> list;
            string sql = "EXECUTE SP_CHECK_USER @user_name";


            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters    
                new SqlParameter { ParameterName = "@user_name", Value = userName },
            };
            list = await context.Users.FromSqlRaw<Users>(sql, parms.ToArray()).ToListAsync();
            return list;
        }
        public Users GetDetail(int id)
        {
            var query = (from x in context.Users
                         where x.Id.Equals(id)
                         select new Users
                         {
                             Id = x.Id,
                             UserName = x.UserName,
                             Password = x.Password,
                             IsActive = x.IsActive,
                             RoleId = x.RoleId,
                             FullName = x.FullName,
                             Email = x.Email,
                         }).FirstOrDefault();

            return query;
        }
        public Users GetDetailByName(InputLoginModel inputModel)
        {
            var query = (from x in context.Users
                         where x.UserName.Equals(inputModel.UserName) && x.Password.Equals(inputModel.PassWord)
                         //where x.UserName.Equals(inputModel.UserName) && x.Password.Equals(EncodeServerName(inputModel.PassWord))
                         select new Users
                         {
                             Id = x.Id,
                             UserName = x.UserName,
                             FullName = x.FullName,
                             Password = x.Password,
                             IsActive = x.IsActive,
                             RoleId = x.RoleId,
                         }).FirstOrDefault();

            return query;
        }
        public static string EncodeServerName(string serverName)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(serverName));
        }
    }
}
