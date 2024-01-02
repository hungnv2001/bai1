using bai1.Context;
using bai1.Models;

namespace bai1.Repo
{
    public class CompanyRepo : ICompanyRepo
    {
        private MyDbContext _context;

        public CompanyRepo()
        {
            _context = new MyDbContext();
        }
        public bool Create(Company company)
        {
            try
            {
                _context.Add(company);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Create(CompanyRepo company)
        {
            throw new NotImplementedException();
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

        public List<Company> GetAll()
        {
            try
            {

                return _context.Companys.ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Company GetById(int id)
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

        public bool Update(Company company)
        {
            try
            {
                _context.Update(company);
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
