using Microsoft.AspNetCore.Mvc;
using OnlineActivityMVC.Models;
using System.Diagnostics;
using Business.Abstract;
using Entities.Dtos.Concrete.ActivityDtos;
using Entities.Dtos.Concrete.CategoryDtos;
using Entities.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace OnlineActivityMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActivityService _activityService;


        public HomeController(ILogger<HomeController> logger, IActivityService activityService)
        {
            _activityService = activityService;
        }


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "USER")]
        [HttpGet]
        public IActionResult Index([FromQuery] ActivityFilterDto activityFilterDto)
        {
            activityFilterDto.ActivityStatus = ActivityStatus.Approved;
            var activityResult = _activityService.GetList(activityFilterDto);
            var activityViewModel = new ActivityViewModel
            {
                Activities = activityResult.Data
            };
            return View(activityViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}