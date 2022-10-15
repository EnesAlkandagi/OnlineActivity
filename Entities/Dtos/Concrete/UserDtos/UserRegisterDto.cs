using Entities.Dtos.Abstarct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Concrete.UserDtos
{
    public class UserRegisterDto : AbstractValidator<UserRegisterDto>, IDto
    {
        //public UserRegisterDto()
        //{
        //    //RuleFor(x => x.FirstName).NotNull();
        //    //RuleFor(x => x.LastName).NotNull();
        //    //RuleFor(x => x.Email).EmailAddress().NotNull();
        //    //RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithMessage("Your password length must be at least 8.")
        //    //    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
        //    //    .Matches(@"[a-z][A-Z]+").WithMessage("Your password must contain at least one uppercase letter.");
        //    //RuleFor(x => x.ConfirmPassword).NotNull().Equals(Password);
        //}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
