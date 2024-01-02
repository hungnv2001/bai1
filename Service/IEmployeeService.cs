using bai1.Models;

namespace bai1.Service
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        bool Create(Employee employee);
        bool Update(Employee employee);
        bool Delete(int id);
    }
}
