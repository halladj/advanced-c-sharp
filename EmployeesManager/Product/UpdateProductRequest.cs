using System;

namespace EmployeesManager.Product;
using FluentValidation;
public class UpdateProductRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }

}
public class UpdateProductsValidator:AbstractValidator<UpdateProductRequest>{
    public UpdateProductsValidator(){
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.StockQuantity).GreaterThanOrEqualTo(0);
    }}