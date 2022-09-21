﻿using Microsoft.AspNetCore.Mvc;
using ProjectTest.Attributes;
using ProjectTest.Model;
using ProjectTest.Services.Interface;
namespace ProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BaseAuthorize]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService loginService)
        {
            _logger = logger;
            _userService = loginService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("Search")]
        public async Task<UserRsModel> Search([FromBody] SearchUserModel searchUserModel)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                return await _userService.GetAllUser(searchUserModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        [HttpPost]
        [Route("Create")]
        public async Task<bool> Create([FromBody] CreateModel add)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return false;
                }
                return await _userService.CreateUse(add, _userInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
