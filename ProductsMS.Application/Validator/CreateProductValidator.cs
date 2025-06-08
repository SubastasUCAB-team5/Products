using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMS.Commons.Dtos.Request;

namespace ProductMS.Application.Validator
{
    public class CreateUserValidator : ValidatorBase<CreateProductDto>
    {
        public CreateUserValidator()
        {
            RuleFor(s => s.Name).NotNull().WithMessage("Name no puede ser nulo").WithErrorCode("040");
            RuleFor(s => s.Name).NotEmpty().WithMessage("Name no puede estar vacio").WithErrorCode("041");
            RuleFor(s => s.Name).MinimumLength(3).WithMessage("Name debe tener al menos 3 caracteres").WithErrorCode("042");
            RuleFor(s => s.Name).MaximumLength(50).WithMessage("Name no puede tener más de 50 caracteres").WithErrorCode("043");
            RuleFor(s => s.Description).NotNull().WithMessage("Description no puede ser nulo").WithErrorCode("044");
            RuleFor(s => s.Description).NotEmpty().WithMessage("Description no puede estar vacio").WithErrorCode("045");
            RuleFor(s => s.Description).MinimumLength(3).WithMessage("Description debe tener al menos 3 caracteres").WithErrorCode("046");
            RuleFor(s => s.Description).MaximumLength(500).WithMessage("Description no puede tener más de 500 caracteres").WithErrorCode("047");
            RuleFor(s => s.BasePrice).NotNull().WithMessage("BasePrice no puede ser nulo").WithErrorCode("048");
            RuleFor(s => s.BasePrice).NotEmpty().WithMessage("BasePrice no puede estar vacio").WithErrorCode("049");
            RuleFor(s => s.BasePrice).Matches(@"^\d+(\.\d{1,2})?$").WithMessage("BasePrice debe ser un número decimal con hasta 2 decimales").WithErrorCode("050");
            RuleFor(s => s.Category).NotNull().WithMessage("Category no puede ser nulo").WithErrorCode("051");
            RuleFor(s => s.Category).NotEmpty().WithMessage("Category no puede estar vacio").WithErrorCode("052");
            RuleFor(s => s.Category).MinimumLength(3).WithMessage("Category debe tener al menos 3 caracteres").WithErrorCode("053");
            RuleFor(s => s.Category).MaximumLength(50).WithMessage("Category no puede tener más de 50 caracteres").WithErrorCode("054");
            RuleFor(s => s.Images).NotNull().WithMessage("Images no puede ser nulo").WithErrorCode("055");
            RuleFor(s => s.Images).NotEmpty().WithMessage("Images no puede estar vacio").WithErrorCode("056");
            RuleFor(s => s.Images).Must(x => x.Count <= 5).WithMessage("Images no puede tener más de 5 elementos").WithErrorCode("057");
            RuleFor(s => s.Images).Must(x => x.All(i => i.Length <= 200)).WithMessage("Cada imagen no puede tener más de 200 caracteres").WithErrorCode("058");
            RuleFor(s => s.Images).Must(x => x.All(i => i.StartsWith("http") || i.StartsWith("https"))).WithMessage("Cada imagen debe ser una URL válida").WithErrorCode("059");
            RuleFor(s => s.Images).Must(x => x.All(i => i.EndsWith(".jpg") || i.EndsWith(".png") || i.EndsWith(".jpeg") || i.EndsWith(".webp"))).WithMessage("Cada imagen debe ser una URL válida").WithErrorCode("060");
        }
    }
}

