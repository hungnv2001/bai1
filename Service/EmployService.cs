using bai1.Models;
using bai1.Repo;

namespace bai1.Service
{
    public class EmployService : IEmployeeService
    {
        public IEmployeeRepo _employeeRepo;
        public EmployService()
        {
            _employeeRepo = new EmployeeRepo();
        }
        public bool Create(Employee employee)
        {
           return _employeeRepo.Create(employee);
        }

        public bool Delete(int id)
        {
            return (_employeeRepo.Delete(id));
        }

        public List<Employee> GetAll()
        {
            return _employeeRepo.GetAll();
        }

        public Employee GetById(int id)
        {
           return _employeeRepo.GetById(id);
        }

        public bool Update(Employee employee)
        {
            return _employeeRepo.Update(employee);
        }
    }
}
