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

        public IDataResult<List<City>> GetList()
        {
            var cities = _cityDal.GetAll();
            return new SuccessDataResult<List<City>>(cities);
        }

        public IResult Add(CityAddDto cityAddDto)
        {
            var isCityExist = _cityDal.Get(c => c.Name.ToUpper().Equals(cityAddDto.Name.ToUpper()));
            if (isCityExist is not null)
            {
                return new ErrorResult("Aynı isimde lokasyon bulunuyor!");
            }

            var city = new City
            {
                Name = cityAddDto.Name,
            };
            _cityDal.Add(city);
            
            return new SuccessResult("Başarıyla eklendi!");
        }

        public IResult Delete(int id)
        {
            var isCityExist = _cityDal.Get(c => c.Id == id);
            if (isCityExist is null)
            {
                return new ErrorResult("Lokasyon bilgisi bulunamadı");
            }
            _cityDal.Delete(isCityExist);
            
            return new SuccessResult("Lokasyon silme işlemi başarıyla gerçekleşti.");
        }
    }
}
