using System.IdentityModel.Tokens.Jwt;
using Business.Abstract;
using Entities.Dtos.Concrete.ActivityDtos;
using Entities.Dtos.Concrete.UserActivityDtos;
using Microsoft.AspNetCore.Mvc;
using OnlineActivityMVC.Models;

namespace OnlineActivityMVC.Controllers;

public class UserActivityController : Controller
{
    private readonly IUserActivityService _userActivityService;

    public UserActivityController(IUserActivityService userActivityService)
    {
        _userActivityService = userActivityService;
    }

    public IActionResult Index()
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Auth");
        }

        var decodedToken = new JwtSecurityToken(token);

        var userActivityFilterDto = new UserActivityFilterDto
        {
            UserId = Convert.ToInt32(decodedToken.Claims.First(c => c.Type.EndsWith("nameidentifier")).Value),
        };

        var pastResult = _userActivityService.GetAllPastActivityByUserId(userActivityFilterDto);
        var currentResult = _userActivityService.GetAllCurrentActivityByUserId(userActivityFilterDto);
        if (!pastResult.Success && !currentResult.Success) return View();
        var model = new UserActivityViewModel
        {
            PastUserActivities = pastResult.Data,
            CurrentUserActivities = currentResult.Data
        };
        return View(model);
    }

    public IActionResult JoinActivity(int id)
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Auth");
        }

        var decodedToken = new JwtSecurityToken(token);

        var model = new JoinActivityDto
        {
            ActivityId = id,
            UserId = Convert.ToInt32(decodedToken.Claims.First(c => c.Type.EndsWith("nameidentifier")).Value),
        };

        var result = _userActivityService.JoinActivity(model);
        if (result.Success)
        {
            return Redirect($"/Activity/Index?Id={id}");
        }
        else
        {
            return BadRequest(result.Message);
        }
    }
}