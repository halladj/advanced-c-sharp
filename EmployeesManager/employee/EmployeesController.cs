using System;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManager.employee;

public class EmployeesController : BaseController
{

    private readonly IRepository<Employee> _repository;
    private readonly IValidator<Employee> _createValidator;

    public EmployeesController(
        IRepository<Employee> repository, 
        IValidator<Employee> createValidator
        )
    {
        _repository = repository;
        _createValidator = createValidator;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_repository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(
        [FromRoute]int id
    )
    {
        return Ok(_repository.GetById(id));
    }

    [HttpPost]
    // public IActionResult Create(CreateEmployeeRequest employee)
    public async Task<IActionResult> CreateAsync(
        [FromBody]Employee employee
        )
    {
        var validationResults = await _createValidator.ValidateAsync(employee);
        if (!validationResults.IsValid)
        {
            return ValidationProblem(validationResults.ToModelStateDictionary());
        }
        _repository.Create(employee);
        return Ok("SUCCESSSSS");
    }

    [HttpPut("{id}")]
    // public IActionResult Update(int id, UpdateEmployeeRequest employee)
    public IActionResult Update(
        [FromRoute]int id, 
        [FromBody]Employee employee
    )
    {
        _repository.Update(employee);
        return Ok(_repository.GetById(id));
    }
}
