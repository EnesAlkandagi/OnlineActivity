using Business.Abstract;
using Core.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkDal;
using Entities.Concrete;
using Entities.Dtos.Concrete.CategoryDtos;
using Entities.Dtos.Concrete.FirmDtos;
using Entities.Dtos.Concrete.UserDtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    internal class FirmManager : IFirmService
    {
        IFirmDal _firmDal;
        public FirmManager(IFirmDal firmDal)
        {
            _firmDal = firmDal;
        }



        public IDataResult<Firm> RegisterFirm(FirmRegisterDto firmCreateDto)
        {
            byte[] passwordHash, passwordSalt;

            var isFirmExist = _firmDal.Get(f => f.Name == firmCreateDto.Name);
            if (isFirmExist is not null)
            {
                return new ErrorDataResult<Firm>("Aynı isimde firma mevcuttur!");
            }
            if (!(firmCreateDto.Password.Length >= 8 && (firmCreateDto.Password.Any(Char.IsLetter) && firmCreateDto.Password.Any(Char.IsDigit))))
            {
                return new ErrorDataResult<Firm>("Parola en 8 karakter olmalı ayrıca harf ve sayı içermelidir.");
            }

            HashingHelper.CreatePasswordHash(firmCreateDto.Password, out passwordHash, out passwordSalt);
            var firm = new Firm()
            {
                Name = firmCreateDto.Name,
                Email = firmCreateDto.Email,
                Website = firmCreateDto.Website,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _firmDal.Add(firm);
            return new SuccessDataResult<Firm>(firm,"Firma başarıyla kaydedilmiştir.");
        }
    }
}
