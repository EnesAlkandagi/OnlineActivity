using Business.Abstract;
using Entities.Dtos.Concrete.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using OnlineActivityMVC.Models;

namespace OnlineActivityMVC.ViewComponents;

public class DashboardFilterViewComponent : ViewComponent
{
    private readonly ICategoryService _categoryService;
    private readonly ICityService _cityService;

    public DashboardFilterViewComponent(ICategoryService categoryService, ICityService cityService)
    {
        _categoryService = categoryService;
        _cityService = cityService;
    }

    public ViewViewComponentResult Invoke()
    {
        var categories = _categoryService.GetList(new CategoryFilterDto());
        var cities = _cityService.GetList();
        var model = new DashboardFilterViewModel
        {
            Categories = categories.Data,
            Cities = cities.Data
        };
        return View(model);
    }
}