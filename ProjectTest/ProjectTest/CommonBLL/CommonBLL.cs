using Microsoft.Data.SqlClient;
using ProjectTest.Data;
using System.Data;

namespace ProjectTest.CommonBLL
{
    public class CommonBLL
    {
        private readonly SqlDbContext con;

        public CommonBLL(SqlDbContext con)
        {
            this.con = con;
        }
        
    }
}
