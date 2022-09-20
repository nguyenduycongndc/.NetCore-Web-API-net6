using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Data;
using ProjectTest.Model;
using ProjectTest.Repo.Interface;
using System.Diagnostics;

namespace ProjectTest.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly SqlDbContext context;

        public UserRepo(SqlDbContext context)
        {
            this.context = context;
        }
        public List<Users> GetAll(SearchUserModel searchUserModel)
        {
            //return context.Users.ToList();
            List<Users> list;
            //string sql = "EXECUTE SP_USER";

            string sql = "EXECUTE SP_USER" +
            "@user_name = '" + searchUserModel.UserName + "'," +
            "@is_active = " + searchUserModel.IsActive + "," +
            "@start_number = " + searchUserModel.StartNumber + "," +
            "@page_size = " + searchUserModel.PageSize + ",";

            //List<SqlParameter> LstParam = new List<SqlParameter>();
            //SqlParameter param = new SqlParameter();
            //param = new SqlParameter("@user_name", searchUserModel.UserName);
            //LstParam.Add(param);
            //param = new SqlParameter("@is_active", searchUserModel.IsActive);
            //LstParam.Add(param);
            //param = new SqlParameter("@start_number", searchUserModel.StartNumber);
            //LstParam.Add(param);
            //param = new SqlParameter("@page_size", searchUserModel.PageSize);
            //LstParam.Add(param);

            list = context.Users.FromSqlRaw<Users>(sql).ToList();
            //Debugger.Break();
            return list;
        }
    }
}
