using ProjectTest.Data;
using ProjectTest.Model;

namespace ProjectTest.Repo.Interface
{
    public interface IUserRepo
    {
        List<Users> GetAll(SearchUserModel searchUserModel);
    }
}
