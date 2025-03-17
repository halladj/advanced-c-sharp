using System;

namespace EmployeesManager.Product;
using FluentValidation;
public class DeleteProductRequest
{
    public int Id { get; set; }
}

public class DeleteProductValidator : AbstractValidator<DeleteProductRequest>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}