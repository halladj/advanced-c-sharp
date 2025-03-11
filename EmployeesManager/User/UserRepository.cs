using System;
using EmployeesManager;

namespace EmployeesManager.User;

public class UserRepository : IRepository<Users>
{
    private readonly List<Users> _user = new List<Users>(){
    new Users {id=1,username = "zidane",email="hamza@gmail.com",password="fjdsjfkdsj"},
    new Users {username = "Houssem",email="Houssem@gmail.com",password="Babamama"},
};
    public void create(Users entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException();
        }
        entity.id = _user.Select(e =>e.id) .DefaultIfEmpty(0) .Max() + 1;
        _user.Add(entity);
    }

//part of the homework
    public void delete(Users entity)
    {
        if (entity == null){
            throw new ArgumentNullException();
        }
        _user.Remove(entity);
    }

    public IEnumerable<Users> GetAll()
    {
        return _user;
    }

    public Users? GetByID(int id)
    {
        return _user.FirstOrDefault(e=>e.id == id);
    }

    public void update(Users entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException();
        }
        var existingEmployee = GetByID(entity.id);
        if (existingEmployee != null)
        {
            existingEmployee.email  = entity.email;
            existingEmployee.password = entity.password;
        }
    }
}
