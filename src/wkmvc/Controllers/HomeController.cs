using Microsoft.AspNetCore.Mvc;
using wkmvc.Data;
using wkmvc.Redis;
using wkmvc.Services.ConfigServices;
using wkmvc.Services.SysServices;

namespace wkmvc.Controllers
{
    public class HomeController : Controller
    {
        public readonly SysUserServices _sysUserServices;

        public readonly AppConfigurtaionServices _AppConfigurtaionServices;

        public readonly ICacheService _cacheService;

        public HomeController(SysUserServices sysUserServices, AppConfigurtaionServices AppConfigurtaionServices, ICacheService CacheService)
        {
            _sysUserServices = sysUserServices;
            _AppConfigurtaionServices = AppConfigurtaionServices;
            _cacheService = CacheService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _AppConfigurtaionServices.GetAppSettings<ApplicationConfiguration>("siteconfig").FileUpPath;
            ViewData["Message2"] = Common.FileHelper.MapPath("/Views/Home/Index.cshml");

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
