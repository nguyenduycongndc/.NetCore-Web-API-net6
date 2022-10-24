using ProjectTest.Model;
using ProjectTest.Services.Interface;
using System.Net;
using System.Net.Mail;

namespace ProjectTest.Services
{
    public class SendMailService : ISendMailService
    {
        private readonly ILogger<SendMailService> _logger;
        private readonly IConfiguration _configuration;
        public SendMailService(IConfiguration configuration, ILogger<SendMailService> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public bool SendMailAsync(EmailDto emailDto)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.Subject = emailDto.Subject;
                mailMessage.Body = emailDto.Body;
                mailMessage.From = new MailAddress(_configuration.GetSection("EmailUsername").Value);
                mailMessage.To.Add(new MailAddress(emailDto.To));
                mailMessage.IsBodyHtml = true;
                var smtpClient = new SmtpClient(_configuration.GetSection("EmailHost").Value)
                {
                    Port = 587,
                    Credentials = new NetworkCredential(_configuration.GetSection("EmailUsername").Value, _configuration.GetSection("EmailPassword").Value),
                    EnableSsl = true,
                };
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
