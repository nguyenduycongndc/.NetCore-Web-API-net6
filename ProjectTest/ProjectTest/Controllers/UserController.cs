using Microsoft.AspNetCore.Mvc;
using ProjectTest.Model;
using ProjectTest.Services.Interface;
namespace ProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[BaseAuthorize]
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
        public UserRsModel Search([FromBody] SearchUserModel searchUserModel)
        {
            try
            {
                //if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                //{
                //    return null;
                //}
                return _userService.GetAllUser(searchUserModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
