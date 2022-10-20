using ProjectTest.Model;
namespace ProjectTest.Services.Interface
{
    public interface ISendMailService
    {
        Task<bool> SendMailAsync(EmailDto emailDto);
    }
}
