using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ProjectTest.Attributes;
using ProjectTest.Model;
using ProjectTest.Services.Interface;
using ProjectTest.Common;

namespace ProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginService _loginServices;

        public LoginController(ILogger<LoginController> logger, ILoginService loginServices)
        {
            _logger = logger;
            _loginServices = loginServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("LoginUser")]
        public ResultModel LoginUser([FromBody] InputLoginModel inputModel)
        {
            var _login = _loginServices.Login(inputModel);
            if (_login != null)
            {
                HttpContext.Session.SetString("SessionToken", _login.Token);
            }
            return _login;
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Login");
        }
    }
}
