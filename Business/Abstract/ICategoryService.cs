using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Concrete.CategoryDtos;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetList(CategoryFilterDto categoryFilterDto);
        IDataResult<Category> GetById(CategoryFilterDto categoryFilterDto);
        IResult Add(AddCategoryDto addCategoryDto);
        IDataResult<Category> Update(CategoryUpdateDto categoryUpdateDto);
        IResult Delete(int id);
    }
}