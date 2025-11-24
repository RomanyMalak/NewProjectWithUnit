using Second_API_project.Model;
using Second_API_project.Repository;

namespace Second_API_project.Uint_of_Ropository
{
    public interface IUnitofwork:IDisposable
    {
        IRepository<Employee> EmployeeRepository { get; }
        IRepository<Department> DepartmentRepository { get; }

        int Save();
    }
}
