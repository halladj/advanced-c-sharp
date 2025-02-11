using System;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.employee;

public class EmployeesController : BaseController
{

    private readonly IRepository<Employee> _repository;
    // private readonly IValidator<CreateEmployeeRequest> _createValidator;

    public EmployeesController(
        IRepository<Employee> repository 
        // IValidator<CreateEmployeeRequest> createValidator
        )
    {
        _repository = repository;
        // _createValidator = createValidator;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }

    [HttpPost]
    // public IActionResult Create(CreateEmployeeRequest employee)
    public IActionResult Create(Employee employee)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    // public IActionResult Update(int id, UpdateEmployeeRequest employee)
    public IActionResult Update(int id, Employee employee)
    {
        return Ok();
    }
}
