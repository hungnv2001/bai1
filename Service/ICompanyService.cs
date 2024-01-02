using bai1.Models;

namespace bai1.Service
{
    public interface ICompanyService
    {
        List<Company> GetAll();
        Company GetById(int id);
        bool Create(Company company);
        bool Update(Company company);
        bool Delete(int id);

    }
}
