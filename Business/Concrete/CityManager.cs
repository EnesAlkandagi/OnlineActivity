using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Concrete.CategoryDtos;
using Entities.Dtos.Concrete.CityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    internal class CityManager : ICityService
    {
        private ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public City GetByName(string name)
        {
            return _cityDal.Get(c => c.Name == name);
        }
        public IResult CityAdd(CityAddDto cityAddDto)
        {
            var isCityExist = GetByName(cityAddDto.Name);
            if (isCityExist is not null)
            {
                return new ErrorResult("Aynı isimde şehir bulunuyor!");
            }

            var city = new City
            {
                Name = cityAddDto.Name,
            };
            return new SuccessResult();
        }

        public IResult CityDelete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessResult("Kategori silme işlemi başarıyla gerçekleşti.");
        }
    }
}
