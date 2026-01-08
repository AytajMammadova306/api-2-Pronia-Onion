using FluentValidation;
using OnionPronia.Application.DTOs.AppUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.Validators
{
    public class LoginDtoValidator:AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(u => u.UsernameOrEmail)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(256)
                .Matches(@"^[A-Za-z0-9-.@+]*$");
            RuleFor(r => r.Password)
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}
