using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Data;
using ProjectTest.Model;
using ProjectTest.Repo.Interface;

namespace ProjectTest.Repo
{
    public class FileRepo : IFileRepo
    {
        private readonly SqlDbContext context;
        public FileRepo(SqlDbContext context)
        {
            this.context = context;
        }
        #region Add New File
        public async Task<bool> AddNewFile(DataUpfile dataUpfile)
        {
            try
            {
                //string sql = "EXECUTE SP_CREATE_USER @user_name, @role_id, @password, @salt, @created_by";

                //List<SqlParameter> parms = new List<SqlParameter>
                //{ 
                //    // Create parameters    
                //    new SqlParameter { ParameterName = "@user_name", Value = user.UserName },
                //    new SqlParameter { ParameterName = "@role_id", Value = user.RoleId },
                //    new SqlParameter { ParameterName = "@password", Value = user.PassWord },
                //    new SqlParameter { ParameterName = "@salt", Value = user.SaltKey },
                //    new SqlParameter { ParameterName = "@created_by", Value = user.CreatedBy },
                //};

                //var dt = await context.Database.ExecuteSqlRawAsync(sql, parms.ToArray());
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
