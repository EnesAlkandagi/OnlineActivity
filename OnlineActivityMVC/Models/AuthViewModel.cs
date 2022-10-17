using Entities.Dtos.Concrete.FirmDtos;
using Entities.Dtos.Concrete.UserDtos;

namespace OnlineActivityMVC.Models
{
    public class AuthViewModel
    {
        public UserRegisterDto userRegisterDto { get; set; }
        public UserLoginDto userLoginDto { get; set; }
        public FirmRegisterDto firmRegisterDto { get; set; }
    }
}
