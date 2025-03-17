using System;
using FluentValidation;

namespace EmployeesManager.User;

public class CreateUserRequest
{
    public int id {get;set;}
    public string username {get;set;}
    public string password{get;set;}
    public string email {get;set;}
}
public class CreateUsersvalidator:AbstractValidator<CreateUserRequest>{
    public CreateUsersvalidator(){
        RuleFor(x =>x.username).NotEmpty();
        RuleFor(x =>x.password).NotEmpty();
        RuleFor(x =>x.email).NotEmpty().EmailAddress();

    }}