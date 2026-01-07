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
            
        }
    }
}
