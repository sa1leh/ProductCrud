using FluentValidation;
using ProductCURD.products;

namespace ProductCURD.Products
{
    public class CreateUpdateProductValidator:AbstractValidator<CreateUpdateProductDto>
    {
        public CreateUpdateProductValidator() 
        {
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .MaximumLength(100)
                .WithErrorCode(ProductCURDDomainErrorCodes.Product_Name_IsValid)
                .WithMessage("Product Name is invalid");
            RuleFor(x => x.ProductDescription)
                 .MaximumLength(1000)
                 .WithErrorCode(ProductCURDDomainErrorCodes.Product_Description_IsValid)
                 .WithMessage("Product Name is invalid");
            
        }
    }
}
