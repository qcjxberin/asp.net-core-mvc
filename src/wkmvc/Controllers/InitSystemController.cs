using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wkmvc.Services.SysServices;
using wkmvc.Services.InitalServices;

namespace wkmvc.Controllers
{
    public class InitSystemController : Controller
    {
        public readonly SysUserServices _sysUserServices;
        public readonly InitalSystemServices _initalSystemServices;

        public InitSystemController(SysUserServices sysUserServices, InitalSystemServices initalSystemServices)
        {
            _sysUserServices = sysUserServices;
            _initalSystemServices = initalSystemServices;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
