using Business.Abstract;
using Entities.Dtos.Concrete.CityDtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineActivityMVC.Models;

namespace OnlineActivityMVC.Controllers;

public class LocationController : Controller
{
    private readonly ICityService _cityService;

    public LocationController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMÝN")]
    public IActionResult Index()
    {
        var result = _cityService.GetList();
        if (!result.Success) return View();
        var model = new CityViewModel
        {
            Cities = result.Data
        };
        return View(model);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMÝN")]
    [HttpPost]
    public IActionResult Add(CityAddDto cityAddDto)
    {
        var result = _cityService.Add(cityAddDto);
        return Json(new {success = result.Success, message = result.Message});
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMÝN")]
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var result = _cityService.Delete(id);
        return Json(new {success = result.Success, message = result.Message});
    }
}