using System;
using EmployeesManager;

namespace EmployeesManager.employee;

public class EmployeeRepository : IRepository<Employee>
{
    private readonly List<Employee> _employees = new List<Employee>{
        new Employee { Id = 1, FirstName= "rody", LastName="Guerfi", age = 24, salary= 100000},
        new Employee { Id = 2, FirstName = "Jane", LastName = "Doe" }
    };

    public Employee? GetById(int id)
    {
        return _employees.FirstOrDefault(e => e.Id == id);
    }

    public IEnumerable<Employee> GetAll()
    {
        return _employees;
    }

    public void Create(Employee entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        //we snuck this in because we're no longer providing default employees!
        entity.Id = _employees.Select(e => e.Id).DefaultIfEmpty(0).Max() + 1;
        _employees.Add(entity);
    }

    public void Update(Employee entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        var existingEmployee = GetById(entity.Id);
        if (existingEmployee != null)
        {
            existingEmployee.FirstName = entity.FirstName;
            existingEmployee.LastName = entity.LastName;
        }
    }

    public void Delete(Employee entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        _employees.Remove(entity);
    }
}

