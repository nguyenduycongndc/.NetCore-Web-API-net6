using ProjectTest.Model;

namespace ProjectTest.Repo.Interface
{
    public interface IFileRepo
    {
        Task<bool> AddNewFile(DataUpfile dataUpfile);
    }
}
