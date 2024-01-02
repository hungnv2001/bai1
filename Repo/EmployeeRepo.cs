using bai1.Context;
using bai1.Models;
using Microsoft.EntityFrameworkCore;

namespace bai1.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private  MyDbContext _context;

        public EmployeeRepo() {
            _context = new MyDbContext();
        }
        public bool Create(Employee employee)
        {
            try
            {
                _context.Add(employee);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _context.Remove(GetById(id));
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Employee> GetAll()
        {
            try
            {
                
                return _context.Employees.Include(e => e.Company).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Employee GetById(int id)
        {
            try
            {

                return GetAll().FirstOrDefault(p=>p.Id==id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Update(Employee employee)
        {
            try
            {
                _context.Update(employee);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
