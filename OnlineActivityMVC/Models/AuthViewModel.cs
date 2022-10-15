using Entities.Dtos.Concrete.UserDtos;

namespace OnlineActivityMVC.Models
{
    public class AuthViewModel
    {
        public UserRegisterDto userRegisterDto { get; set; }
        public UserLoginDto userLoginDto { get; set; }
    }
}
