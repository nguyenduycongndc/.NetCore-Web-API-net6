using Microsoft.EntityFrameworkCore;
using ProjectTest.Data;
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
        public List<Users> GetAll()
        {
            //return context.Users.ToList();
            List<Users> list;
            string sql = "EXEC SP_USER";
            list = context.Users.FromSqlRaw<Users>(sql).ToList();
            //Debugger.Break();
            return list;
        }
    }
}
