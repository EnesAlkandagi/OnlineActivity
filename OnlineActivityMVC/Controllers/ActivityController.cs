using System.IdentityModel.Tokens.Jwt;
using Business.Abstract;
using Entities.Dtos.Concrete.ActivityDtos;
using Entities.Dtos.Concrete.CategoryDtos;
using Entities.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineActivityMVC.Models;

namespace OnlineActivityMVC.Controllers;

public class ActivityController : Controller
{
    private readonly IActivityService _activityService;
    private readonly ICategoryService _categoryService;
    private readonly ICityService _cityService;

    public ActivityController(IActivityService activityService, ICategoryService categoryService,
        ICityService cityService)
    {
        _activityService = activityService;
        _categoryService = categoryService;
        _cityService = cityService;
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "USER")]
    [HttpGet]
    public IActionResult Index(ActivityFilterDto activityFilterDto)
    {
        var result = _activityService.GetById(activityFilterDto);
        if (!result.Success) return View();
        var model = new ActivityViewModel
        {
            Activity = result.Data
        };
        return View(model);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "USER")]
    public IActionResult Create()
    {
        var categoryResult = _categoryService.GetList(new CategoryFilterDto());
        var cityResult = _cityService.GetList();
        var activityViewModel = new ActivityViewModel
        {
            Categories = categoryResult.Data,
            Cities = cityResult.Data
        };
        return View(activityViewModel);
    }

    [HttpPost]
    public IActionResult Create(ActivityViewModel activityViewModel)
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Auth");
        }

        var decodedToken = new JwtSecurityToken(token);

        activityViewModel.ActivityCreateDto.CreatedBy =
            Convert.ToInt32(decodedToken.Claims.First(c => c.Type.EndsWith("nameidentifier")).Value);

        var result = _activityService.Create(activityViewModel.ActivityCreateDto);
        if (!result.Success)
        {
            return Json(new {success = false, message = result.Message});
        }

        return Json(new {success = true, message = result.Message});
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "USER")]
    [HttpPost]
    public IActionResult Update(ActivityUpdateDto activityUpdateDto)
    {
        var result = _activityService.Update(activityUpdateDto);
        if (!result.Success)
        {
            Json(new {success = false, message = result.Message});
        }

        return Json(new {success = true, url = "Home/Index"});
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "USER")]
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var result = _activityService.Delete(id);
        if (!result.Success)
        {
            Json(new {success = false, message = result.Message});
        }

        return Json(new {success = true, url = "Home/Index"});
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "USER")]
    [HttpGet]
    public IActionResult WaitingApproveList()
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Auth");
        }

        var decodedToken = new JwtSecurityToken(token);

        var activityFilterDto = new ActivityFilterDto
        {
            CreatedBy = Convert.ToInt32(decodedToken.Claims.First(c => c.Type.EndsWith("nameidentifier")).Value),
        };

        var result = _activityService.GetList(activityFilterDto);
        return View(new ActivityViewModel
        {
            Activities = result.Data
        });
    }


    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMÝN")]
    [HttpGet]
    public IActionResult ApproveList()
    {
        var activityFilterDto = new ActivityFilterDto
        {
            ActivityStatus = ActivityStatus.WaitingForApproval
        };

        var result = _activityService.GetList(activityFilterDto);
        return View(new ActivityViewModel
        {
            Activities = result.Data
        });
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMÝN")]
    public IActionResult ApproveActivity(int id)
    {
        var activityStatusDto = new ActivityStatusDto
        {
            Id = id,
            ActivityStatus = ActivityStatus.Approved
        };

        var result = _activityService.UpdateActivityStatus(activityStatusDto);
        return RedirectToAction("ApproveList");
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMÝN")]
    public IActionResult RejectedActivity(int id)
    {
        var activityStatusDto = new ActivityStatusDto
        {
            Id = id,
            ActivityStatus = ActivityStatus.Cancel
        };

        var result = _activityService.UpdateActivityStatus(activityStatusDto);
        return RedirectToAction("ApproveList");
    }
}