using bai1.Models;

namespace bai1.Repo
{
    public interface IEmployeeRepo
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        bool Create(Employee employee);
        bool Update(Employee employee);
        bool Delete(int id);

    }
}
