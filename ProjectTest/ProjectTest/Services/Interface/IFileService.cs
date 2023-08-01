using ProjectTest.Common;
using ProjectTest.Model;

namespace ProjectTest.Services.Interface
{
    public interface IFileService
    {
        Task<ResultModel> AddFileOrder(Upfile fileModel, CurrentUserModel _userInfo);
    }
}
