using Microsoft.AspNetCore.Mvc;
using ProjectTest.Attributes;
using ProjectTest.Common;
using ProjectTest.Model;
using ProjectTest.Services;
using ProjectTest.Services.Interface;

namespace ProjectTest.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //[BaseAuthorize]
    public class IndividualController : Controller
    {
        private readonly ILogger<IndividualController> _logger;
        private readonly IIndividualService _individualService;
        public IndividualController(ILogger<IndividualController> logger, IIndividualService individualService)
        {
            _logger = logger;
            _individualService = individualService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
