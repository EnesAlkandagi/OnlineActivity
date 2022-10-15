using Entities.Dtos.Abstarct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Concrete.UserDtos
{
    public class UserLoginDto : AbstractValidator<UserLoginDto>, IDto
    {
        public UserLoginDto()
        {
            RuleFor(x => x.Email).EmailAddress().NotNull();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
        }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
