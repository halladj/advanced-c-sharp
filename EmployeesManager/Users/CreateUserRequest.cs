using FluentValidation;

namespace EmployeesManager.Users;

public class CreareUserRequest
{
    public int id {get; set;}
    public string? username {get; set;}
    public string? password {get; set;}
    public string? email {get; set;}
}

public class CreateUserValidator: AbstractValidator<CreareUserRequest>{
    public CreateUserValidator()
    {
        RuleFor(x => x.username).NotEmpty(); 
        RuleFor(x => x.password).NotEmpty(); 
        RuleFor(x => x.email).EmailAddress(); 
    }
}
