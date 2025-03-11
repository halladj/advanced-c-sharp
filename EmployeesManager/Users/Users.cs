using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeesManager.Users;

public class Users
{

    public int id {get; set;}
    [Required]
    public string username {get; set;}
    [Required]
    public string password {get; set;}
    [Required, EmailAddress]
    public string email {get; set;}
}
