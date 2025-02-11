using System.ComponentModel.DataAnnotations;
using FluentValidation;

public class Employee
{
    public int Id {get; set;}
    public string? FirstName {get; set;}
    public string? LastName  {get; set;}
    public int salary {get; set;}
    public int age    {get; set;}

}

public class CreateEmployeeRequestValidator : AbstractValidator<Employee>
{
    public CreateEmployeeRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
    }
}