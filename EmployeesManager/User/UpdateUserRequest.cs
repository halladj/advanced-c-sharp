using System;
using FluentValidation;

namespace EmployeesManager.User;

public class UpdateUserRequest
{
    public int id {get;set;}
    public string username {get;set;}
    public string password{get;set;}
    public string email {get;set;}
}
public class UpdateUserValidator:AbstractValidator<UpdateUserRequest>{
    public UpdateUserValidator(){
        RuleFor(x =>x.username).NotEmpty();
        RuleFor(x =>x.password).NotEmpty();
        RuleFor(x =>x.email).NotEmpty().EmailAddress();

    }}