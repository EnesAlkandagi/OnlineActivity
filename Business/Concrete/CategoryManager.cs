using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Concrete.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helpers;

namespace Business.Concrete
{
    internal class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        
        public IDataResult<List<Category>> GetList(CategoryFilterDto categoryFilterDto)
        {
            var predicate = PredicateBuilder.True<Category>();
            if (!string.IsNullOrEmpty(categoryFilterDto.Name))
            {
                predicate = predicate.And(p => p.Name == categoryFilterDto.Name);
            }

            if (categoryFilterDto.Id > 0)
            {
                predicate = predicate.And(c => c.Name.Contains(categoryFilterDto.Name));
            }

            var categoryList = _categoryDal.GetAll(predicate);
            return new SuccessDataResult<List<Category>>(categoryList);
        }

        public IDataResult<Category> GetById(CategoryFilterDto categoryFilterDto)
        {
            var category = _categoryDal.Get(c => c.Id == categoryFilterDto.Id);
            if (category is null) return new ErrorDataResult<Category>("Category not found");
            return new SuccessDataResult<Category>(category);
        }

        public IResult Add(AddCategoryDto addCategoryDto)
        {
            var isCategoryExist = _categoryDal.Get(x => x.Name.ToUpper().Equals(addCategoryDto.Name.ToUpper()));
            if (isCategoryExist is not null)
            {
                return new ErrorResult("Aynı isimde kategori bulunuyor!");
            }

            var category = new Category
            {
                Name = addCategoryDto.Name,
            };

            _categoryDal.Add(category);
            return new SuccessResult("Kategori başarıyla eklendi.");
        }

        public IDataResult<Category> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var isCategoryExist = _categoryDal.Get(c => c.Id == categoryUpdateDto.Id);
            if (isCategoryExist is null)
            {
                return new ErrorDataResult<Category>("Güncellemek istediğiniz kategori bulunamadı.");
            }

            var isCategoryNameExist = _categoryDal.Get(x => x.Name.ToUpper().Equals(categoryUpdateDto.Name.ToUpper()));

            if (isCategoryNameExist is not null)
            {
                return new ErrorDataResult<Category>("Güncellemek istediğiniz kategori ismi kullanılmaktadır.");
            }

            isCategoryExist.Name = categoryUpdateDto.Name;
            _categoryDal.Update(isCategoryExist);
            return new SuccessDataResult<Category>("Kategori başarıyla güncellendi.");
        }

        public IResult Delete(int id)
        {
            var isCategoryExist = _categoryDal.Get(c => c.Id == id);
            if (isCategoryExist is null)
            {
                return new ErrorResult("Kategori bulunamadı");
            }

            _categoryDal.Delete(isCategoryExist);
            return new SuccessResult("Kategori silme işlemi başarıyla gerçekleşti.");
        }
    }
}