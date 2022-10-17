using Business.Abstract;
using Entities.Dtos.Concrete.CategoryDtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineActivityMVC.Models;

namespace OnlineActivityMVC.Controllers;

//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "USER")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }


    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMÝN")]
    [HttpGet]
    public IActionResult Index(CategoryFilterDto categoryFilterDto)
    {
        var result = _categoryService.GetList(categoryFilterDto);
        if (!result.Success) return View();
        var model = new CategoryViewModel
        {
            Categories = result.Data
        };
        return View(model);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMÝN")]
    [HttpPost]
    public IActionResult Add(AddCategoryDto addCategoryDto)
    {
        var result = _categoryService.Add(addCategoryDto);
        return Json(new {success = result.Success, message = result.Message});
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMÝN")]
    [HttpPost]
    public IActionResult Update(CategoryUpdateDto categoryUpdateDto)
    {
        var result = _categoryService.Update(categoryUpdateDto);
        return Json(new {success = result.Success, message = result.Message});
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMÝN")]
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var result = _categoryService.Delete(id);
        return Json(new {success = result.Success, message = result.Message});
    }
}