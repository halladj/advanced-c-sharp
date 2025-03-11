using System;

namespace EmployeesManager;

public interface IRepository<T>
{
    T? GetByID(int id);
    IEnumerable<T> GetAll();
    void create (T entity);
    void update (T entity);
    void delete (T entity);
}
