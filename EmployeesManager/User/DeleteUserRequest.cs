using System;
using FluentValidation;

namespace EmployeesManager.User;

public class DeleteUserRequest
{
    public int id {get;set;}
    public string username {get;set;}
    public string password{get;set;}
    public string email {get;set;}
}
public class DeleteUserValidator:AbstractValidator<DeleteUserRequest>{
    public DeleteUserValidator(){
        RuleFor(x =>x.username).NotEmpty();
        

    }}
