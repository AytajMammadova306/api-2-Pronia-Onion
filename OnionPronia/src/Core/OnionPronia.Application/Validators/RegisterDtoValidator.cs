using FluentValidation;
using OnionPronia.Application.DTOs.AppUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.Validators
{
    public class RegisterDtoValidator:AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(3)
                .Matches(@"^[A-Za-z]*$");
            RuleFor(r => r.Surname)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(3)
                .Matches(@"^[A-Za-z]*$");
            RuleFor(r => r.Email)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(256)
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            RuleFor(r => r.Username)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(256)
                .Matches(@"^[A-Za-z0-9-.@+]*$");
            RuleFor(r => r.Password)
                .NotEmpty()
                .MinimumLength(8);
            RuleFor(r => r)
                .Must(r => r.ConfirmPassword == r.Password);
                
            
        }
    }
}
