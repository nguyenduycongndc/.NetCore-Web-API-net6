using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using ProjectTest.Model;
using ProjectTest.Services.Interface;
using MailKit.Net.Smtp;
using Org.BouncyCastle.Crypto.Macs;
using Microsoft.Identity.Client;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using System.Net;

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
        public async Task<bool> SendMailAsync(EmailDto emailDto)
        {
            try
            {
                //var client = new SmtpClient();
                //client.Connect(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                //var email = new MimeMessage();
                //email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUsername").Value));
                //email.To.Add(MailboxAddress.Parse(emailDto.To));
                //email.Subject = emailDto.Subject;
                //email.Body = new TextPart(TextFormat.Html) { Text = emailDto.Body };


                ////var oauth2 = new NetworkCredential(_configuration.GetSection("EmailUsername").Value, authToken.Token.AccessToken);
                ////client.Authenticate(oauth2);
                //// send email
                //client.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassWord").Value);
                //client.Send(email);
                //client.Disconnect(true);
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
