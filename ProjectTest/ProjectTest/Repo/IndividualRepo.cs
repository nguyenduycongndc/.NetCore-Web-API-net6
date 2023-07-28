using ProjectTest.Data;
using ProjectTest.Repo.Interface;

namespace ProjectTest.Repo
{
    public class IndividualRepo : IIndividualRepo
    {
        private readonly SqlDbContext context;

        public IndividualRepo(SqlDbContext context)
        {
            this.context = context;
        }
    }
}
