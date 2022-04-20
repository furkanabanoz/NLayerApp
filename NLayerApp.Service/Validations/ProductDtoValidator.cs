using FluentValidation;
using NLayerApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Service.Validations
{
    public class ProductDtoValidator:AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()//https://docs.fluentvalidation.net/en/latest/built-in-validators.html buradan bakarak baska validatorlar da bulaliriz
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            //Value type olanlara bir sekilde kural koyabilmek icin alttakini yapmamiz gerekir
            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
        }


    }
}
