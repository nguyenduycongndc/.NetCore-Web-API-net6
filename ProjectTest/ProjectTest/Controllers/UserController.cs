using Microsoft.AspNetCore.Mvc;
using ProjectTest.Attributes;
using ProjectTest.Common;
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

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("Search")]
        public async Task<ResultModel> Search([FromBody] SearchUserModel searchUserModel)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return ResUnAuthorized.Unauthor();
                }
                return await _userService.GetAllUser(searchUserModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                var data = new ResultModel()
                {
                    Message = "Not Found",
                    Code = 404,
                };
                return data;
            }
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ResultModel> Create([FromBody] CreateModel add)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return ResUnAuthorized.Unauthor();
                }
                return await _userService.CreateUser(add, _userInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                var data = new ResultModel()
                {
                    Message = "Not Found",
                    Code = 404,
                };
                return data;
            }
        }
        [HttpGet]
        [Route("Detail")]
        public ResultModel Detail(int id)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return ResUnAuthorized.Unauthor();
                }
                return _userService.GetDetailModels(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                var data = new ResultModel()
                {
                    Message = "Not Found",
                    Code = 404,
                };
                return data;
            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ResultModel> Update(UpdateModel updateModel)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return ResUnAuthorized.Unauthor();
                }
                return await _userService.UpdateUser(updateModel, _userInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                var data = new ResultModel()
                {
                    Message = "Not Found",
                    Code = 404,
                };
                return data;
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<ResultModel> Delete(int id)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return ResUnAuthorized.Unauthor();
                }
                return await _userService.DeleteUser(id, _userInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                var data = new ResultModel()
                {
                    Message = "Not Found",
                    Code = 404,
                };
                return data;
            }
        }
    }
}
