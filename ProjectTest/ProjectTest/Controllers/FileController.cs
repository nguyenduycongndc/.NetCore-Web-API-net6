using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Attributes;
using ProjectTest.Common;
using ProjectTest.Model;
using ProjectTest.Services;
using ProjectTest.Services.Interface;

namespace ProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BaseAuthorize]
    public class FileController : Controller
    {
        private readonly ILogger<FileController> _logger;
        private readonly IFileService _ifileservice;
        public FileController(ILogger<FileController> logger, IFileService fileService)
        {
            _logger = logger;
            _ifileservice = fileService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("UploadFile")]
        public async Task<ResultModel> UploadFile([FromForm] Upfile upfile)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return ResUnAuthorized.Unauthor();
                }
                return await _ifileservice.AddFileOrder(upfile, _userInfo);
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
