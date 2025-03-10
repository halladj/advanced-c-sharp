using System;
using EmployeesManager;

namespace EmployeesManager.Users;

public class UserRepository : IRepository<Users>
{
    private readonly List<Users> _user= new List<Users>()
    {
        new Users {id= 1, username = "zidane1591", email="hamza@gmail.com", password="shhhhhht"},
        new Users {id =2, username = "houssem", email="houssem@gmail.com", password="shhhhhht"},
    };

    public void Create(Users entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException();
        }
        entity.id = _user.Select(e => e.id).DefaultIfEmpty(0).Max() + 1;
        _user.Add(entity);
    }

    // Part of the homework
    public void Delete(Users entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException();
        }
        _user.Remove(entity);
    }

    // Part of the homework
    public IEnumerable<Users> GetAll()
    {
        return _user;
    }

    public Users? GetById(int id)
    {
        return _user.FirstOrDefault(e => e.id == id);
    }

    public void Update(Users entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException();
        }
        var existingEmployee  = GetById(entity.id);
        if (existingEmployee != null)
        {
            existingEmployee.email    = entity.email;
            existingEmployee.password = entity.password;
        }
    }
}
