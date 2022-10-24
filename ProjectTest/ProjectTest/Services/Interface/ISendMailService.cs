using ProjectTest.Model;
namespace ProjectTest.Services.Interface
{
    public interface ISendMailService
    {
        bool SendMailAsync(EmailDto emailDto);
    }
}
