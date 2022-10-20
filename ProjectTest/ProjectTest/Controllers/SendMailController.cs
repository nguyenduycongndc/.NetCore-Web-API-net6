using Microsoft.AspNetCore.Mvc;
using ProjectTest.Attributes;
using ProjectTest.Model;
using ProjectTest.Services.Interface;

namespace ProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BaseAuthorize]
    public class SendMailController : Controller
    {
        private readonly ILogger<SendMailController> _logger;

        private readonly ISendMailService _sendMailService;
        public SendMailController(ILogger<SendMailController> logger, ISendMailService sendMailService)
        {
            _logger = logger;
            _sendMailService = sendMailService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("SendMail")]
        public async Task<IActionResult> SendMail(EmailDto emailDto)
        {
            await _sendMailService.SendMailAsync(emailDto);
            return Ok();
        }
    }
}
