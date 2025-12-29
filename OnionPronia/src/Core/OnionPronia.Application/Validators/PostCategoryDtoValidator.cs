using FluentValidation;
using OnionPronia.Application.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.Validators
{
    public class PostCategoryDtoValidator:AbstractValidator<PostCategoryDto>
    {
        private const int MAX_LIMIT = 150;
        private const int MIN_LIMIT = 2;
        public PostCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name is required")
                .MaximumLength(MAX_LIMIT)
                    .WithMessage("Name must be less than 150")
                .MinimumLength(MIN_LIMIT)
                    .WithMessage("Name must be more than 1 characters")
                .Matches(@"^[A-Za-z0-9\s]*$");
                //.Must(CheckName)
                //    .WithMessage("Custom Yoxlama");
        }
        //public bool CheckName(string name)
        //{
        //    return name.Contains("t") && name.StartsWith("C");
        //}
    }
}
