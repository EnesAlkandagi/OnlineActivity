using Entities.Concrete;
using Entities.Dtos.Concrete.CategoryDtos;

namespace OnlineActivityMVC.Models;

public class CategoryViewModel
{
    public List<Category> Categories { get; set; }
    public AddCategoryDto AddCategoryDto { get; set; }
    public CategoryUpdateDto CategoryUpdateDto { get; set; }
    public CategoryFilterDto CategoryFilterDto { get; set; }
}