using Business.Abstract;
using Core.Utilities.JWT;
using Microsoft.AspNetCore.Mvc;
using OnlineActivityMVC.Models;

namespace OnlineActivityMVC.Controllers
{
    public class AuthController : Controller
    {
        IAuthService _authService;
        IFirmService _firmService;

        public AuthController(IAuthService authService, IFirmService firmService)
        {
            _authService = authService;
            _firmService = firmService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthViewModel authViewModel)
        {
            var result = _authService.Login(authViewModel.userLoginDto);
            if (!result.Success) return Json(new {success = false, message = result.Message});
            HttpContext.Session.SetString("Token", result.Data.Token);
            return Json(new {success = true, url = "Home/Index"});
        }

        [HttpPost]
        public IActionResult Register(AuthViewModel authViewModel)
        {
            //if (ModelState.IsValid)
            //{
            //    var result = _authService.Register(authViewModel.userRegisterDto);
            //    if (result.Success)
            //    {
            //        return Json(new { success = true, message = result.Message });
            //    }
            //    return Json(new { success = false, message = result.Message });
            //}
            //return BadRequest(ModelState);

            var result = _authService.Register(authViewModel.userRegisterDto);
            if (result.Success)
            {
                return Json(new {success = true, message = result.Message});
            }

            return Json(new {success = false, message = result.Message});
        }

        [HttpPost]
        public IActionResult RegisterFirm(AuthViewModel authViewModel)
        {
            var result = _firmService.RegisterFirm(authViewModel.firmRegisterDto);
            if (result.Success)
            {
                return Json(new { success = true, message = result.Message });
            }
            return Json(new { success = false, message = result.Message });
        }
    }
}
