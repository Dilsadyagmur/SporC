using Microsoft.AspNetCore.Mvc;
using SporC.Web.Models;
using System.Diagnostics;


namespace Tricount.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
//using Microsoft.AspNetCore.Mvc;
//using SporC.BL.Abstract;
//using SporC.BL.Concrete;
//using SporC.Web.Models;
//using System.Diagnostics;

//namespace SporC.Web.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;
//        private readonly IPostManager postManager;

//        public HomeController(ILogger<HomeController> logger/*,IPostManager postManager*/)
//        {
//            _logger = logger;
//            //this.postManager = postManager;
//        }

//        public async  Task<IActionResult> Index()
//        {
//            //var result = postManager.GetAllInclude(null, p => p.Comments).Result.ToList();
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}