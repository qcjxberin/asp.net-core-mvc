using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wkmvc.Services.ComServices;
using wkmvc.Data.ViewModels;
using wkmvc.Data.CommonModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace wkmvc.Areas.SysManage.Controllers
{
    [Area("SysManage")]
    public class AccountController : Controller
    {
        public readonly VierificationCodeServices _vierificationCodeServices;

        public AccountController(VierificationCodeServices vierificationCodeServices)
        {
            _vierificationCodeServices = vierificationCodeServices;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel entity)
        {
            var json = new JsonModel() { Msg = "登录成功", Status = false };

            return Json(json);
        }

        public IActionResult ValidateCode()
        {
            string code = "";
            System.IO.MemoryStream ms = _vierificationCodeServices.Create(out code);
            Response.Body.Dispose();
            return File(ms.ToArray(), @"image/png");
        }
    }
}
