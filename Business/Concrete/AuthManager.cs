using Business.Abstract;
using Core.Utilities.JWT;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Concrete.UserDtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserDal _userDal;
        private IUserService _userService;
        private IUserRoleDal _userRoleDal;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserDal userDal, IUserService userService, ITokenHelper tokenHelper,
            IUserRoleDal userRoleDal)
        {
            _userDal = userDal;
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userRoleDal = userRoleDal;
        }

        public IDataResult<AccessToken> Login(UserLoginDto userLoginDto)
        {
            var isUserExist = _userDal.Get(x => x.Email.Equals(userLoginDto.Email));
            if (isUserExist is null)
            {
                return new ErrorDataResult<AccessToken>("Kullanıcı bulunamadı. Lütfen kayıt olunuz.");
            }

            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, isUserExist.PasswordHash,
                    isUserExist.PasswordSalt))
            {
                return new ErrorDataResult<AccessToken>("Hatalı parola!");
            }

            var claims = _userDal.GetClaims(isUserExist);
            var accessToken = _tokenHelper.CreateToken(isUserExist, claims);
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IDataResult<User> Register(UserRegisterDto userRegisterDto)
        {
            byte[] passwordHash, passwordSalt;

            var existEmail = _userDal.Get(u => u.Email == userRegisterDto.Email);

            if (existEmail is not null)
            {
                return new ErrorDataResult<User>("Bu mail adresi kullanılmaktadır.");
            }
            if (userRegisterDto.Password.Length < 8 && (!userRegisterDto.Password.Any(Char.IsLetter) || !userRegisterDto.Password.Any(Char.IsDigit)))
            {
                return new ErrorDataResult<User>("Parola en 8 karakter olmalı ayrıca harf ve sayı içermelidir.");
            }

            HashingHelper.CreatePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Email = userRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            _userDal.Add(user);

            var savedUser = _userService.GetByEmail(userRegisterDto.Email);

            var userClaim = new UserRole
            {
                UserId = savedUser.Id,
                RoleId = 1
            };

            _userRoleDal.Add(userClaim);

            return new SuccessDataResult<User>(user);
        }
    }
}