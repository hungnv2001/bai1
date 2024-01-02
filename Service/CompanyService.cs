using bai1.Models;
using bai1.Repo;

namespace bai1.Service
{
    public class CompanyService : ICompanyService
    {
        public ICompanyRepo _companyRepo;
        public CompanyService()
        {
            _companyRepo = new CompanyRepo();
        }


        public bool Create(Company company)
        {
           return _companyRepo.Create(company);
        }

        public bool Delete(int id)
        {
           return (_companyRepo.Delete(id));
        }

        public List<Company> GetAll()
        {
           return _companyRepo.GetAll();
        }

        public Company GetById(int id)
        {
            return _companyRepo.GetById(id);
        }

        public bool Update(Company company)
        {
            return _companyRepo.Update(company);
        }
    }
}
